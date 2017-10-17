Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class MetodoPagoClienteController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsClienteMetodoPago
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetMetodosPagoByClienteId(ByVal clienteId As Integer) As IEnumerable(Of spConsClienteMetodoPago_Result)
            Try
                Return db.spConsClienteMetodoPago(clienteId)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        '''' <summary>
        '''' spInsClienteMetodoPago
        '''' </summary>
        '''' <param name="clienteId"></param>
        '''' <returns></returns>
        '<HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        '<HttpGet>
        'Public Function InsertClienteMetodoPago(ByVal clienteId As Integer) As IEnumerable(Of spConsClienteMetodoPago_Result)
        '    Try
        '        Return db.spInsClienteMetodoPago(clienteId)
        '    Catch ex As Exception
        '        Return BadRequest(ex.Message)
        '    End Try
        'End Function
    End Class
End Namespace