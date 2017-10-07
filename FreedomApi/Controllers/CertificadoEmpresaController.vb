Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class CertificadoEmpresaController
        Inherits FreedomApi


        ''' <summary>
        ''' spInsCertificadoEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function insCertificadoEmpresa(ByVal model As CertificadoEmpresa) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                Dim newBytes() As Byte = Convert.FromBase64String(model.certificado)

                With model
                    db.spInsCertificadoEmpresa(.idEmpresa, Convert.FromBase64String(.certificado), Convert.FromBase64String(.llavePrivada), .llavePublica, .idOrganizacion)
                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spConsCertificadoEmpresa_EmpresaId
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function getCertificadoEmpresa(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IHttpActionResult
            Return db.spConsCertificadoEmpresa_EmpresaId(idEmpresa, idOrganizacion, GetUserId)
        End Function


    End Class
End Namespace