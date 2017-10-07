Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class ConfiguracionImpuestoController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsConfiguracionImpuesto
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idTipoComprobante"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function getConfiguracionImpuesto(ByVal idEmpresa As Integer, ByVal idTipoComprobante As Integer) As IEnumerable(Of spConsConfiguracionImpuesto_Result)
            Try
                Return db.spConsConfiguracionImpuesto(idEmpresa, idTipoComprobante)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spDelConfiguracionImpuesto
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idTipoComprobante"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpDelete>
        Public Function delConfiguracionImpuesto(ByVal idEmpresa As Integer, ByVal idTipoComprobante As Integer) As IHttpActionResult
            Try
                db.spDelConfiguracionImpuesto(idEmpresa, idTipoComprobante)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spInsConfiguracionImpuesto
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function insConfiguracionImpuesto(ByVal model As ConfiguracionImpuestoModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                db.spInsConfiguracionImpuesto(model.idEmpresa, model.idTipoComprobante, model.idTipoComprobante)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

    End Class
End Namespace