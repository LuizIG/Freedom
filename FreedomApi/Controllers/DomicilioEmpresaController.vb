Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class DomicilioEmpresaController
        Inherits FreedomApi


        ''' <summary>
        ''' spInsDomicilioEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertOrganizacion(ByVal model As DomicilioEmpresasModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                With model
                    db.spInsDomicilioEmpresa(.IdEmpresa, .calle, .numeroExterno,
                                             .numeroInterno, .entreCalles, .colonia,
                                             .cp, .municipio, .estadoId, .fiscalFlg,
                                             .activoFlg, .emisionFlg)
                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' spUpdDomicilioEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdateDomicilioEmpresa(ByVal model As DomicilioEmpresasUpdateModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try

                With model
                    db.spUpdDomicilioEmpresa(.IdEmpresa, .IdDomicilio, .calle, .numeroExterno,
                                             .numeroInterno, .entreCalles, .colonia,
                                             .cp, .municipio, .estadoId, .fiscalFlg,
                                             .activoFlg, .emisionFlg)
                    Return Ok()
                End With
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function


        ''' <summary>
        ''' spConsDomicilioEmpresa_EmpresaId
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function UpdateDomicilioEmpresa(ByVal idEmpresa As Integer) As IEnumerable(Of spConsDomicilioEmpresa_EmpresaId_Result)
            Return db.spConsDomicilioEmpresa_EmpresaId(idEmpresa)
        End Function
    End Class
End Namespace