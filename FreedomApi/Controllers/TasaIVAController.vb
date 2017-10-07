Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class TasaIVAController
        Inherits FreedomApi
        ''' <summary>
        ''' spAllTasaIVA
        ''' </summary>
        ''' <param name="active">Parametro opcional true por default</param>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getAllTasaIva(Optional active As Boolean = True) As IEnumerable(Of spAllTasaIVA_Result)
            Try
                Return db.spAllTasaIVA(active)
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function

    End Class
End Namespace