Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports Model
Imports Newtonsoft.Json.Linq

Public Class FreedomPage
    Inherits System.Web.UI.Page

    Public Shared Function StringToValue(value As String, type As Type) As Object
        Dim jss = New JavaScriptSerializer()
        Dim result As Object = jss.Deserialize(value, type)
        Return result
    End Function

    Public Function GetUserInfo() As UserInfo
        If Page.User.Identity.IsAuthenticated Then
            Dim cookie As HttpCookie = Context.Request.Cookies("UserInfo")
            Dim auth = FormsAuthentication.Decrypt(cookie.Value)
            Dim info As UserInfo = StringToValue(auth.UserData, GetType(UserInfo))
            Return info
        Else
            Return Nothing
        End If
    End Function

    Public ReadOnly Property UserSession() As UserInfo
        Get
            If GetUserInfo() Is Nothing Then
                Return Nothing
            Else
                Return GetUserInfo()
            End If
        End Get
    End Property

    Public Property EmpresaId() As Integer
        Get
            If Session("EmpresaId") Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(Session("EmpresaId"), Integer)
            End If
        End Get
        Set
            Session("EmpresaId") = Value
        End Set
    End Property

    Protected Overridable Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Page.User.Identity.IsAuthenticated Then
                FormsAuthentication.RedirectToLoginPage()
            End If
        End If

        ClearLateralPanel()
    End Sub

    Protected Sub SelectMenuItem(ByVal id As String)
        Dim MasterPage = Page.Master
        Dim span As HtmlGenericControl = TryCast(MasterPage.FindControl(id), HtmlGenericControl)
        span.Attributes("class") = "bg-success icon-thumbnail"
    End Sub

    Private Sub ClearLateralPanel()
        Const BaseClass As String = "icon-thumbnail"
        Dim MasterPage = Page.Master
        If MasterPage IsNot Nothing Then
            For Each item As Control In MasterPage.Controls
                Dim span As System.Web.UI.HtmlControls.HtmlGenericControl = TryCast(item, System.Web.UI.HtmlControls.HtmlGenericControl)
                If span IsNot Nothing Then
                    If span.ClientID.StartsWith("menu_span") Then
                        span.Attributes("class") = BaseClass
                    End If
                End If
            Next
        End If
    End Sub

End Class
