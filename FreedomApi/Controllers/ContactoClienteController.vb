Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity
Imports Model

Namespace Controllers
    <Authorize>
    Public Class ContactoClienteController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsContactoCliente_ClienteId
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetContactoClienteById(ByVal clienteId As Integer) As IEnumerable(Of spConsContactoCliente_ClienteId_Result)
            Try
                Return db.spConsContactoCliente_ClienteId(clienteId)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

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
                    Dim response = db.spInsContactoCliente(.ClienteId, .Nombre, .TelefonoFijo, .TelefonoMovil, .CorreoElectronico, .Puesto, .TipoContactoClienteId)
                    Dim contacto As New ClienteContactoModel
                    contacto.ContactoId = response.ToList(0).id
                    Return Ok(contacto)
                End With

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
                    db.spUpdContactoCliente(.ClienteId, .ContactoId, .Nombre, .TelefonoFijo, .TelefonoMovil, .CorreoElectronico, .Puesto, .TipoContactoClienteId)
                End With
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spDelContactoCliente
        ''' </summary>
        ''' <param name="clienteId"></param>
        ''' <param name="contactoId"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpDelete>
        Public Function DeleteContactoCliente(ByVal clienteId As Integer, ByVal contactoId As Integer) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                'With Model
                '    Model.ContactoId = db.spDelContactoCliente(.ClienteId, .ContactoId)

                '    If (Model.ContactoId = 0) Then
                '        Return BadRequest()
                '    End If
                'End With
                contactoId = db.spDelContactoCliente(clienteId, contactoId)

                If (contactoId = 0) Then
                    Return BadRequest()
                End If
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
    End Class
End Namespace