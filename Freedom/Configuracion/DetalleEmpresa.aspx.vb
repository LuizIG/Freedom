Imports System.Web.Services
Imports Model
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class DetalleEmpresa
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)
        SelectMenuItem("menu_span_configuracion")
        SelectMenuItem("menu_span_configuracion_sistema")
        SelectMenuItem("menu_span_configuracion_sistema_empresa")

        MaintainScrollPositionOnPostBack = True

        CargarRegimenFiscal()
        CargarPaises()
        'CargarTipoImpuesto()
        'CargarComprobante()

        If Not IsPostBack Then
            Session("tblContactos") = Nothing
        End If

        If EditEmpresa Then
            CargarPagina()
            txtEditarEmpresa.Text = "True"
            lblTitulo.Text = "Editar empresa"
        Else
            lblTitulo.Text = "Nueva empresa"
        End If
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarEmpresa(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim nombre = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRE").ToList()(0).ParamValue.ToString(), "")
            Dim rfc = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "RFC").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "RFC").ToList()(0).ParamValue.ToString(), "")
            Dim regimendFiscalId = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCALID").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCALID").ToList()(0).ParamValue.ToString(), "")
            Dim regimendFiscal = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCAL").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCAL").ToList()(0).ParamValue.ToString(), "")
            Dim activo = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "ACTIVO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "ACTIVO").ToList()(0).ParamValue.ToString(), "")
            Dim predeterminado = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "PREDETERMINADO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "PREDETERMINADO").ToList()(0).ParamValue.ToString(), "")
            Dim curp = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CURP").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CURP").ToList()(0).ParamValue.ToString(), "")

            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim empresa = New Model.Empresa() With {
                .NombreEmpresa = nombre,
                .RFC = rfc,
                .RegimenFiscalId = regimendFiscalId,
                .RegimenFiscal = regimendFiscal,
                .ActivoFlg = Boolean.Parse(activo),
                .DefaultFlg = Boolean.Parse(predeterminado),
                .CURP = curp,
                .OrganizacionId = loginsession.OrganizacionId.ToString()
            }

            Dim req = ""
            Dim msjRet = ""
            Dim data = JsonConvert.SerializeObject(empresa)

            If page.EditEmpresa Then
                req = PutRequest("api/Empresas", loginsession.Token, data)
                msjRet = "Información general actualizada"
            Else
                req = PostRequest("api/Empresas", data, loginsession.Token)
                msjRet = "Información general guardada"
            End If

            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Dim detail = result.GetValue("detail").Value(Of JObject)
                Dim empresaId = detail.GetValue("Id").Value(Of String)

                page.EmpresaId = Convert.ToInt32(empresaId)

                Return New ServiceResult() With {
                    .Result = True,
                    .Message = msjRet,
                    .Ret = data
                }
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = errorMessage,
                    .Ret = ""
                }
            End If
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarDomicilio(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim calle = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLE").ToList()(0).ParamValue.ToString(), "")
            Dim numExt = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMEXT").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMEXT").ToList()(0).ParamValue.ToString(), "")
            Dim numInt = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMINT").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMINT").ToList()(0).ParamValue.ToString(), "")
            Dim calles = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLES").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLES").ToList()(0).ParamValue.ToString(), "")
            Dim colonia = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "COLONIA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "COLONIA").ToList()(0).ParamValue.ToString(), "")
            Dim cp = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CP").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CP").ToList()(0).ParamValue.ToString(), "")
            Dim municipio = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "MUNICIPIO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "MUNICIPIO").ToList()(0).ParamValue.ToString(), "")
            Dim estado = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADO").ToList()(0).ParamValue.ToString(), "")
            Dim pais = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "PAIS").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "PAIS").ToList()(0).ParamValue.ToString(), "")
            Dim esLugarEmision = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "LUGAREMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "LUGAREMISION").ToList()(0).ParamValue.ToString(), "")

            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim domicilio = New DomicilioEmpresa() With {
                .IdEmpresa = page.EmpresaId,
                .calle = calle,
                .numeroExterno = numExt,
                .numeroInterno = numInt,
                .entreCalles = calles,
                .colonia = colonia,
                .cp = cp,
                .municipio = municipio,
                .estadoId = estado,
                .fiscalFlg = True,
                .emisionFlg = Boolean.Parse(esLugarEmision),
                .activoFlg = True
            }

            Dim data = JsonConvert.SerializeObject(domicilio)
            Dim req = PostRequest("api/DomicilioEmpresa", data, loginsession.Token)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                If Not Boolean.Parse(esLugarEmision) Then
                    calle = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLEEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLEEMISION").ToList()(0).ParamValue.ToString(), "")
                    numExt = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMEXTEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMEXTEMISION").ToList()(0).ParamValue.ToString(), "")
                    numInt = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMINTEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NUMINTEMISION").ToList()(0).ParamValue.ToString(), "")
                    calles = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLESEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CALLESEMISION").ToList()(0).ParamValue.ToString(), "")
                    colonia = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "COLONIAEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "COLONIAEMISION").ToList()(0).ParamValue.ToString(), "")
                    cp = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CPEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CPEMISION").ToList()(0).ParamValue.ToString(), "")
                    municipio = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "MUNICIPIOEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "MUNICIPIOEMISION").ToList()(0).ParamValue.ToString(), "")
                    estado = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADOEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADOEMISION").ToList()(0).ParamValue.ToString(), "")
                    pais = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "PAISEMISION").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "PAISEMISION").ToList()(0).ParamValue.ToString(), "")

                    Dim lugarEmision = New DomicilioEmpresa() With {
                            .IdEmpresa = page.EmpresaId,
                            .calle = calle,
                            .numeroExterno = numExt,
                            .numeroInterno = numInt,
                            .entreCalles = calles,
                            .colonia = colonia,
                            .cp = cp,
                            .municipio = municipio,
                            .estadoId = estado,
                            .fiscalFlg = False,
                            .emisionFlg = True,
                            .activoFlg = True
                        }

                    data = JsonConvert.SerializeObject(lugarEmision)
                    req = PostRequest("api/DomicilioEmpresa", data, loginsession.Token)
                    result = JObject.Parse(req)
                    statusCode = result.GetValue("statusCode").Value(Of Integer)

                    If (statusCode >= 200 And statusCode < 400) Then
                        Dim list = New List(Of DomicilioEmpresa) From {
                            domicilio,
                            lugarEmision
                        }

                        data = JsonConvert.SerializeObject(list)
                        Return New ServiceResult() With {
                            .Result = True,
                            .Message = "Domicilio Fiscal y lugar de emisión guardados",
                            .Ret = data
                        }
                    Else
                        Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                        Return New ServiceResult() With {
                            .Result = False,
                            .Message = errorMessage,
                            .Ret = ""
                        }
                    End If
                Else
                    Dim list = New List(Of DomicilioEmpresa) From {
                        domicilio
                    }

                    data = JsonConvert.SerializeObject(list)
                    Return New ServiceResult() With {
                        .Result = True,
                        .Message = "Domicilio Fiscal guardado",
                        .Ret = data
                    }
                End If
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                Return New ServiceResult() With {
                        .Result = False,
                        .Message = errorMessage,
                        .Ret = ""
                    }
            End If
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarPersonalizacion(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim nombreComercial = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRECOMERCIAL").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRECOMERCIAL").ToList()(0).ParamValue.ToString(), "")
            Dim logo = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "LOGO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "LOGO").ToList()(0).ParamValue.ToString(), "")
            Dim mensajeFactura = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "MENSAJEFACTURA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "MENSAJEFACTURA").ToList()(0).ParamValue.ToString(), "")
            Dim telefonoFactura = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "TELEFONOFACTURA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "TELEFONOFACTURA").ToList()(0).ParamValue.ToString(), "")
            Dim correoFactura = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CORREOFACTURA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CORREOFACTURA").ToList()(0).ParamValue.ToString(), "")

            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim personalizacion = New PersonalizacionEmpresa() With {
                .idEmpresa = page.EmpresaId,
                .idOrganizacion = loginsession.OrganizacionId,
                .nombreComercial = nombreComercial,
                .logo = logo,
                .mensajeFactura = mensajeFactura,
                .telefonoFactura = telefonoFactura,
                .correoFactura = correoFactura
            }

            Dim data = JsonConvert.SerializeObject(personalizacion)
            Dim req = PostRequest("api/CertificadoEmpresa", data, loginsession.Token)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "Personalización guardada",
                    .Ret = ""
                }
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = errorMessage,
                    .Ret = ""
                }
            End If
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarCertificados(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim llavePublica = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "LLAVEPUBLICA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "LLAVEPUBLICA").ToList()(0).ParamValue.ToString(), "")
            Dim llavePrivada = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "LLAVEPRIVADA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "LLAVEPRIVADA").ToList()(0).ParamValue.ToString(), "")
            Dim selloDigital = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "SELLODIGITAL").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "SELLODIGITAL").ToList()(0).ParamValue.ToString(), "")

            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim certificados = New CertificadoEmpresa() With {
                .idEmpresa = page.EmpresaId,
                .idOrganizacion = loginsession.OrganizacionId,
                .certificado = selloDigital,
                .llavePrivada = llavePrivada,
                .llavePublica = llavePublica
            }

            Dim data = JsonConvert.SerializeObject(certificados)
            Dim req = PostRequest("api/CertificadoEmpresa", data, loginsession.Token)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "Certificados guardados",
                    .Ret = data
                }
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = errorMessage,
                    .Ret = ""
                }
            End If
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarContactos() As ServiceResult
        Try
            If HttpContext.Current.Session("tblContactos") Is Nothing Then
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = "Es necesario agregar al menos un contacto",
                    .Ret = ""
                }
            End If

            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession
            Dim nombresContactos = ""
            Dim contactos = DirectCast(HttpContext.Current.Session("tblContactos"), DataTable)

            For Each row As DataRow In contactos.Rows
                Dim contacto = New ContactoEmpresa() With {
                    .idEmpresa = page.EmpresaId,
                    .nombre = row("NombreContacto"),
                    .telefono = row("TelefonoFijo"),
                    .telefonoMovil = row("TelefonoMovil"),
                    .correoElectronico = row("Correo"),
                    .puesto = row("Puesto"),
                    .tipoContacto = row("TipoContacto")
                }

                nombresContactos += row("NombreContacto") + "<br/>"
                Dim data = JsonConvert.SerializeObject(contacto)
                Dim req = PostRequest("api/ContactoEmpresa", data, loginsession.Token)
                Dim result = JObject.Parse(req)
                Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

                If (statusCode >= 200 And statusCode < 400) Then
                    Continue For
                Else
                    Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                    Return New ServiceResult() With {
                        .Result = False,
                        .Message = errorMessage,
                        .Ret = ""
                    }
                End If
            Next

            Return New ServiceResult() With {
                .Result = True,
                .Message = "Contactos guardados",
                .Ret = nombresContactos
            }
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarImpuestos(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim tipoComprobanteId = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "TIPOCOMPROBANTEID").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "TIPOCOMPROBANTEID").ToList()(0).ParamValue.ToString(), "")
            Dim tipoComprobante = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "TIPOCOMPROBANTE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "TIPOCOMPROBANTE").ToList()(0).ParamValue.ToString(), "")
            Dim impuestoValue = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "IMPUESTO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "IMPUESTO").ToList()(0).ParamValue, "")
            Dim impuestoIdValue = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "IMPUESTOID").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "IMPUESTOID").ToList()(0).ParamValue, "")
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim impuestos = DirectCast(impuestoIdValue, IList)
            Dim valorImpuestos = DirectCast(impuestoValue, IList)

            Dim list = New List(Of ConfiguracionImpuesto)

            If impuestos.Count > 0 Then
                For Each impuestoId As String In impuestoIdValue
                    Dim configImpuesto = New ConfiguracionImpuesto() With {
                        .idEmpresa = page.EmpresaId,
                        .idTipoComprobante = Convert.ToInt32(tipoComprobanteId),
                        .TipoComprobante = tipoComprobante,
                        .TipoImpuesto = impuestoValue.ToString(),
                        .idTipoImpuesto = Convert.ToInt32(impuestoId)
                    }

                    list.Add(configImpuesto)

                    Dim data = JsonConvert.SerializeObject(configImpuesto)
                    Dim req = PostRequest("api/ConfiguracionImpuesto", data, loginsession.Token)
                    Dim result = JObject.Parse(req)
                    Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

                    If (statusCode >= 200 And statusCode < 400) Then
                        Continue For
                    Else
                        Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                        Return New ServiceResult() With {
                            .Result = False,
                            .Message = errorMessage,
                            .Ret = ""
                        }
                    End If
                Next
            Else
                Dim configImpuesto = New ConfiguracionImpuesto() With {
                    .idEmpresa = page.EmpresaId,
                    .idTipoComprobante = Convert.ToInt32(tipoComprobanteId),
                    .TipoComprobante = tipoComprobante,
                    .TipoImpuesto = "",
                    .idTipoImpuesto = 0
                }

                list.Add(configImpuesto)
                Dim data = JsonConvert.SerializeObject(configImpuesto)
                Dim req = PostRequest("api/ConfiguracionImpuesto", data, loginsession.Token)
                Dim result = JObject.Parse(req)
                Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

                If (statusCode >= 200 And statusCode < 400) Then

                Else
                    Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                    Return New ServiceResult() With {
                        .Result = False,
                        .Message = errorMessage,
                        .Ret = ""
                    }
                End If
            End If

            Dim retData = JsonConvert.SerializeObject(list)
            Return New ServiceResult() With {
                    .Result = True,
                    .Message = "Configuración de impuestos guardada",
                    .Ret = retData
                }
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function CargarEstados(paisId As String) As ServiceResult
        Try
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession
            Dim id As Integer = Convert.ToInt32(paisId)
            Dim url = "api/Estados?idPais=" & id
            Dim req = GetRequest(url, loginsession.Token)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Dim detail = result.GetValue("detail").Value(Of JArray)

                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "",
                    .Ret = detail.ToString()
                }
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)

                Return New ServiceResult() With {
                .Result = False,
                .Message = errorMessage,
                .Ret = ""
            }
            End If

        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    Public Sub CargarTablaContactos()
        Dim tbl = New DataTable()
        Dim nombreContacto = txtNombreContacto.Text
        Dim tipoContacto = "" 'cbxTipoContacto.Value
        Dim telFijo = txtTelefonoFijo.Text
        Dim telMovil = txtMovil.Text
        Dim correo = txtCorreoContacto.Text
        Dim puesto = txtPuesto.Text

        If Session("tblContactos") Is Nothing Then
            tbl.Columns.Add("NombreContacto")
            tbl.Columns.Add("TipoContacto")
            tbl.Columns.Add("TelefonoFijo")
            tbl.Columns.Add("TelefonoMovil")
            tbl.Columns.Add("Correo")
            tbl.Columns.Add("Puesto")

            tbl.Rows.Add(nombreContacto, tipoContacto, telFijo, telMovil, correo, puesto)
        Else
            tbl = DirectCast(Session("tblContactos"), DataTable)
            Dim newRow = tbl.NewRow

            newRow(0) = nombreContacto
            newRow(1) = tipoContacto
            newRow(2) = telFijo
            newRow(3) = telMovil
            newRow(4) = correo
            newRow(5) = puesto

            tbl.Rows.Add(newRow)
        End If

        txtNombreContacto.Text = ""
        'txtTipoContacto.Text = ""
        txtTelefonoFijo.Text = ""
        txtMovil.Text = ""
        txtCorreoContacto.Text = ""
        txtPuesto.Text = ""

        tbl.AcceptChanges()
        repContactos.DataSource = tbl
        repContactos.DataBind()
        Session("tblContactos") = tbl
    End Sub

    Public Sub CargarRegimenFiscal()
        Dim req = GetRequest("api/RegimenFiscal", UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)

            cbxRegimenFiscal.DataSource = detail
            cbxRegimenFiscal.DataValueField = "RegimenFiscalId"
            cbxRegimenFiscal.DataTextField = "RegimenFiscal"
            cbxRegimenFiscal.DataBind()
        End If
    End Sub

    Public Sub CargarPaises()
        Dim req = GetRequest("api/Paises", UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)

            cbxPais.DataSource = detail
            cbxPais.DataValueField = "PaisId"
            cbxPais.DataTextField = "Pais"
            cbxPais.DataBind()

            cbxPaisEmision.DataSource = detail
            cbxPaisEmision.DataValueField = "PaisId"
            cbxPaisEmision.DataTextField = "Pais"
            cbxPaisEmision.DataBind()
        End If
    End Sub

    'Public Sub CargarTipoImpuesto()
    '    Dim req = GetRequest("api/TipoImpuesto", UserSession.Token)
    '    Dim result = JObject.Parse(req)
    '    Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

    '    If (statusCode >= 200 And statusCode < 400) Then
    '        Dim detail = result.GetValue("detail").Value(Of JArray)
    '        Dim tipoImpuesto As List(Of TipoImpuesto) = StringToValue(detail.ToString(), GetType(List(Of TipoImpuesto)))

    '        repImpuestos.DataSource = tipoImpuesto
    '        repImpuestos.DataBind()
    '    End If
    'End Sub

    'Public Sub CargarComprobante()
    '    Dim req = GetRequest("api/TipoComprobanteEsquemaFiscal?esquemafiscal=CFDI", UserSession.Token)
    '    Dim result = JObject.Parse(req)
    '    Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

    '    If (statusCode >= 200 And statusCode < 400) Then
    '        Dim detail = result.GetValue("detail").Value(Of JArray)
    '        Dim comprobantes As List(Of Comprobante) = StringToValue(detail.ToString(), GetType(List(Of Comprobante)))

    '        cbxComprobante.DataSource = comprobantes
    '        cbxComprobante.DataValueField = "TipoComprobanteId"
    '        cbxComprobante.DataTextField = "TipoComprobante"
    '        cbxComprobante.DataBind()
    '    End If
    'End Sub

    Public Sub CargarPagina()
        CargarEmpresa()
        CargarContactos()
    End Sub

    Public Sub CargarEmpresa()
        Dim url = "api/Empresas/" & EmpresaId & "?idOrganizacion=" & UserSession.OrganizacionId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim empresa As List(Of EmpresaResult) = StringToValue(detail.ToString(), GetType(List(Of EmpresaResult)))

            txtNombre.Text = empresa(0).NombreEmpresa
            txtRFC.Text = empresa(0).RFC
            'cbxRegimenFiscal.Items.FindByValue(empresa(0).).Selected = True
            txtCURP.Text = empresa(0).CURP

            txtCalle.Text = If(empresa(0).Calle_Fiscal, "")
            txtNumExt.Text = If(empresa(0).NumeroExterno_Fiscal, "")
            txtNumInt.Text = If(empresa(0).NumeroInterno_Fiscal, "")
            txtCalles.Text = If(empresa(0).EntreCalles_Fiscal, "")
            txtColonia.Text = If(empresa(0).Colonia_Fiscal, "")
            txtCP.Text = If(empresa(0).CP_Fiscal, "")
            cbxPais.Items.FindByText(If(empresa(0).Pais_Fiscal, "MEXICO")).Selected = True
            'cbxEstado.Items.FindByValue(If(empresa(0).EstadoId_Fiscal = 0, 1, empresa(0).EstadoId_Fiscal)).Selected = True
            txtMunicipio.Text = If(empresa(0).Municipio_Fiscal, "")

            txtCalleEmision.Text = If(empresa(0).Calle_Emision, "")
            txtNumExtEmision.Text = If(empresa(0).NumeroExterno_Emision, "")
            txtNumIntEmision.Text = If(empresa(0).NumeroInterno_Emision, "")
            txtCallesEmision.Text = If(empresa(0).EntreCalles_Emision, "")
            txtColoniaEmision.Text = If(empresa(0).Colonia_Emision, "")
            txtCPEmision.Text = If(empresa(0).CP_Emision, "")
            cbxPaisEmision.Items.FindByText(If(empresa(0).Pais_Emision, "MEXICO")).Selected = True
            'cbxEstadoEmision.Items.FindByValue(If(empresa(0).EstadoId_Emision = 0, 1, empresa(0).EstadoId_Emision)).Selected = True
            txtMunicipioEmision.Text = If(empresa(0).Municipio_Emision, "")
        End If
    End Sub

    Public Sub CargarContactos()
        Dim url = "api/ContactoEmpresa?idEmpresa=" & EmpresaId & "&idOrganizacion=" & UserSession.OrganizacionId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim contactos As List(Of ContactoEmpresa) = StringToValue(detail.ToString(), GetType(List(Of ContactoEmpresa)))
            Dim tbl = New DataTable()

            If Session("tblContactos") Is Nothing Then
                tbl.Columns.Add("NombreContacto")
                tbl.Columns.Add("TipoContacto")
                tbl.Columns.Add("TelefonoFijo")
                tbl.Columns.Add("TelefonoMovil")
                tbl.Columns.Add("Correo")
                tbl.Columns.Add("Puesto")

                For Each contacto As ContactoEmpresa In contactos
                    tbl.Rows.Add(contacto.nombre, contacto.tipoContacto, contacto.telefono, contacto.telefonoMovil, contacto.correoElectronico, contacto.puesto)
                Next

                tbl.AcceptChanges()
                repContactos.DataSource = tbl
                repContactos.DataBind()
                Session("tblContactos") = tbl
            End If
        End If
    End Sub

    Protected Sub btnAgregarContacto_Click(sender As Object, e As EventArgs)
        CargarTablaContactos()
    End Sub
End Class