Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class UsuarioEmpresaController
        Inherits FreedomApi

        '''' <summary>
        '''' spSELUsario_Empresa
        '''' </summary>
        '''' <param name="idOrganizacion">Id Organizacion</param>
        '''' <param name="idEmpresa">Id Empresa</param>
        '''' <returns></returns>
        '<HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        '<HttpGet>
        'Public Function getUsuarioEmpresa(ByVal idOrganizacion As Integer, ByVal idEmpresa As Integer) As IEnumerable(Of spSELUsario_Empresa_Result)
        '    Return db.spSELUsario_Empresa(GetUserId, idOrganizacion, idEmpresa)
        'End Function


        '''' <summary>
        '''' spConUsuario_Empresa
        '''' Obtiene las empresas por usuario
        '''' </summary>
        '''' <param name="idOrganizacion"></param>
        '''' <param name="idEmpresa"></param>
        '''' <returns></returns>
        '<HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        '<HttpGet>
        'Public Function spConUsuario_Empresa(ByVal idOrganizacion As Integer, ByVal idEmpresa As Integer, ByVal usuario As String) As IEnumerable(Of spConUsuario_Empresa_Result)
        '    Return db.spConUsuario_Empresa(idOrganizacion, idEmpresa, usuario)
        'End Function



        ''' <summary>
        ''' spConEmpresasUsuario
        ''' Obtiene las empresas por usuario
        ''' </summary>
        ''' <param name="idOrganizacion"></param>
        ''' <param name="usuario"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function spConEmpresasUsuario(ByVal idOrganizacion As Integer, ByVal usuario As String) As IEnumerable(Of spConEmpresasUsuario_Result)
            Return db.spConEmpresasUsuario(idOrganizacion, usuario)
        End Function

        ''' <summary>
        ''' spALLUsuario_Empresa
        ''' Obtiene los usuarios por empresa
        ''' </summary>
        ''' <param name="idOrganizacion"></param>
        ''' <param name="idEmpresa"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function spALLUsuario_Empresa(ByVal idOrganizacion As Integer, ByVal idEmpresa As Integer) As IEnumerable(Of spALLUsuario_Empresa_Result)
            Return db.spALLUsuario_Empresa(idOrganizacion, idEmpresa)
        End Function



        ''' <summary>
        ''' spINSUsuario_Empresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function spINSUsuario_Empresa(ByVal model As PermisoUsarioEmpresa) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Dim idUsuario As String = GetUserId()
            Try
                db.spINSUsuario_Empresa(model.idUsuario, model.idEmpresa, model.idOrganizacion, model.idPermiso)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spDELUsuario_Empresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpDelete>
        Public Function spDELUsuario_Empresa(ByVal model As DeletePermisoUsarioEmpresa) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Dim idUsuario As String = GetUserId()
            Try
                db.spDELUsuario_Empresa(GetUserId, model.idEmpresa, model.idOrganizacion)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

    End Class
End Namespace