Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class ValidaComprobantesEmitodosEmpresaController
        Inherits FreedomApi

        ''' <summary>
        ''' spValidaComprobantesEmitidosporEmpresa
        ''' </summary>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function ValidaComprobantesEmitidosporEmpresa(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of Integer)
            Try
                Return db.spValidaComprobantesEmitidosporEmpresa(idEmpresa, idOrganizacion)
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function
    End Class
End Namespace