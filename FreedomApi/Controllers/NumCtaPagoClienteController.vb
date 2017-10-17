Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class NumCtaPagoClienteController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsClienteNumCtaPago
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetNumCtaPagoByClienteId(ByVal clienteId As Integer) As IEnumerable(Of spConsClienteNumCtaPago_Result)
            Try
                Return db.spConsClienteNumCtaPago(clienteId)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        '''' <summary>
        '''' spInsClienteNumCtaPago
        '''' </summary>
        '''' <param name="clienteId"></param>
        '''' <returns></returns>
        '<HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        '<HttpGet>
        'Public Function InsertClienteMetodoPago(ByVal clienteId As Integer) As IEnumerable(Of spConsClienteMetodoPago_Result)
        '    Try
        '        Return db.spInsClienteNumCtaPago(clienteId)
        '    Catch ex As Exception
        '        Return BadRequest(ex.Message)
        '    End Try
        'End Function
    End Class
End Namespace