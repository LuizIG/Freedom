Imports System.IO
Imports System.Net
Imports System.Web.Http
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class ConfiguracionEmpresaController
        Inherits FreedomApi
        ''' <summary>
        ''' spConsConfiguracionEmpresa_EmpresaId
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="idOrganizacion"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpGet>
        Public Function GetEmpresa(ByVal id As Integer, ByVal idOrganizacion As Integer) As IEnumerable(Of spConsConfiguracionEmpresa_EmpresaId_Result)
            Try
                Dim idUsuario As String = GetUserId()
                Return db.spConsConfiguracionEmpresa_EmpresaId(id, idOrganizacion, idUsuario)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try

        End Function


        ''' <summary>
        ''' spInsConfiguracionEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPost>
        Public Function InsConfiguracionEmpresa(ByVal model As ConfiguracionEmpresa) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try
                Dim newBytes() As Byte = Convert.FromBase64String(model.logo)
                Dim result = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.Ticks.ToString() & "_" & model.idEmpresa)
                Dim imageName = Convert.ToBase64String(result) & ".jpg"

                Dim errorMessage As String = ""


                If (ByteArrayToFile(imageName, newBytes, errorMessage)) Then
                    With model
                        db.spInsConfiguracionEmpresa(.idEmpresa, .nombreComercial, 1, .telefono, .correo, .mensajeAdicionalFactura, .idOrganizacion, imageName, .tituloCorreo, .cuerpoCorreo)
                    End With
                    Return Ok()
                End If

                Return BadRequest(errorMessage)

            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' spUpdConfiguracionEmpresa
        ''' </summary>
        ''' <param name="model"></param>
        ''' <returns></returns>
        <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
        <HttpPut>
        Public Function UptConfiguracionEmpresa(ByVal model As ConfiguracionEmpresa) As IHttpActionResult

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try

                Dim imageName = ""
                Dim newBytes() As Byte
                If (model.logo <> "") Then
                    newBytes = Convert.FromBase64String(model.logo)
                    Dim imageNameBytes = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.Ticks.ToString() & "_" & model.idEmpresa)
                    imageName = Convert.ToBase64String(imageNameBytes) & ".jpg"
                End If


                Dim errorMessage As String = ""
                With model
                    Dim response = db.spUpdConfiguracionEmpresa(.idEmpresa, .nombreComercial,
                                                     1, .telefono, .correo, .mensajeAdicionalFactura, .idOrganizacion, imageName, .tituloCorreo, .cuerpoCorreo)

                    Dim result = response.ToList(0)

                    If (result.IdError <> 0) Then
                        Return BadRequest(result.Error)
                    Else
                        'Remove prev image

                        If (imageName <> "") Then
                            Dim file = HttpContext.Current.Server.MapPath("~/logos/" & result.Error)
                            If System.IO.File.Exists(file) = True Then
                                System.IO.File.Delete(file)
                            End If
                            ByteArrayToFile(imageName, newBytes, errorMessage)
                        End If
                        Return Ok()
                    End If
                End With
                Return BadRequest(errorMessage)
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function


        Private Function ByteArrayToFile(fileName As String, byteArray As Byte(), ByRef errorMessage As String) As Boolean
            Try
                Dim root = HttpContext.Current.Server.MapPath("~/logos")
                Dim exists As Boolean = System.IO.Directory.Exists("~/logos")

                If Not exists Then
                    System.IO.Directory.CreateDirectory(root)
                End If
                Using fs = New FileStream(root & "/" & fileName, FileMode.Create, FileAccess.Write)
                    fs.Write(byteArray, 0, byteArray.Length)
                    Return True
                End Using
            Catch ex As Exception
                Console.WriteLine("Exception caught in process: {0}", ex)
                errorMessage = ex.Message
                Return False
            End Try
        End Function
    End Class
End Namespace