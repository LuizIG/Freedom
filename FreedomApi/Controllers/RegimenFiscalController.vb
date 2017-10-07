Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class RegimenFiscalController
        Inherits FreedomApi

        ''' <summary>
        ''' spAllRegimenFiscal
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getRegimenFiscal() As IEnumerable(Of spAllRegimenFiscal_Result)
            Try
                Return db.spAllRegimenFiscal()
            Catch ex As Exception
                Return BadRequest()
            End Try

        End Function

    End Class
End Namespace