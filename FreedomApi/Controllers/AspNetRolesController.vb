Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Controllers
    <Authorize>
    <RoutePrefix("api/Roles")>
    Public Class RolesController
        Inherits ApiController

        ''' <summary>
        ''' Alta de nuevo rol
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Async Function AddRole(model As RoleAddBindingModel) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim RoleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)())
            Dim roleresult = Await RoleManager.CreateAsync(New IdentityRole(model.Name))

            If Not roleresult.Succeeded Then
                Return GetErrorResult(roleresult)
            End If

            Return Ok()
        End Function

        ''' <summary>
        ''' Obtiene una lista de los roles
        ''' </summary>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        <ResponseType(GetType(List(Of RoleViewModel)))>
        Public Function getRoles() As List(Of RoleViewModel)
            Dim RoleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)())
            Dim roleresult = RoleManager.Roles.ToList()

            Dim resutl As New List(Of RoleViewModel)
            For Each identiyRole In roleresult
                Dim role As New RoleViewModel With {
                    .Id = identiyRole.Id,
                    .Name = identiyRole.Name
                }
                resutl.Add(role)
            Next
            Return resutl
        End Function


        ''' <summary>
        ''' Obtiene rol por id
        ''' </summary>
        ''' <param name="id">Id del rol</param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        <ResponseType(GetType(RoleViewModel))>
        Public Async Function getRole(ByVal id As String) As Task(Of IHttpActionResult)
            Dim RoleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)())
            Dim roleresult = Await RoleManager.FindByIdAsync(id)

            If roleresult IsNot Nothing Then
                Dim role As New RoleViewModel With {
                    .Id = roleresult.Id,
                    .Name = roleresult.Name
                }
                Return Ok(role)
            End If

            ModelState.AddModelError("error", "El rol no existe")
            Return BadRequest(ModelState)
        End Function


        Private Function GetErrorResult(result As IdentityResult) As IHttpActionResult
            If result Is Nothing Then
                Return InternalServerError()
            End If
            If Not result.Succeeded Then
                If result.Errors IsNot Nothing Then
                    For Each [error] As String In result.Errors
                        ModelState.AddModelError("", [error])
                    Next
                End If
                If ModelState.IsValid Then
                    ' No hay disponibles errores ModelState para enviar, por lo que simplemente devuelva un BadRequest vacío.
                    Return BadRequest()
                End If
                Return BadRequest(ModelState)
            End If
            Return Nothing
        End Function
    End Class
End Namespace