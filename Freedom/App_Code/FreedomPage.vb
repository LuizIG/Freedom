Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class FreedomPage
    Inherits System.Web.UI.Page
    'Private SERVER_HOST As String = ConfigurationManager.AppSettings("url").ToString
    Private Const SERVER_HOST As String = "http://localhost/"

    Protected Overridable Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClearLateralPanel()
        If (Session("access_token") Is Nothing) Then
            'Response.Redirect("~/")
            Return
        End If

    End Sub

    Protected Sub SelectMenuItem(ByVal id As String)
        Dim MasterPage = Page.Master
        Dim span As System.Web.UI.HtmlControls.HtmlGenericControl = TryCast(MasterPage.FindControl(id), System.Web.UI.HtmlControls.HtmlGenericControl)
        span.Attributes("class") = "bg-success icon-thumbnail"
    End Sub

    Private Sub ClearLateralPanel()
        Const BaseClass As String = "icon-thumbnail"
        Dim MasterPage = Page.Master
        For Each item As Control In MasterPage.Controls
            Dim span As System.Web.UI.HtmlControls.HtmlGenericControl = TryCast(item, System.Web.UI.HtmlControls.HtmlGenericControl)
            If span IsNot Nothing Then
                If span.ClientID.StartsWith("menu_span") Then
                    span.Attributes("class") = BaseClass
                End If
            End If
        Next
    End Sub

    Public Function doPostRequest(url As String, data As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = createRequest(SERVER_HOST & url, "POST", contentType)
        sendData(request, data)
        Return getData(request)
    End Function

    Public Function doGetRequest(url As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = createRequest(SERVER_HOST & url, "GET", contentType)
        Return getData(request)
    End Function


    Public Function doDeleteRequest(url As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = createRequest(SERVER_HOST & url, "DELETE", contentType)
        Return getData(request)
    End Function


    Public Function doPutRequest(url As String, data As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = createRequest(SERVER_HOST & url, "PUT", contentType)
        sendData(request, data)
        Return getData(request)
    End Function


    Private Function createRequest(ByVal url As String, ByVal method As String, Optional ByVal contentType As String = "application/json") As WebRequest
        Console.WriteLine(url)
        Dim request As WebRequest = WebRequest.Create(url)
        request.Method = method
        request.ContentType = contentType

        Dim token As String = Session("auth_token")

        If Not Strings.StrComp(token, "") = 0 Then
            request.Headers.Add("Authorization", "bearer " & token)
        End If
        Return request
    End Function


    Private Sub sendData(ByRef request As WebRequest, ByVal data As String)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(data)
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
    End Sub


    Private Function getData(ByRef request As WebRequest) As String

        Try
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusCode)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()
            If (responseFromServer Is Nothing Or String.Compare(responseFromServer, "") = 0) Then
                responseFromServer = "{}"
            End If
            Dim responseStatus = "{" _
                & """statusCode"":" & CType(response, HttpWebResponse).StatusCode & "," _
                & """errorMessage"":""""," _
                & """detail"":" & responseFromServer _
                & "}"
            Return responseStatus
        Catch ex As WebException
            Dim resp = New StreamReader(ex.Response.GetResponseStream()).ReadToEnd()

            Dim StatusCode As Integer = 9999

            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim response = TryCast(ex.Response, HttpWebResponse)
                If response IsNot Nothing Then
                    StatusCode = CInt(response.StatusCode)
                    ' no http status code available
                Else
                End If
                ' no http status code available
            Else
            End If

            Dim ErrorString As String = ""
            Dim errorJSON As JObject


            Try
                errorJSON = JObject.Parse(resp)
            Catch e As Exception
                ErrorString = "{
                      'Message': 'Ocurrió un error en el servidor'
                    }"
                Return "{" _
                & """statusCode"":" & StatusCode & "," _
                & """errorMessage"":""Ocurrió un error en el servidor""," _
                & """detail"":" & ErrorString _
                & "}"
            End Try

            Try
                ErrorString = errorJSON.GetValue("error_description").Value(Of String)
            Catch e As Exception

            End Try

            Try
                ErrorString = errorJSON.GetValue("Message").Value(Of String)
            Catch e As Exception

            End Try

            Dim responseStatus = "{" _
                & """statusCode"":" & StatusCode & "," _
                & """errorMessage"":""" & ErrorString & """," _
                & """detail"":" & resp _
                & "}"
            Return responseStatus
        End Try
    End Function

End Class
