Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize>
    Public Class ConfiguracionCorreoController
        Inherits FreedomApi

        '''' <summary>
        '''' spConsConfiguracionCliente_ClienteId
        '''' </summary>
        '''' <returns></returns>
        '<HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        '<HttpGet>
        'Public Function getConsConfiguracionCorreo_EmpresaId() As IEnumerable(Of spConsConfiguracionCliente_ClienteId_Result)
        '    Try
        '        Return db.spConsConfiguracionCliente_ClienteId(GetUserId)
        '    Catch ex As Exception
        '        Return BadRequest(ex.Message)
        '    End Try
        'End Function


        ''' <summary>
        ''' spConsConfiguracionCorreo_EmpresaId
        ''' </summary>
        ''' <param name="idEmpresa"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function getConsConfiguracionCorreo_EmpresaId(ByVal idEmpresa As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of spConsConfiguracionCorreo_EmpresaId_Result)
            Try
                Return db.spConsConfiguracionCorreo_EmpresaId(idEmpresa, idOrganizacion)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' spInsConfiguracionCorreo
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function insConfiguracionCorreo(ByVal model As ConfiguracionCorreoModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                With model
                    db.spInsConfiguracionCorreo(.idEmpresa, .servidor, .puerto, .cuenta, .contrasena, .ssl, .active)
                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' spUpdConfiguracionCorreo
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function updConfiguracionCorreo(ByVal model As ConfiguracionCorreoUpdModel) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                With model
                    db.spUpdConfiguracionCorreo(.idEmpresa, .servidor, .puerto, .cuenta, .contrasena, .ssl, .active, .idOrganizacion)
                End With
                Return Ok()
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

    End Class
End Namespace