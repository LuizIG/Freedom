Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Models

    <Authorize>
    Public Class PaisesController
        Inherits FreedomApi

        ''' <summary>
        ''' spSELPaises
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getPaises() As IEnumerable(Of spSELPaises_Result)
            Try
                Return db.spSELPaises()
            Catch ex As Exception
                Return BadRequest()
            End Try

        End Function

    End Class
End Namespace