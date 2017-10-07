Imports System.Data.SqlClient
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers

    <Authorize>
    Public Class EmpresasController
        Inherits FreedomApi

        ''' <summary>
        ''' spInsEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertEmpresa(ByVal model As EmpresasModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Dim idUsuario As String = GetUserId()

            Try
                Dim response = db.spInsEmpresa(model.NombreEmpresa, model.RFC, model.RegimenFiscalId, model.ActivoFlg, model.DefaultFlg, model.CURP, model.OrganizacionId, idUsuario)

                Dim empresa As New EmpresasModelResult
                empresa.Id = response.ToList(0).Id
                empresa.NombreEmpresa = model.NombreEmpresa
                empresa.RFC = model.RFC
                empresa.RegimenFiscalId = model.RegimenFiscalId
                empresa.ActivoFlg = model.ActivoFlg
                empresa.DefaultFlg = model.DefaultFlg
                empresa.CURP = model.CURP
                empresa.OrganizacionId = model.OrganizacionId

                Try
                    db.spINSUsuario_Empresa(idUsuario, empresa.Id, empresa.OrganizacionId, 1)
                Catch ex As Exception

                End Try

                Return Ok(empresa)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' spUpdActivoFlgEmpresa_EmpresaId
        ''' </summary>
        ''' <param name="model"></param>
        ''' <param name="active"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdActivoFlag(ByVal model As EmpresasActivoModel, ByVal active As Boolean) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Dim x = db.spUpdActivoFlgEmpresa_EmpresaId(model.IdEmpresa, active, model.IdOrganizacion)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function
        ''' <summary>
        ''' spConsEmpresa_EmpresaId
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetEmpresa(ByVal id As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of spConsEmpresa_EmpresaId_Result)

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Return db.spConsEmpresa_EmpresaId(id, idOrganizacion)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' spConsEmpresa_RegimenFiscal
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetEmpresaRegimenFiscal(ByVal id As Integer) As IEnumerable(Of spConsEmpresa_RegimenFiscal_Result)

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Return db.spConsEmpresa_RegimenFiscal(id)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' spConsEmpresa_EmpresaDefault
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetEmpresaDefaul(ByVal idEmpresa As Integer) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Dim idUsuario As String = GetUserId()

                Return db.spConsEmpresa_EmpresaDefault(idUsuario, idEmpresa)

            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' spAllEmpresa
        ''' </summary>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetAllEmpresa(ByVal idOrganizacion As Integer) As IEnumerable(Of spAllEmpresa_Result)
            Return db.spAllEmpresa(idOrganizacion)
        End Function

        ''' <summary>
        ''' spSELEmpresa
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetSelEmprsa(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of spAllEmpresa_Result)
            Return db.spSELEmpresa(idEmpresa, idOrganizacion)
        End Function


        ''' <summary>
        ''' spDelEmpresa
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpDelete>
        Public Function GetAllEmpresa(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Dim idUsuario As String = GetUserId()
                db.spDelEmpresa(idEmpresa, idOrganizacion, idUsuario)
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function



        ''' <summary>
        ''' spUpdEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdateEmpresa(ByVal model As EmpresasUpdateModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Dim idUsuario As String = GetUserId()

                With model
                    db.spUpdEmpresa(.IdEmpresa, .NombreEmpresa, .RFC, .RegimenFiscalId,
                                    .ActivoFlg, .DefaultFlg, .CURP, .OrganizacionId, idUsuario)
                    Return Ok()
                End With
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function



    End Class
End Namespace