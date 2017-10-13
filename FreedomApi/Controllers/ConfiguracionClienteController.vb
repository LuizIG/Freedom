Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity
Imports Model

Namespace Controllers
    <Authorize>
    Public Class ConfiguracionClienteController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsConfiguracionCliente_ClienteId
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetConfiguracionClienteById(ByVal clienteId As Integer, ByVal organizacionId As Integer, ByVal empresaId As Integer) As IEnumerable(Of spConsConfiguracionCliente_ClienteId_Result)
            Try
                Return db.spConsConfiguracionCliente_ClienteId(clienteId, organizacionId, empresaId)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spInsConfiguracionCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertConfiguracionCliente(ByVal model As ClienteConfiguracionModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    db.spInsConfiguracionCliente(.ClienteId, 1, .Telefono, .CorreoElectronico, .DiasCredito)
                    Return Ok()
                End With
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spUpdConfiguracionCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdateConfiguracionCliente(ByVal model As ClienteConfiguracionModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    db.spUpdConfiguracionCliente(.ClienteId, 1, .Telefono, .CorreoElectronico, .DiasCredito, .OrganizacionId, .EmpresaId)
                    Return Ok()
                End With
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
    End Class
End Namespace