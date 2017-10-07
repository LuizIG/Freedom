Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class TipoImpuestoController
        Inherits FreedomApi
        ''' <summary>
        ''' spConsTipoImpuesto
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getConsTipoImpuesto() As IEnumerable(Of spConsTipoImpuesto_Result)
            Try
                Return db.spConsTipoImpuesto()
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function
    End Class
End Namespace