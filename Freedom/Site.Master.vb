Imports System.Web.Script.Serialization
Imports Model
Imports Newtonsoft.Json.Linq

Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'Dim page = New FreedomPage()
        'Dim loginsession = page.UserSession
        'CargarEmpresas(loginSession.OrganizacionId)
    End Sub

    Protected Sub btnLogout_ServerClick(sender As Object, e As EventArgs)
        'Dim loginSession = DirectCast(HttpContext.Current.Session("LoginSession"), LoginInfo)
        'Dim req = PostRequest("api/Account/Logout", String.Empty, loginSession.Token)
        'Dim result = JObject.Parse(req)
        'Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        'If (statusCode >= 200 And statusCode < 400) Then
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
        'Else
        '    Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
        'End If
    End Sub

    'Public Sub CargarEmpresas(IdOrganizacion As Integer)
    '    Dim page = New FreedomPage()
    '    Dim loginsession = page.UserSession
    '    Dim req = GetRequest("api/Empresas?idOrganizacion=" & IdOrganizacion, loginSession.Token)
    '    Dim result = JObject.Parse(req)
    '    Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

    '    If (statusCode >= 200 And statusCode < 400) Then
    '        Dim detail = result.GetValue("detail").Value(Of JArray)
    '        Dim empresas As List(Of Model.Empresa) = StringToValue(detail.ToString(), GetType(List(Of Model.Empresa)))

    '        cbxEmpresa.DataSource = empresas.OrderByDescending(Function(x) x.EmpresaDefault).ThenBy(Function(x) x.IdEmpresa)
    '        cbxEmpresa.DataValueField = "IdEmpresa"
    '        cbxEmpresa.DataTextField = "NombreEmpresa"
    '        cbxEmpresa.DataBind()
    '    End If
    'End Sub

    'Public Shared Function StringToValue(value As String, type As Type) As Object
    '    Dim jss = New JavaScriptSerializer()
    '    Dim result As Object = jss.Deserialize(value, type)
    '    Return result
    'End Function
End Class