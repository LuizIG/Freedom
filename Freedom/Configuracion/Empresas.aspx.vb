Imports System.Web.Services
Imports Model
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Empresa
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Page_Load(sender, e)
        SelectMenuItem("menu_span_configuracion")
        SelectMenuItem("menu_span_configuracion_sistema")
        SelectMenuItem("menu_span_configuracion_sistema_empresa")

        If Not IsPostBack Then
            CargarEmpresas(UserSession.OrganizacionId)
        End If
    End Sub

    Public Sub CargarEmpresas(IdOrganizacion As Integer)
        Dim req = GetRequest("api/Empresas?idOrganizacion=" & IdOrganizacion, UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim empresas As List(Of Model.Empresa) = StringToValue(detail.ToString(), GetType(List(Of Model.Empresa)))

            repEmpresas.DataSource = empresas
            repEmpresas.DataBind()
        Else

        End If
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Shared Function EliminarEmpresa(empresaId As String) As ServiceResult
        Try
            Dim page = New FreedomPage()
            Dim loginsession = page.UserSession

            Dim url = "api/Empresas?idEmpresa=" & Convert.ToInt32(empresaId) & "&idOrganizacion=" & loginsession.OrganizacionId
            Dim req = DeleteRequest(url, loginsession.Token)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then

                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "Empresa eliminada",
                    .Ret = ""
                }
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = errorMessage,
                    .Ret = ""
                }
            End If
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function EditarEmpresa(empresaId As String) As ServiceResult
        Try
            Dim page = New FreedomPage()
            page.EditEmpresa = True
            page.EmpresaId = CInt(empresaId)

            Return New ServiceResult() With {
                .Result = True,
                .Message = "",
                .Ret = ""
            }
        Catch ex As Exception
            Return New ServiceResult() With {
                .Result = False,
                .Message = ex.Message,
                .Ret = ""
            }
        End Try
    End Function

    Protected Sub btnNuevaEmpresa_Click(sender As Object, e As EventArgs)
        EditEmpresa = False
        Response.Redirect("DetalleEmpresa.aspx")
    End Sub
End Class