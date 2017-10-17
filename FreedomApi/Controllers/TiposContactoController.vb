Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class TiposContactoController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsTipoContactoCliente
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function GetTiposContacto() As IEnumerable(Of spConsTipoContactoCliente_Result)
            Try
                Return db.spConsTipoContactoCliente()
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function
    End Class
End Namespace