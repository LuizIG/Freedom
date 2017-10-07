Imports System.Data.Entity.Core.Objects
Imports System.Data.SqlClient
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class OrganizacionController
        Inherits FreedomApi
        ''' <summary>
        ''' spConsOrganizacion
        ''' </summary>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetOrganizacion() As IEnumerable(Of spConsOrganizacion_Result)

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim idUsuario As String = GetUserId()

            Try
                Return db.spConsOrganizacion(idUsuario)
            Catch ex As Exception
                Return BadRequest()
            End Try

            Return Ok()
        End Function

        ''' <summary>
        ''' spInsOrganizacion
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertOrganizacion(ByVal model As OrganizacionModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Dim idUsuario As String = GetUserId()
            Try
                Dim response = db.spInsOrganizacion(model.NombreOrganizacion, idUsuario)
                model.id = response.ToList(0).Id

                Try
                    db.spINSUsuario_Organizacion(idUsuario, 1, model.id, idUsuario)
                Catch ex As Exception

                End Try

                Return Ok(model)
            Catch ex As Exception
                MsgBox(ex.StackTrace)
                Return BadRequest(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' spUpdOrganizacion
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function InsertOrganizacion(ByVal model As OrganizacionUpdateModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim idUsuario As String = GetUserId()

            Try

                Dim x = db.spUpdOrganizacion(model.organizacionId, idUsuario, model.NombreOrganizacion, model.activoFlg)

                Return Ok(x)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function


    End Class
End Namespace