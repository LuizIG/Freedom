Imports System.Web.Script.Serialization
Imports Model
Imports Newtonsoft.Json.Linq

Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
End Class