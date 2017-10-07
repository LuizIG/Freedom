Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Models

    <Authorize>
    Public Class EstadosController
        Inherits FreedomApi
        ''' <summary>
        ''' spSELEstados
        ''' </summary>
        ''' <param name="idPais"></param>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getPaises(ByVal idPais As Integer) As IEnumerable(Of spSELEstados_Result)
            Try
                Return db.spSELEstados(idPais)
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function

    End Class
End Namespace