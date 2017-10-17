Imports System.Web.Services
Imports Model
Imports Newtonsoft.Json.Linq

Public Class Clientes
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Page_Load(sender, e)


        'Dim combo = DirectCast(LoadControl("~/UserControls/ComboEmpresas.ascx"), ComboEmpresas)
        'Me.Controls.Add(combo)

        'If Not IsPostBack Then
        '    combo.CargarEmpresas(UserSession.OrganizacionId)
        'End If

        'combo.cbxEmpresa_ServerChange(combo, Nothing)


        CargarClientes(UserSession.OrganizacionId)
    End Sub

    Public Sub CargarClientes(IdOrganizacion As Integer)
        Dim url = "api/Clientes?idOrganizacion=" & IdOrganizacion & "&idEmpresa=" & EmpresaId
        Dim req = GetRequest(url, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim clientes As List(Of ClienteModel) = StringToValue(detail.ToString(), GetType(List(Of ClienteModel)))

            repClientes.DataSource = clientes.OrderBy(Function(x) x.ClienteEmpresaId)
            repClientes.DataBind()
        End If
    End Sub

    Protected Sub btnEditarCliente_Click(sender As Object, e As CommandEventArgs)
        Dim page = New FreedomPage()
        Dim clienteId = e.CommandArgument
        page.EditCliente = True
        page.IdCliente = CInt(clienteId)
        Response.Redirect("DetalleCliente.aspx")
    End Sub

    Protected Sub btnNuevoCliente_Click(sender As Object, e As EventArgs)
        EditCliente = False
        Response.Redirect("DetalleCliente.aspx")
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Shared Function EliminarCliente(clienteId As String) As ServiceResult
        Try
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim url = "api/Clientes?clienteId=" & Convert.ToInt32(clienteId) & "&idOrganizacion=" & loginsession.OrganizacionId
            Dim req = DeleteRequest(url, loginsession.Token)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "Cliente eliminado",
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
End Class