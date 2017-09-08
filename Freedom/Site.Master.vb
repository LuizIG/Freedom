Imports System.Web.Script.Serialization
Imports Newtonsoft.Json.Linq

Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CargarEmpresas(1)
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

    Public Sub CargarEmpresas(IdOrganizacion As Integer)
        'Dim req = GetRequest("api/Empresas?idOrganizacion=" & IdOrganizacion, UserSession.Token)
        'Dim result = JObject.Parse(req)
        'Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        'If (statusCode >= 200 And statusCode < 400) Then
        '    Dim detail = result.GetValue("detail").Value(Of JArray)
        '    Dim empresas As List(Of Model.Empresa) = StringToValue(detail.ToString(), GetType(List(Of Model.Empresa)))

        '    repListaEmpresas.DataSource = empresas
        '    repListaEmpresas.DataBind()
        'Else

        'End If
        Dim empresas = New List(Of Model.Empresa)

        Dim emp1 = New Model.Empresa With {
            .NombreEmpresa = "General Motors",
            .RFC = "AHSN871921FG4"
        }

        Dim emp2 = New Model.Empresa With {
            .NombreEmpresa = "Grainger",
            .RFC = "AFIO871209JK8"
        }

        Dim emp3 = New Model.Empresa With {
            .NombreEmpresa = "Zwan",
            .RFC = "PJK18614OP7"
        }

        Dim emp4 = New Model.Empresa With {
            .NombreEmpresa = "",
            .RFC = "GUTH890526OI3"
        }

        empresas.Add(emp1)
        empresas.Add(emp2)
        empresas.Add(emp3)
        empresas.Add(emp4)

        repListaEmpresas.DataSource = empresas
        repListaEmpresas.DataBind()
    End Sub

    Public Shared Function StringToValue(value As String, type As Type) As Object
        Dim jss = New JavaScriptSerializer()
        Dim result As Object = jss.Deserialize(value, type)
        Return result
    End Function
End Class