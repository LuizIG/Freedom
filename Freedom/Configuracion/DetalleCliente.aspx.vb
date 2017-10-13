Imports System.Web.Services
Imports Model
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class DetalleCliente
    Inherits FreedomPage

    Public Property EditarDomicilioCliente() As Boolean
        Get
            If Session("EditarDomicilioCliente") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditarDomicilioCliente"))
            End If
        End Get
        Set
            Session("EditarDomicilioCliente") = Value
        End Set
    End Property

    Public Property EditarPersonalizacionCliente() As Boolean
        Get
            If Session("EditarPersonalizacionCliente") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditarPersonalizacionCliente"))
            End If
        End Get
        Set
            Session("EditarPersonalizacionCliente") = Value
        End Set
    End Property

    Public Property EditContactoCliente() As Boolean
        Get
            If Session("EditContactoCliente") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditContactoCliente"))
            End If
        End Get
        Set
            Session("EditContactoCliente") = Value
        End Set
    End Property

    Public Property EditarContactosCliente() As Boolean
        Get
            If Session("EditarContactosCliente") Is Nothing Then
                Return Nothing
            Else
                Return CBool(Session("EditarContactosCliente"))
            End If
        End Get
        Set
            Session("EditarContactosCliente") = Value
        End Set
    End Property

    Public Property NombresContactosCliente() As String
        Get
            If Session("NombresContactosCliente") Is Nothing Then
                Return String.Empty
            Else
                Return Session("NombresContactosCliente").ToString()
            End If
        End Get
        Set
            Session("NombresContactosCliente") = Value
        End Set
    End Property

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)

        MaintainScrollPositionOnPostBack = True

        CargarRegimenFiscal()
        CargarPaises()

        If Not IsPostBack Then
            Session("tblContactos") = Nothing
            IdDomicilio = 0
            IdContacto = 0
        End If

        If EditCliente Then
            CargarPagina()
            txtEditarCliente.Text = "True"
            lblTitulo.Text = "Editar cliente"

            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "script", "UpdateResumen('" + NombresContactosCliente + "');", True)
        Else
            lblTitulo.Text = "Nuevo cliente"
        End If
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Shared Function GuardarCliente(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim nombre = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRE").ToList()(0).ParamValue.ToString(), "")
            Dim rfc = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "RFC").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "RFC").ToList()(0).ParamValue.ToString(), "")
            Dim regimendFiscalId = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCALID").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCALID").ToList()(0).ParamValue.ToString(), "")
            Dim regimendFiscal = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCAL").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "REGIMENFISCAL").ToList()(0).ParamValue.ToString(), "")

            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim empresa = New ClienteModel With {
                .EmpresaId = page.EmpresaId,
                .ClienteEmpresaId = page.IdCliente,
                .ClienteEmpresaNombre = nombre,
                .RFC = rfc,
                .RegimenFiscalId = integer.Parse(regimendFiscalId),
                .RegimenFiscal = regimendFiscal,
                .OrganizacionId = loginsession.OrganizacionId
            }

            Dim req = ""
            Dim msjRet = ""
            Dim data = JsonConvert.SerializeObject(empresa)

            If page.EditEmpresa Then
                req = PutRequest("api/Clientes", loginsession.Token, data)
                msjRet = "Información general actualizada"
            Else
                req = PostRequest("api/Clientes", data, loginsession.Token)
                msjRet = "Información general guardada"
            End If

            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Dim detail = result.GetValue("detail").Value(Of JObject)

                If Not page.EditCliente Then
                    Dim cliente = detail.GetValue("ClienteEmpresaId").Value(Of String)
                    page.IdCliente = Convert.ToInt32(cliente)
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
            Dim estadoId = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADOID").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADOID").ToList()(0).ParamValue.ToString(), "")
            Dim estado = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "ESTADO").ToList()(0).ParamValue.ToString(), "")
            Dim paisId = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "PAISID").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "PAISID").ToList()(0).ParamValue.ToString(), "")
            Dim pais = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "PAIS").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "PAIS").ToList()(0).ParamValue.ToString(), "")

            Dim page = New FreedomPage()
            Dim pageDet = New DetalleCliente()
            Dim loginsession = page.UserSession

            Dim domicilio = New ClienteDomicilioModel() With {
                .DomicilioId = page.IdDomicilio,
                .ClienteId = page.IdCliente,
                .Calle = calle,
                .NumeroExterno = numExt,
                .NumeroInterno = numInt,
                .EntreCalles = calles,
                .Colonia = colonia,
                .CP = cp,
                .Municipio = municipio,
                .EstadoId = estadoId,
                .Estado = estado,
                .PaisId = paisId,
                .Pais = pais
            }

            Dim data = JsonConvert.SerializeObject(domicilio)

            Dim req = ""
            Dim msjRet = ""

            If page.EditEmpresa AndAlso pageDet.EditarDomicilioCliente Then
                req = PutRequest("api/DomicilioCliente", loginsession.Token, data)
                msjRet = "Domicilio Fiscal actualizado"
            Else
                req = PostRequest("api/DomicilioCliente", data, loginsession.Token)
                msjRet = "Domicilio Fiscal guardado"
            End If

            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Dim list = New List(Of ClienteDomicilioModel) From {
                        domicilio
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
            Dim telefonoFactura = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "TELEFONOCLIENTE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "TELEFONOCLIENTE").ToList()(0).ParamValue.ToString(), "")
            Dim correoFactura = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CORREOCLIENTE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CORREOCLIENTE").ToList()(0).ParamValue.ToString(), "")
            Dim diasCredito = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "DIASCREDITO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "DIASCREDITO").ToList()(0).ParamValue.ToString(), "")

            Dim pageDet = New DetalleCliente()
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim personalizacion = New ClienteConfiguracionModel() With {
                .ClienteId = page.IdCliente,
                .ConfiguracionId = page.ConfiguracionId,
                .DiasCredito = diasCredito,
                .Telefono = telefonoFactura,
                .CorreoElectronico = correoFactura,
                .OrganizacionId = loginsession.OrganizacionId,
                .EmpresaId = page.EmpresaId
            }

            Dim data = JsonConvert.SerializeObject(personalizacion)

            Dim req = ""
            Dim msjRet = ""

            If page.EditEmpresa AndAlso pageDet.EditarPersonalizacionCliente Then
                req = PutRequest("api/ConfiguracionCliente", loginsession.Token, data)
                msjRet = "Personalización actualizado"
            Else
                req = PostRequest("api/ConfiguracionCliente", data, loginsession.Token)
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
    Public Shared Function GuardarContactos() As ServiceResult
        Try
            If HttpContext.Current.Session("tblContactos") Is Nothing Then
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = "Es necesario agregar al menos un contacto",
                    .Ret = ""
                }
            End If

            Dim pageDet = New DetalleCliente()
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession
            Dim nombresContactos = ""
            Dim contactos = DirectCast(HttpContext.Current.Session("tblContactos"), DataTable)
            Dim msjRet = ""

            For Each row As DataRow In contactos.Rows
                Dim contacto = New ClienteContactoModel() With {
                    .ClienteId = page.IdCliente,
                    .ContactoId = Convert.ToInt32(row("ContactoId")),
                    .Nombre = row("NombreContacto"),
                    .Telefono = row("TelefonoFijo"),
                    .TelefonoMovil = row("TelefonoMovil"),
                    .CorreoElectronico = row("Correo"),
                    .Puesto = row("Puesto"),
                    .TipoContacto = row("TipoContacto"),
                    .OrganizacionId = loginsession.OrganizacionId,
                    .EmpresaId = page.EmpresaId
                }

                nombresContactos += row("NombreContacto") + "<br/>"

                Dim req = ""
                Dim data = JsonConvert.SerializeObject(contacto)

                If page.EditEmpresa AndAlso pageDet.EditarContactosCliente Then
                    req = PutRequest("api/ContactoCliente", loginsession.Token, data)
                    msjRet = "Contactos actualizados"
                Else
                    req = PostRequest("api/ContactoCliente", data, loginsession.Token)
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
        End If
    End Sub

    Public Sub CargarTablaContactos()
        Dim tbl = New DataTable()
        Dim nombreContacto = txtNombreContacto.Text
        Dim tipoContacto = "" 'cbxTipoContacto.Value
        Dim telFijo = txtTelefonoFijo.Text
        Dim telMovil = txtMovil.Text
        Dim correo = txtCorreoContacto.Text
        Dim puesto = txtPuesto.Text

        If EditContactoCliente Then
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

    Public Sub CargarPagina()
        CargarCliente()
        CargarDomicilio()
        CargarPersonalizacion()
        CargarContactos()
    End Sub

    Public Sub CargarCliente()
        Dim url = "api/Clientes?clienteId=" & IdCliente & "&organizacionId=" & UserSession.OrganizacionId & "&empresaId=" & EmpresaId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim cliente As List(Of ClienteModel) = StringToValue(detail.ToString(), GetType(List(Of ClienteModel)))

            If cliente.Count > 0 Then
                txtNombre.Text = cliente(0).ClienteEmpresaNombre
                txtRFC.Text = cliente(0).RFC
                'cbxRegimenFiscal.Items.FindByValue(empresa(0).).Selected = True
            End If
        End If
    End Sub

    Public Sub CargarPersonalizacion()
        Dim url = "api/ConfiguracionCliente?clienteId=" & IdCliente & "&organizacionId=" & UserSession.OrganizacionId & "&empresaId=" & EmpresaId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim personalizacion As List(Of ClienteConfiguracionModel) = StringToValue(detail.ToString(), GetType(List(Of ClienteConfiguracionModel)))

            If personalizacion.Count > 0 Then
                EditarPersonalizacionCliente = True
                txtDiasCredito.Text = If(personalizacion(0).DiasCredito.ToString(), "")
                txtTelefonoPer.Text = If(personalizacion(0).Telefono, "")
                txtCorreoPer.Text = If(personalizacion(0).CorreoElectronico, "")
                ConfiguracionId = personalizacion(0).ConfiguracionId
            Else
                EditarPersonalizacionCliente = False
            End If
        End If
    End Sub

    Public Sub CargarDomicilio()
        Dim url = "api/DomicilioCliente?clienteId=" & IdCliente & "&organizacionId=" & UserSession.OrganizacionId & "&empresaId=" & EmpresaId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim domicilio As List(Of ClienteDomicilioModel) = StringToValue(detail.ToString(), GetType(List(Of ClienteDomicilioModel)))

            If domicilio.Count > 0 Then
                EditarDomicilioCliente = True
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
            Else
                EditarDomicilioCliente = False
            End If
        End If
    End Sub

    Public Sub CargarContactos()
        Dim url = "api/ContactoCliente?clienteId=" & IdCliente
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim contactos As List(Of ClienteContactoModel) = StringToValue(detail.ToString(), GetType(List(Of ClienteContactoModel)))
            Dim tbl = New DataTable()

            If contactos.Count > 0 Then
                EditarContactosCliente = True

                If Session("tblContactos") Is Nothing Then
                    tbl.Columns.Add("ContactoId")
                    tbl.Columns.Add("NombreContacto")
                    tbl.Columns.Add("TipoContacto")
                    tbl.Columns.Add("TelefonoFijo")
                    tbl.Columns.Add("TelefonoMovil")
                    tbl.Columns.Add("Correo")
                    tbl.Columns.Add("Puesto")

                    NombresContactosCliente = ""

                    For Each contacto As ClienteContactoModel In contactos
                        NombresContactosCliente += contacto.Nombre + "<br/>"
                        tbl.Rows.Add(contacto.ContactoId, contacto.Nombre, contacto.TipoContacto, contacto.Telefono, contacto.TelefonoMovil, contacto.CorreoElectronico, contacto.Puesto)
                    Next

                    tbl.AcceptChanges()
                    repContactos.DataSource = tbl
                    repContactos.DataBind()
                    Session("tblContactos") = tbl
                End If
            Else
                EditarContactosCliente = False
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

    Protected Sub btnAgregarContacto_Click(sender As Object, e As EventArgs)
        CargarTablaContactos()
    End Sub

    Protected Sub btnTriggerUpdate_Click(sender As Object, e As EventArgs)
        'CargarEmpresas(UserSession.OrganizacionId)
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
                EditContactoCliente = True
                IdContacto = contactoId
                Exit For
            End If
        Next
    End Sub

    Public Sub EliminarContacto(contactoId As String)
        Try
            Dim tbl = DirectCast(Session("tblContactos"), DataTable)

            If EditEmpresa Then
                Dim contacto = New ClienteContactoModel() With {
                    .ClienteId = IdCliente,
                    .ContactoId = Convert.ToInt32(contactoId)
                }

                Dim data = JsonConvert.SerializeObject(contacto)
                Dim url = "api/ContactoCliente"
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

    Protected Sub repContactos_ItemCreated(sender As Object, e As RepeaterItemEventArgs)
        Dim scriptMan As ScriptManager = ScriptManager.GetCurrent(Me)
        Dim btn As LinkButton = TryCast(e.Item.FindControl("btnEditarContacto"), LinkButton)
        If btn IsNot Nothing Then
            scriptMan.RegisterAsyncPostBackControl(btn)
        End If
    End Sub
End Class