Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class EsquemaFiscalController
        Inherits FreedomApi
        ''' <summary>
        ''' spAllEsquemaFiscal
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getAllEsquemaFiscal() As IEnumerable(Of String)
            Try
                Return db.spAllEsquemaFiscal()
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function

    End Class
End Namespace