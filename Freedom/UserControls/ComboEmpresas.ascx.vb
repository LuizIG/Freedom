Imports System.IO
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json.Linq

Public Class ComboEmpresas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim page = New FreedomPage()
        Dim loginsession = page.UserSession

        If IsPostBack Then
            If page.UpdateEmpresa AndAlso page.ReLoadComboEmpresa Then
                CargarEmpresas(loginsession.OrganizacionId)
            End If
        Else
            CargarEmpresas(loginsession.OrganizacionId)

            If page.EmpresaId > 0 Then
                For Each item As ListItem In cbxEmpresa.Items
                    If item.Value = page.EmpresaId.ToString() Then
                        If Not item.Selected Then
                            item.Selected = True
                        End If
                    End If
                Next
            Else
                Dim idEmpresa = cbxEmpresa.Items(cbxEmpresa.SelectedIndex).Value
                page.EmpresaId = Convert.ToInt32(idEmpresa)
            End If
        End If
    End Sub

    Public Sub CargarEmpresas(IdOrganizacion As Integer)
        Dim page = New FreedomPage()
        Dim loginsession = page.UserSession
        Dim req = GetRequest("api/Empresas?idOrganizacion=" & IdOrganizacion, loginsession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim empresas As List(Of Model.Empresa) = StringToValue(detail.ToString(), GetType(List(Of Model.Empresa)))

            cbxEmpresa.DataSource = empresas.OrderByDescending(Function(x) x.EmpresaDefault).ThenBy(Function(x) x.IdEmpresa)
            cbxEmpresa.DataValueField = "EmpresaId"
            cbxEmpresa.DataTextField = "NombreEmpresa"
            cbxEmpresa.DataBind()

            If page.UpdateEmpresa Then
                For Each item As ListItem In cbxEmpresa.Items
                    If item.Value = page.EmpresaId.ToString() Then
                        item.Selected = True
                    End If
                Next
            End If
        End If
    End Sub

    Public Shared Function StringToValue(value As String, type As Type) As Object
        Dim jss = New JavaScriptSerializer()
        Dim result As Object = jss.Deserialize(value, type)
        Return result
    End Function

    Public Sub cbxEmpresa_ServerChange(sender As Object, e As EventArgs)
        Dim freedom = New FreedomPage()
        Dim idEmpresa = cbxEmpresa.Items(cbxEmpresa.SelectedIndex).Value
        freedom.EmpresaId = Convert.ToInt32(idEmpresa)

        For Each item As ListItem In cbxEmpresa.Items
            If item.Value = freedom.EmpresaId.ToString() Then
                If Not item.Selected Then
                    item.Selected = True
                End If
            End If
        Next
    End Sub
End Class