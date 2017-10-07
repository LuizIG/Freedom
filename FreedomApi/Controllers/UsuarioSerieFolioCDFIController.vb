Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class UsuarioSerieFolioCDFIController
        Inherits FreedomApi

        ''' <summary>
        ''' spSelUsuarioSerieFolio_CFDI
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HttpGet>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function selUsuarioSerieFolio(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of spSelUsuarioSerieFolio_CFDI_Result)
            Try
                Return db.spSelUsuarioSerieFolio_CFDI(GetUserId, idEmpresa, idOrganizacion)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spInsUsuarioSerieFolio_CFDI
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HttpPost>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function insUsuariosSerieFolioCFDI(ByVal model As UsuariosSerieFolioCFDIModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                model.id = db.spInsUsuarioSerieFolio_CFDI(GetUserId, model.idEmpresa, model.serie, model.folioInicial, model.tipoComprobante, model.idOrganizacion)
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spDelUsuarioSerieFolio_CFDI
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HttpDelete>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        Public Function detUsuariosSerieFolioCFDI(ByVal model As DelUsuariosSerieFolioCFDIModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                db.spDelUsuarioSerieFolio_CFDI(GetUserId, model.idEmpresa, model.idOrganizacion)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


    End Class
End Namespace