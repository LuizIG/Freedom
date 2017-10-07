Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class UsuarioOrganizacionController
        Inherits FreedomApi


        ''' <summary>
        ''' spALLUsuario_Organizacion
        ''' </summary>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function spALLUsuario_Organizacion(ByVal idOrganizacion As Integer) As IEnumerable(Of spALLUsuario_Organizacion_Result)
            Return db.spALLUsuario_Organizacion(idOrganizacion, GetUserId)
        End Function


        ''' <summary>
        ''' spINSUsuario_Organizacion
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HttpPost>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function InsUsuarioOrganziacion(ByVal model As UsuarioOrganizacionModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                Dim aspNetUser = db.AspNetUsers.Where(Function(x) x.Email = model.email).ToList

                If (aspNetUser.Count = 0) Then
                    Return BadRequest("No existe el usuario: " & model.email)
                End If
                Dim idNewUsuario = aspNetUser(0).Id
                Dim idUsuario As String = GetUserId()

                model.id = db.spINSUsuario_Organizacion(idNewUsuario, IIf(model.soloLectura, 3, 2), model.idOrganizacion, idUsuario)

                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spDELUsuario_Organizacion
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HttpDelete>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function spDELUsuario_Organizacion(ByVal model As DeleteUsuarioOrganizacionModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                Dim aspNetUser = db.AspNetUsers.Where(Function(x) x.Email = model.email).ToList
                If (aspNetUser.Count = 0) Then
                    Return BadRequest("No existe el usuario: " & model.email)
                End If
                Dim idNewUsuario = aspNetUser(0).Id
                db.spDELUsuario_Organizacion(idNewUsuario, model.idOrganizacion)
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
    End Class
End Namespace