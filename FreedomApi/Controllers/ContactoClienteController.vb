Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity
Imports Model

Namespace Controllers
    <Authorize>
    Public Class ContactoClienteController
        Inherits FreedomApi

        '''' <summary>
        '''' spConsContactoCliente_ClienteId
        '''' </summary>
        '''' <param name="clienteId"></param>
        '''' <returns></returns>
        '<HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        '<HttpGet>
        'Public Function GetContactoClienteById(ByVal clienteId As Integer) As IEnumerable(Of spConsContactoCliente_ClienteId_Result)
        '    Try
        '        Return db.spConsContactoCliente_ClienteId(clienteId)
        '    Catch ex As Exception
        '        Return BadRequest(ex.Message)
        '    End Try
        'End Function

        ''' <summary>
        ''' spInsContactoCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsertContactoCliente(ByVal model As ClienteContactoModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    model.ContactoId = db.spInsContactoCliente(.ClienteId, .Nombre, .Telefono, .TelefonoMovil, .CorreoElectronico, .Puesto, .TipoContacto)
                End With
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spUpdContactoCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UpdateContactoCliente(ByVal model As ClienteContactoModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    db.spUpdContactoCliente(.ClienteId, .ContactoId, .Nombre, .Telefono, .TelefonoMovil, .CorreoElectronico, .Puesto, .TipoContacto)
                End With
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spDelContactoCliente
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpDelete>
        Public Function DeleteContactoCliente(ByVal model As ClienteContactoModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    model.ClienteId = db.spDelContactoCliente(.ClienteId, .ContactoId)

                    If (model.ClienteId = 0) Then
                        Return BadRequest()
                    End If
                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
    End Class
End Namespace