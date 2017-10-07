Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class ContactoEmpresaController
        Inherits FreedomApi

        ''' <summary>
        ''' spConsContactoEmpresa_EmpresaId
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function getContactoEmpresa(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of spConsContactoEmpresa_EmpresaId_Result)
            Try
                Return db.spConsContactoEmpresa_EmpresaId(idEmpresa, idOrganizacion)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spInsContactoEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function insContactoEmpresa(ByVal model As ContactoEmpresaModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                With model
                    model.id = db.spInsContactoEmpresa(.idEmpresa, .nombre, .telefono, .telefonoMovil, .correoElectronico, .puesto, .tipoContacto)
                End With
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spDelContactoEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpDelete>
        Public Function delContactoEmpresa(ByVal model As ContactoDelEmpresaModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    model.id = db.spDelContactoEmpresa(.idEmpresa, .id, .idOrganizacion)

                    If (model.id = 0) Then
                        Return BadRequest()
                    End If

                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function


        ''' <summary>
        ''' spUpdContactoEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function updContactoEmpresa(ByVal model As ContactoEmpresaModel) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Try
                With model
                    db.spUpdContactoEmpresa(.idEmpresa, .id, .nombre, .telefono, .telefonoMovil, .correoElectronico, .puesto, .tipoContacto)
                End With
                Return Ok(model)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function

    End Class
End Namespace