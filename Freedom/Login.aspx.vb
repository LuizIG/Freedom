Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports Model
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Shared Function StringToValue(value As String, type As Type) As Object
        Dim jss = New JavaScriptSerializer()
        Dim result As Object = jss.Deserialize(value, type)
        Return result
    End Function

    <WebMethod(EnableSession:=True)>
    Public Shared Function LogIn(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim usuario = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "USUARIO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "USUARIO").ToList()(0).ParamValue.ToString(), "")
            Dim password = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CONTRASENA").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CONTRASENA").ToList()(0).ParamValue.ToString(), "")
            Dim esPersistente = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "ESPERSISTENTE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "ESPERSISTENTE").ToList()(0).ParamValue.ToString(), "")

            Dim ingresar = Login(usuario, password, Boolean.Parse(esPersistente))

            If ingresar.Result Then
                'FormsAuthentication.RedirectFromLoginPage(usuario, Boolean.Parse(esPersistente))
                Return New ServiceResult() With {
                        .Result = True,
                        .Message = "",
                        .Ret = "Inicio/Home.aspx"
                    }
            Else
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = ingresar.Message,
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
    Public Shared Function Registro(value As String) As ServiceResult
        Try
            Dim parametros As List(Of Parametros) = StringToValue(value, GetType(List(Of Parametros)))
            Dim nombre = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRE").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "NOMBRE").ToList()(0).ParamValue.ToString(), "")
            Dim apellidoPaterno = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "APELLIDOPATERNO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "APELLIDOPATERNO").ToList()(0).ParamValue.ToString(), "")
            Dim apellidoMaterno = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "APELLIDOMATERNO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "APELLIDOMATERNO").ToList()(0).ParamValue.ToString(), "")
            Dim correo = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CORREO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CORREO").ToList()(0).ParamValue.ToString(), "")
            Dim telefono = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "TELEFONO").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "TELEFONO").ToList()(0).ParamValue.ToString(), "")
            Dim pass = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "PASS").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "PASS").ToList()(0).ParamValue.ToString(), "")
            Dim confirmarPass = If(parametros.Where(Function(x) x.ParamName.ToUpper() = "CONFIRMARPASS").ToList()(0).ParamValue.ToString() <> "", parametros.Where(Function(x) x.ParamName.ToUpper() = "CONFIRMARPASS").ToList()(0).ParamValue.ToString(), "")
            Dim organizacion = "Organización " & nombre & " " & apellidoPaterno

            Dim reg = New Registro With {
                .Email = correo,
                .Password = pass,
                .ConfirmPassword = confirmarPass,
                .Name = nombre,
                .PaternalSurnae = apellidoPaterno,
                .MaternalSurnae = apellidoMaterno,
                .Phone = telefono,
                .Organization = organizacion
            }

            Dim registrar = Registro(reg)

            If registrar.Result Then
                Dim ingresar = Login(correo, pass, False)

                If ingresar.Result Then
                    Dim org = New Organizacion With {
                        .NombreOrganizacion = reg.Organization
                    }

                    Dim data = JsonConvert.SerializeObject(org)
                    Dim req = PostRequest("api/Organizacion", data, ingresar.Ret)
                    Dim result = JObject.Parse(req)
                    Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

                    If (statusCode >= 200 And statusCode < 400) Then
                        req = GetRequest("api/Organizacion", ingresar.Ret)
                        result = JObject.Parse(req)
                        statusCode = result.GetValue("statusCode").Value(Of Integer)

                        If (statusCode >= 200 And statusCode < 400) Then
                            Dim detalle = result.GetValue("detail").Value(Of JArray)
                            Dim organizaciones As List(Of Organizacion) = StringToValue(detalle.ToString(), GetType(List(Of Organizacion)))

                            Dim info = New UserInfo With {
                                .Usuario = reg.Email,
                                .Token = ingresar.Ret,
                                .OrganizacionId = organizaciones.FirstOrDefault().OrganizacionId
                            }

                            Dim userData = JsonConvert.SerializeObject(info)
                            FormsAuthentication.SetAuthCookie(reg.Email, False)
                            Dim ticket As New FormsAuthenticationTicket(2,
                                                            reg.Email,
                                                            System.DateTime.Now,
                                                            System.DateTime.Now.AddDays(15),
                                                            False,
                                                            userData,
                                                            FormsAuthentication.FormsCookiePath)
                            Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
                            HttpContext.Current.Response.Cookies.Add(New HttpCookie("UserInfo", encTicket))
                        End If

                        Return New ServiceResult() With {
                            .Result = True,
                            .Message = "",
                            .Ret = "Configuracion/Empresas.aspx"
                        }
                    Else
                        Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                        Return New ServiceResult() With {
                            .Result = False,
                            .Message = errorMessage,
                            .Ret = ""
                        }
                    End If
                Else
                    Return New ServiceResult() With {
                        .Result = False,
                        .Message = ingresar.Message,
                        .Ret = ""
                    }
                End If
            Else
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = registrar.Message,
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

    Public Shared Function Login(user As String, pass As String, esPersistente As Boolean) As ServiceResult
        Dim req = PostRequest("Token", "grant_type=password&username=" & user & "&password=" & pass, String.Empty, "application/x-www-form-urlencoded")

        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)
        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JObject)
            Dim accessToken = detail.GetValue("access_token").Value(Of String)
            Dim tokenType = detail.GetValue("token_type").Value(Of String)
            Dim usr = detail.GetValue("userName").Value(Of String)

            req = GetRequest("api/Organizacion", accessToken)
            result = JObject.Parse(req)
            statusCode = result.GetValue("statusCode").Value(Of Integer)

            If (statusCode >= 200 And statusCode < 400) Then
                Dim detalle = result.GetValue("detail").Value(Of JArray)
                Dim organizaciones As List(Of Organizacion) = StringToValue(detalle.ToString(), GetType(List(Of Organizacion)))

                If organizaciones.Count > 0 Then
                    Dim info = New UserInfo With {
                        .Usuario = usr,
                        .Token = accessToken,
                        .OrganizacionId = organizaciones.FirstOrDefault().OrganizacionId
                    }

                    Dim userData = JsonConvert.SerializeObject(info)
                    FormsAuthentication.SetAuthCookie(user, esPersistente)

                    Dim ticket As New FormsAuthenticationTicket(1,
                                                                usr,
                                                                System.DateTime.Now,
                                                                System.DateTime.Now.AddDays(15),
                                                                esPersistente,
                                                                userData,
                                                                FormsAuthentication.FormsCookiePath)
                    Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
                    HttpContext.Current.Response.Cookies.Add(New HttpCookie("UserInfo", encTicket))
                End If

                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "",
                    .Ret = accessToken
                }
            Else
                Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
                Return New ServiceResult() With {
                    .Result = False,
                    .Message = errorMessage,
                    .Ret = ""
                }
            End If
        Else
            Dim errorMessage = result.GetValue("errorMessage").Value(Of String)
            Return New ServiceResult() With {
                .Result = False,
                .Message = errorMessage,
                .Ret = ""
            }
        End If
    End Function

    Public Shared Function Registro(reg As Registro) As ServiceResult
        Try
            Dim data = JsonConvert.SerializeObject(reg)
            Dim req = PostRequest("api/Account/Register", data, String.Empty)
            Dim result = JObject.Parse(req)
            Dim statusCode = result.GetValue("statusCode").Value(Of Integer)
            If (statusCode >= 200 And statusCode < 400) Then
                Return New ServiceResult() With {
                    .Result = True,
                    .Message = "",
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
End Class