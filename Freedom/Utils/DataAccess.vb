Imports System.IO
Imports System.Net
Imports System.Web.Hosting
Imports Newtonsoft.Json.Linq
Module DataAccess
    ' AWS
    'Public Const SERVER_HOST As String = "http://13.59.156.149/FreedomApi/"

    ' Azure
    Public Const SERVER_HOST As String = "http://freedomapi-test.azurewebsites.net/"

    Public Function PostRequest(url As String, data As String, token As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = CreateRequest(SERVER_HOST & url, "POST", token, contentType)
        SendData(request, data)
        Return GetData(request)
    End Function

    Public Function GetRequest(url As String, token As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = CreateRequest(SERVER_HOST & url, "GET", token, contentType)
        Return GetData(request)
    End Function

    Public Function DeleteRequest(url As String, token As String, Optional ByVal data As String = "", Optional ByVal contentType As String = "application/json") As String
        Dim request = CreateRequest(SERVER_HOST & url, "DELETE", token, contentType)
        Return GetData(request)
    End Function

    Public Function PutRequest(url As String, token As String, data As String, Optional ByVal contentType As String = "application/json") As String
        Dim request = CreateRequest(SERVER_HOST & url, "PUT", token, contentType)
        SendData(request, data)
        Return GetData(request)
    End Function

    Private Function CreateRequest(ByVal url As String, ByVal method As String, ByVal token As String, Optional ByVal contentType As String = "application/json") As WebRequest
        Console.WriteLine(url)
        Dim request As WebRequest = WebRequest.Create(url)
        request.Method = method
        request.ContentType = contentType

        If Not String.IsNullOrEmpty(token) Then
            request.Headers.Add("Authorization", "bearer " & token)
        End If

        Return request
    End Function

    Private Sub SendData(ByRef request As WebRequest, ByVal data As String)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(data)
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
    End Sub

    Private Function GetData(ByRef request As WebRequest) As String

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
End Module
