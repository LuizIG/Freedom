Imports Model
Imports Newtonsoft.Json.Linq

Public Class Usuarios
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)

    End Sub

    Public Sub CargarUsuarios(IdOrganizacion As Integer)
        Dim req = GetRequest("api/UsuarioOrganizacion?idOrganizacion=" & IdOrganizacion, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim usuarios As List(Of UsuarioOrganizacion) = StringToValue(detail.ToString(), GetType(List(Of UsuarioOrganizacion)))

            repUsuarios.DataSource = usuarios
            repUsuarios.DataBind()
        Else

        End If
    End Sub
End Class