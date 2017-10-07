Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class TipoComprobanteEsquemaFiscalController
        Inherits FreedomApi
        ''' <summary>
        ''' spAllTipoComprobante_EsquemaFiscal
        ''' </summary>
        ''' <param name="esquemafiscal">CFD,CBB,CFDI</param>
        ''' <returns></returns>
        '''
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function getConsTipoImpuesto(ByVal esquemafiscal As String) As IEnumerable(Of spAllTipoComprobante_EsquemaFiscal_Result)
            Try
                If esquemafiscal <> "CFD" And esquemafiscal <> "CBB" And esquemafiscal <> "CFDI" Then
                    Return BadRequest("El esquema fiscal no es válido")
                End If
                Return db.spAllTipoComprobante_EsquemaFiscal(esquemafiscal)
            Catch ex As Exception
                Return BadRequest()
            End Try
        End Function
    End Class
End Namespace