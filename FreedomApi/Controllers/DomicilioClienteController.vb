Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity
Imports Model

Namespace Controllers
    <Authorize>
    Public Class DomicilioClienteController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsDomicilioCliente_ClienteId
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <param name="organizacionId"></param>
        ''' <param name="empresaId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetDomicilioClienteById(ByVal clienteId As Integer, ByVal organizacionId As Integer, ByVal empresaId As Integer) As IEnumerable(Of spConsDomicilioCliente_ClienteId_Result)
            Return db.spConsDomicilioCliente_ClienteId(clienteId, organizacionId, empresaId)
        End Function

        ''' <summary>
        ''' spInsDomicilioCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertDomicilioCliente(ByVal model As ClienteDomicilioModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                With model
                    db.spInsDomicilioCliente(.ClienteId, .Calle, .NumeroExterno,
                                             .NumeroInterno, .Colonia,
                                             .CP, .Municipio, .EstadoId)
                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spUpdDomicilioCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdateDomicilioCliente(ByVal model As ClienteDomicilioModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    db.spUpdDomicilioCliente(.DomicilioId, .ClienteId, .Calle, .NumeroExterno,
                                             .NumeroInterno, .Colonia,
                                             .CP, .Municipio, .EstadoId)
                    Return Ok()
                End With
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
    End Class
End Namespace