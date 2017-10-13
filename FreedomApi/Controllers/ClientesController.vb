Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity
Imports Model

Namespace Controllers
    '<Authorize>
    Public Class ClientesController
        Inherits FreedomApi

        ''' <summary>
        ''' spAllCliente
        ''' </summary>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetClientes(ByVal idOrganizacion As Integer, ByVal idEmpresa As Integer) As IEnumerable(Of spAllCliente_Result)
            Try
                Return db.spAllCliente(idOrganizacion, idEmpresa)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spConsCliente_ClienteId
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <param name="organizacionId"></param>
        ''' <param name="empresaId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetClienteById(ByVal clienteId As Integer, ByVal organizacionId As Integer, ByVal empresaId As Integer) As IEnumerable(Of spConsCliente_ClienteId_Result)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Return db.spConsCliente_ClienteId(clienteId, organizacionId, empresaId)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spInsCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertCliente(ByVal model As ClienteModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                Dim response = db.spInsCliente(model.ClienteEmpresaNombre, model.RFC, model.RegimenFiscalId, model.OrganizacionId, model.EmpresaId)

                Dim cliente As New ClienteModel
                cliente.ClienteEmpresaId = response.ToList(0).id
                Return Ok(cliente)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spUpdCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdateCliente(ByVal model As ClienteModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    db.spUpdCliente(.ClienteEmpresaId, .ClienteEmpresaNombre, .RFC, .RegimenFiscalId, .OrganizacionId, .EmpresaId)
                    Return Ok()
                End With
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
    End Class
End Namespace