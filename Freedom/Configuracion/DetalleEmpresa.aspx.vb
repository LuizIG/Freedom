Imports System.Web.Services
Imports Model
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class DetalleEmpresa
    Inherits FreedomPage


    Public Property EditarDomicilio() As Boolean
        Get
            If Session("EditarDomicilio") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditarDomicilio"))
            End If
        End Get
        Set
            Session("EditarDomicilio") = Value
        End Set
    End Property

    Public Property EditarPersonalizacion() As Boolean
        Get
            If Session("EditarPersonalizacion") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditarPersonalizacion"))
            End If
        End Get
        Set
            Session("EditarPersonalizacion") = Value
        End Set
    End Property

    Public Property EditContacto() As Boolean
        Get
            If Session("EditContacto") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditContacto"))
            End If
        End Get
        Set
            Session("EditContacto") = Value
        End Set
    End Property


    Public Property EditarContactos() As Boolean
        Get
            If Session("EditarContactos") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditarContactos"))
            End If
        End Get
        Set
            Session("EditarContactos") = Value
        End Set
    End Property

    Public Property NombresContactos() As String
        Get
            If Session("NombresContactos") Is Nothing Then
                Return String.Empty
            Else
                Return Session("NombresContactos").ToString()
            End If
        End Get
        Set
            Session("NombresContactos") = Value
        End Set
    End Property

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
            UpdateEmpresa = False
            IdDomicilio = 0
            IdContacto = 0
        End If

        If EditEmpresa Then
            CargarPagina()
            txtEditarEmpresa.Text = "True"
            lblTitulo.Text = "Editar empresa"

            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "script", "UpdateResumen('" + NombresContactos + "');", True)
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
                .IdEmpresa = page.EmpresaId,
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

                If Not page.EditEmpresa Then
                    Dim empresaId = detail.GetValue("Id").Value(Of String)

                    page.UpdateEmpresa = True
                    page.ReLoadComboEmpresa = True
                    page.EmpresaId = Convert.ToInt32(empresaId)
                End If

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
            Dim pageDet = New DetalleEmpresa()
            Dim loginsession = page.UserSession

            Dim domicilio = New DomicilioEmpresa() With {
                .IdDomicilio = page.IdDomicilio,
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

            Dim req = ""
            Dim msjRet = ""

            If page.EditEmpresa AndAlso pageDet.EditarDomicilio Then
                req = PutRequest("api/DomicilioEmpresa", loginsession.Token, data)
                msjRet = "Domicilio Fiscal actualizado"
            Else
                req = PostRequest("api/DomicilioEmpresa", data, loginsession.Token)
                msjRet = "Domicilio Fiscal guardado"
            End If

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
                        .IdDomicilio = page.IdDomicilio,
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

                    If page.EditEmpresa AndAlso pageDet.EditarDomicilio Then
                        req = PutRequest("api/DomicilioEmpresa", loginsession.Token, data)
                        msjRet = "Domicilio Fiscal y Lugar de Emision actualizados"
                    Else
                        req = PostRequest("api/DomicilioEmpresa", data, loginsession.Token)
                        msjRet = "Domicilio Fiscal y Lugar de Emision guardados"
                    End If

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
                Else
                    Dim list = New List(Of DomicilioEmpresa) From {
                        domicilio
                    }

                    data = JsonConvert.SerializeObject(list)
                    Return New ServiceResult() With {
                        .Result = True,
                        .Message = msjRet,
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
            Dim tituloCorreo = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "TITULOCORREO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "TITULOCORREO").ToList()(0).ParamValue.ToString(), "")
            Dim contenidoCorreo = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CONTENIDOCORREO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CONTENIDOCORREO").ToList()(0).ParamValue.ToString(), "")

            Dim pageDet = New DetalleEmpresa()
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim personalizacion = New PersonalizacionEmpresa() With {
                .idEmpresa = page.EmpresaId,
                .idOrganizacion = loginsession.OrganizacionId,
                .nombreComercial = nombreComercial,
                .logo = logo,
                .mensajeAdicionalFactura = mensajeFactura,
                .telefono = telefonoFactura,
                .correo = correoFactura,
                .tituloCorreo = tituloCorreo,
                .cuerpoCorreo = contenidoCorreo
            }

            Dim data = JsonConvert.SerializeObject(personalizacion)

            Dim req = ""
            Dim msjRet = ""

            If page.EditEmpresa AndAlso pageDet.EditarPersonalizacion Then
                req = PutRequest("api/ConfiguracionEmpresa", loginsession.Token, data)
                msjRet = "Personalización actualizado"
            Else
                req = PostRequest("api/ConfiguracionEmpresa", data, loginsession.Token)
                msjRet = "Personalización guardada"
            End If

            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "Personalización guardada",
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

            Dim pageDet = New DetalleEmpresa()
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession
            Dim nombresContactos = ""
            Dim contactos = DirectCast(HttpContext.Current.Session("tblContactos"), DataTable)
            Dim msjRet = ""

            For Each row As DataRow In contactos.Rows
                Dim contacto = New ContactoEmpresa() With {
                    .idEmpresa = page.EmpresaId,
                    .id = Convert.ToInt32(row("ContactoId")),
                    .nombre = row("NombreContacto"),
                    .telefono = row("TelefonoFijo"),
                    .telefonoMovil = row("TelefonoMovil"),
                    .correoElectronico = row("Correo"),
                    .puesto = row("Puesto"),
                    .tipoContacto = row("TipoContacto")
                }

                nombresContactos += row("NombreContacto") + "<br/>"

                Dim req = ""
                Dim data = JsonConvert.SerializeObject(contacto)

                If page.EditEmpresa AndAlso pageDet.EditarContactos Then
                    req = PutRequest("api/ContactoEmpresa", loginsession.Token, data)
                    msjRet = "Contactos actualizados"
                Else
                    req = PostRequest("api/ContactoEmpresa", data, loginsession.Token)
                    msjRet = "Contactos guardados"
                End If

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
                .Message = msjRet,
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

        If EditContacto Then
            tbl = DirectCast(Session("tblContactos"), DataTable)

            For Each row As DataRow In tbl.Rows
                If CInt(row("ContactoId")) = IdContacto Then
                    row("ContactoId") = IdContacto
                    row("NombreContacto") = nombreContacto
                    row("TelefonoFijo") = telFijo
                    row("TelefonoMovil") = telMovil
                    row("Correo") = correo
                    row("Puesto") = puesto
                    Exit For
                End If
            Next
        Else
            If Session("tblContactos") Is Nothing Then
                tbl.Columns.Add("ContactoId")
                tbl.Columns.Add("NombreContacto")
                tbl.Columns.Add("TipoContacto")
                tbl.Columns.Add("TelefonoFijo")
                tbl.Columns.Add("TelefonoMovil")
                tbl.Columns.Add("Correo")
                tbl.Columns.Add("Puesto")

                Dim id As Integer = 0

                If tbl.Rows.Count > 0 Then
                    id = tbl.Rows.Count
                End If

                tbl.Rows.Add(id, nombreContacto, tipoContacto, telFijo, telMovil, correo, puesto)
            Else
                tbl = DirectCast(Session("tblContactos"), DataTable)
                Dim newRow = tbl.NewRow

                newRow(0) = tbl.Rows.Count
                newRow(1) = nombreContacto
                newRow(2) = tipoContacto
                newRow(3) = telFijo
                newRow(4) = telMovil
                newRow(5) = correo
                newRow(6) = puesto

                tbl.Rows.Add(newRow)
            End If
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
        CargarDomicilio()
        CargarPersonalizacion()
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

            If empresa.Count > 0 Then
                txtNombre.Text = empresa(0).NombreEmpresa
                txtRFC.Text = empresa(0).RFC
                'cbxRegimenFiscal.Items.FindByValue(empresa(0).).Selected = True
                txtCURP.Text = empresa(0).CURP
            End If
        End If
    End Sub

    Public Sub CargarPersonalizacion()
        Dim url = "api/ConfiguracionEmpresa/" & EmpresaId & "?idOrganizacion=" & UserSession.OrganizacionId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim personalizacion As List(Of PersonalizacionResult) = StringToValue(detail.ToString(), GetType(List(Of PersonalizacionResult)))

            If personalizacion.Count > 0 Then
                EditarPersonalizacion = True
                Dim NombreLogo = personalizacion(0).LogoTipoNombre

                If Not NombreLogo = "" Then
                    url = SERVER_HOST & "logos/" & NombreLogo
                    output.Src = url
                End If

                txtLogo.Text = NombreLogo
                txtNombreComercial.Text = If(personalizacion(0).NombreComercial, "")
                txtMensaje.Text = If(personalizacion(0).MensajeAdicionalFactura, "")
                txtTelefonos.Text = If(personalizacion(0).Telefono, "")
                txtCorreo.Text = If(personalizacion(0).CorreoElectronico, "")
                txtTitulo.Text = If(personalizacion(0).TituloCorreo, "")
                txtContenido.Text = If(personalizacion(0).CuerpoCorreo, "")
            Else
                EditarPersonalizacion = False
            End If
        End If
    End Sub

    Public Sub CargarDomicilio()
        Dim url = "api/DomicilioEmpresa?idEmpresa=" & EmpresaId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim domicilio As List(Of DomicilioResult) = StringToValue(detail.ToString(), GetType(List(Of DomicilioResult)))

            If domicilio.Count > 0 Then
                EditarDomicilio = True
                IdDomicilio = domicilio(0).DomicilioId
                txtCalle.Text = If(domicilio(0).Calle, "")
                txtNumExt.Text = If(domicilio(0).NumeroExterno, "")
                txtNumInt.Text = If(domicilio(0).NumeroInterno, "")
                txtCalles.Text = If(domicilio(0).EntreCalles, "")
                txtColonia.Text = If(domicilio(0).Colonia, "")
                txtCP.Text = If(domicilio(0).CP, "")
                cbxPais.Items.FindByText("MEXICO").Selected = True
                'cbxEstado.Items.FindByValue(If(domicilio(0).EstadoId = 0, 1, domicilio(0).EstadoId)).Selected = True
                txtMunicipio.Text = If(domicilio(0).Municipio, "")
                'cbxEmision.Checked = domicilio(0).EmisionFlg

                If Not domicilio(0).EmisionFlg Then
                    txtCalleEmision.Text = If(domicilio(1).Calle, "")
                    txtNumExtEmision.Text = If(domicilio(1).NumeroExterno, "")
                    txtNumIntEmision.Text = If(domicilio(1).NumeroInterno, "")
                    txtCallesEmision.Text = If(domicilio(1).EntreCalles, "")
                    txtColoniaEmision.Text = If(domicilio(1).Colonia, "")
                    txtCPEmision.Text = If(domicilio(1).CP, "")
                    cbxPaisEmision.Items.FindByText("MEXICO").Selected = True
                    'cbxEstadoEmision.Items.FindByValue(If(domicilio(1).EstadoId = 0, 1, domicilio(1).EstadoId)).Selected = True
                    txtMunicipioEmision.Text = If(domicilio(1).Municipio, "")
                End If
            Else
                EditarDomicilio = False
            End If
        End If
    End Sub

    Public Sub CargarContactos()
        Dim url = "api/ContactoEmpresa?idEmpresa=" & EmpresaId & "&idOrganizacion=" & UserSession.OrganizacionId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim contactos As List(Of ContactoResult) = StringToValue(detail.ToString(), GetType(List(Of ContactoResult)))
            Dim tbl = New DataTable()

            If contactos.Count > 0 Then
                EditarContactos = True

                If Session("tblContactos") Is Nothing Then
                    tbl.Columns.Add("ContactoId")
                    tbl.Columns.Add("NombreContacto")
                    tbl.Columns.Add("TipoContacto")
                    tbl.Columns.Add("TelefonoFijo")
                    tbl.Columns.Add("TelefonoMovil")
                    tbl.Columns.Add("Correo")
                    tbl.Columns.Add("Puesto")

                    NombresContactos = ""

                    For Each contacto As ContactoResult In contactos
                        NombresContactos += contacto.Nombre + "<br/>"
                        tbl.Rows.Add(contacto.ContactoId, contacto.Nombre, contacto.TipoContacto, contacto.TelefonoFijo, contacto.TelefonoMovil, contacto.CorreoElectronico, contacto.Puesto)
                    Next

                    tbl.AcceptChanges()
                    repContactos.DataSource = tbl
                    repContactos.DataBind()
                    Session("tblContactos") = tbl
                End If
            Else
                EditarContactos = False
            End If
        End If
    End Sub

    Protected Sub btnEditarContacto_Click(sender As Object, e As CommandEventArgs)
        Dim contactoId = e.CommandArgument
        EditarContacto(CInt(contactoId))
    End Sub

    Protected Sub btnEliminarContacto_Click(sender As Object, e As CommandEventArgs)
        Dim contactoId = e.CommandArgument
        EliminarContacto(CInt(contactoId))
    End Sub

    Public Sub EditarContacto(contactoId As Integer)
        Dim tbl = DirectCast(Session("tblContactos"), DataTable)

        For Each row As DataRow In tbl.Rows
            If CInt(row("ContactoId")) = contactoId Then
                txtNombreContacto.Text = row("NombreContacto")
                txtTelefonoFijo.Text = row("TelefonoFijo")
                txtMovil.Text = row("TelefonoMovil")
                txtCorreoContacto.Text = row("Correo")
                txtPuesto.Text = row("Puesto")
                EditContacto = True
                IdContacto = contactoId
                Exit For
            End If
        Next
    End Sub

    Public Sub EliminarContacto(contactoId As String)
        Try
            Dim tbl = DirectCast(Session("tblContactos"), DataTable)

            If EditEmpresa Then
                Dim contacto = New EliminaContacto() With {
                    .id = Convert.ToInt32(contactoId),
                    .idEmpresa = EmpresaId,
                    .idOrganizacion = UserSession.OrganizacionId
                }

                Dim data = JsonConvert.SerializeObject(contacto)
                Dim url = "api/ContactoEmpresa"
                Dim req = DeleteRequest(url, UserSession.Token, data)
                Dim result = JObject.Parse(req)
                Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

                If (statusCode >= 200 And statusCode < 400) Then
                    For Each row As DataRow In tbl.Rows
                        If row("ContactoId") = contactoId Then
                            tbl.Rows.Remove(row)
                        End If
                    Next

                    tbl.AcceptChanges()
                    repContactos.DataSource = tbl
                    repContactos.DataBind()
                    Session("tblContactos") = tbl
                Else
                    Dim errorMessage = result.GetValue("errorMessage").Value(Of String)

                End If
            Else
                For Each row As DataRow In tbl.Rows
                    If row("ContactoId") = contactoId Then
                        tbl.Rows.Remove(row)
                    End If
                Next

                tbl.AcceptChanges()
                repContactos.DataSource = tbl
                repContactos.DataBind()
                Session("tblContactos") = tbl
            End If
        Catch ex As Exception

        End Try
    End Sub

    '<WebMethod(EnableSession:=True)>
    'Public Shared Function EliminarContacto(contactoId As String) As ServiceResult
    '    Try
    '        Dim page = New FreedomPage()
    '        Dim loginsession = page.UserSession
    '        Dim curPage As Page = DirectCast(HttpContext.Current.Handler, Page)
    '        Dim repContactos As Repeater = DirectCast(curPage.FindControl("repContactos"), Repeater)
    '        Dim tbl = DirectCast(HttpContext.Current.Session("tblContactos"), DataTable)

    '        If page.EditEmpresa Then
    '            Dim contacto = New ContactoEmpresa() With {
    '                .id = Convert.ToInt32(contactoId),
    '                .idEmpresa = page.EmpresaId,
    '                .idOrganizacion = loginsession.OrganizacionId
    '            }

    '            Dim data = JsonConvert.SerializeObject(contacto)
    '            Dim url = "api/ContactoEmpresa"
    '            Dim req = DeleteRequest(url, loginsession.Token, data)
    '            Dim result = JObject.Parse(req)
    '            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

    '            If (statusCode >= 200 And statusCode < 400) Then

    '                For Each row As DataRow In tbl.Rows
    '                    If row("ContactoId") = contactoId Then
    '                        tbl.Rows.Remove(row)
    '                    End If
    '                Next

    '                tbl.AcceptChanges()
    '                repContactos.DataSource = tbl
    '                repContactos.DataBind()
    '                HttpContext.Current.Session("tblContactos") = tbl

    '                Return New ServiceResult() With {
    '                    .Result = True,
    '                    .Message = "Contacto eliminado",
    '                    .Ret = ""
    '                }
    '            Else
    '                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
    '                Return New ServiceResult() With {
    '                    .Result = False,
    '                    .Message = errorMessage,
    '                    .Ret = ""
    '                }
    '            End If
    '        Else
    '            For Each row As DataRow In tbl.Rows
    '                If row("ContactoId") = contactoId Then
    '                    tbl.Rows.Remove(row)
    '                End If
    '            Next

    '            tbl.AcceptChanges()
    '            repContactos.DataSource = tbl
    '            repContactos.DataBind()
    '            HttpContext.Current.Session("tblContactos") = tbl

    '            Return New ServiceResult() With {
    '                .Result = True,
    '                .Message = "Contacto eliminado",
    '                .Ret = ""
    '            }
    '        End If
    '    Catch ex As Exception
    '        Return New ServiceResult() With {
    '            .Result = False,
    '            .Message = ex.Message,
    '            .Ret = ""
    '        }
    '    End Try
    'End Function

    Protected Sub btnAgregarContacto_Click(sender As Object, e As EventArgs)
        CargarTablaContactos()
    End Sub

    Protected Sub btnTriggerUpdate_Click(sender As Object, e As EventArgs)
        'CargarEmpresas(UserSession.OrganizacionId)
    End Sub

    Protected Sub repContactos_ItemCreated(sender As Object, e As RepeaterItemEventArgs)
        Dim scriptMan As ScriptManager = ScriptManager.GetCurrent(Me)
        Dim btn As LinkButton = TryCast(e.Item.FindControl("btnEditarContacto"), LinkButton)
        If btn IsNot Nothing Then
            scriptMan.RegisterAsyncPostBackControl(btn)
        End If
    End Sub
End Class