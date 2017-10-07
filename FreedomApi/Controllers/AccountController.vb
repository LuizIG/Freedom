Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Security.Claims
Imports System.Security.Cryptography
Imports System.Threading.Tasks
Imports System.Web
Imports System.Web.Http
Imports System.Web.Http.ModelBinding
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.OAuth

<Authorize>
<RoutePrefix("api/Account")>
Public Class AccountController
    Inherits FreedomApi
    Private Const LocalLoginProvider As String = "Local"
    
    Private _userManager As ApplicationUserManager
    Private m_AccessTokenFormat As ISecureDataFormat(Of AuthenticationTicket)

    Public Sub New()
    End Sub

    Public Sub New(userMan As ApplicationUserManager, accessTokenFormatType As ISecureDataFormat(Of AuthenticationTicket))
        Me.UserManager = userMan
        Me.AccessTokenFormat = accessTokenFormatType
    End Sub

    Public Property UserManager() As ApplicationUserManager
        Get
            Return If(_userManager, Request.GetOwinContext().GetUserManager(Of ApplicationUserManager)())
        End Get
        Private Set
            _userManager = value
        End Set
    End Property

    Public Property AccessTokenFormat() As ISecureDataFormat(Of AuthenticationTicket)
        Get
            Return m_AccessTokenFormat
        End Get
        Private Set
            m_AccessTokenFormat = Value
        End Set
    End Property

    ' GET api/Account/UserInfo
    <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
    <Route("UserInfo")>
    Public Function GetUserInfo() As UserInfoViewModel
        Dim externalLogin As ExternalLoginData = ExternalLoginData.FromIdentity(TryCast(User.Identity, ClaimsIdentity))

        Return New UserInfoViewModel() With {
            .Email = User.Identity.GetUserName(),
            .HasRegistered = externalLogin Is Nothing,
            .LoginProvider = If(externalLogin IsNot Nothing, externalLogin.LoginProvider, Nothing)
        }
    End Function

    ' POST api/Account/Logout
    <Route("Logout")>
    Public Function Logout() As IHttpActionResult
        Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType)
        Return Ok()
    End Function

    ' POST api/Account/ChangePassword
    <Route("ChangePassword")>
    Public Async Function ChangePassword(model As ChangePasswordBindingModel) As Task(Of IHttpActionResult)
        If Not ModelState.IsValid Then
            Return BadRequest(ModelState)
        End If

        Dim result As IdentityResult = Await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword)

        If Not result.Succeeded Then
            Return GetErrorResult(result)
        End If

        Return Ok()
    End Function


    ' POST api/Account/SendInvitation
    <Route("SendInvitation")>
    <HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)>
    Public Async Function SendInvitation(model As InviteModel) As Task(Of IHttpActionResult)
        If Not ModelState.IsValid Then
            Return BadRequest(ModelState)
        End If
        Dim guest = HttpContext.Current.User.Identity.Name




        Dim userInvited = Await UserManager.FindByEmailAsync(model.email)
        Dim baseUrl = "http://localhost:50098/"

        Dim body = guest & " te ha invitado a colaborar en su origanización.\n"
        body += "Da clic en el siguiente enlace para aceptar la invitación.\n"

        Dim idOrganizacionEnc = AES_Encrypt(model.idOrganizacion)

        Dim idOrganizacion = AES_Decrypt(idOrganizacionEnc)

        If (userInvited Is Nothing) Then
            'El no existe

            Dim message = New IdentityMessage()
            message.Destination = model.email
            message.Subject = "Te han invitado a trabajar en una organización"

            body += "<a href='" & baseUrl & "Inicio/Register?x=" & idOrganizacionEnc & "' >link</a>"

            message.Body = body

            Dim emailservice = New EmailService()
            Await emailservice.IIdentityMessageService_SendAsync(message)
        Else
            'El usuario ya existe
            body += "<a href='" & baseUrl & "Login?email=" & model.email & "&org=" & idOrganizacionEnc & "'' >link</a>"

            Await UserManager.SendEmailAsync(userInvited.Id, "Te han invitado a trabajar en una organización", body)
        End If

        Return Ok()
    End Function


    ' POST api/Account/SetPassword
    <Route("SetPassword")>
    Public Async Function SetPassword(model As SetPasswordBindingModel) As Task(Of IHttpActionResult)
        If Not ModelState.IsValid Then
            Return BadRequest(ModelState)
        End If

        Dim result As IdentityResult = Await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword)

        If Not result.Succeeded Then
            Return GetErrorResult(result)
        End If

        Return Ok()
    End Function

    ' POST api/Account/Register
    <AllowAnonymous>
    <Route("Register")>
    Public Async Function Register(model As RegisterBindingModel) As Task(Of IHttpActionResult)
        If Not ModelState.IsValid Then
            Return BadRequest(ModelState)
        End If

        Dim idOrganizacionClear As String = ""
        If (model.idOrganizacion IsNot Nothing) Then
            idOrganizacionClear = AES_Decrypt(model.idOrganizacion)
            If (idOrganizacionClear <> "") Then

            Else
                Return BadRequest("La organización no es válida")
            End If
        End If

        Dim user = New ApplicationUser() With {
            .UserName = model.Email,
            .Email = model.Email,
            .Name = model.Name,
            .PaternalSurname = model.PaternalSurnae,
            .MaternalSurname = model.MaternalSurnae,
            .PhoneNumber = model.Phone,
            .RegisterDate = DateTime.Now,
            .ActiveUser = True
        }

        Dim result As IdentityResult = Await UserManager.CreateAsync(user, model.Password)

        If Not result.Succeeded Then
            Return GetErrorResult(result)
        End If


        If (idOrganizacionClear <> "") Then
  
            Dim userCreated = Await UserManager.FindByEmailAsync(model.Email)
            db.spINSUsuario_Organizacion(userCreated.Id, 1, CInt(idOrganizacionClear), "")
        End If

        Dim token = Await UserManager.GenerateEmailConfirmationTokenAsync(user.Id)

        Await UserManager.SendEmailAsync(user.Id, "Confirma tu correo", "Cuerpo " & token)

        Return Ok()
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso _userManager IsNot Nothing Then
            _userManager.Dispose()
            _userManager = Nothing
        End If

        MyBase.Dispose(disposing)
    End Sub

#Region "Helpers"

    Private ReadOnly Property Authentication() As IAuthenticationManager
        Get
            Return Request.GetOwinContext().Authentication
        End Get
    End Property

    Private Function GetErrorResult(result As IdentityResult) As IHttpActionResult
        If result Is Nothing Then
            Return InternalServerError()
        End If

        If Not result.Succeeded Then
            If result.Errors IsNot Nothing Then
                For Each [error] As String In result.Errors
                    ModelState.AddModelError("", [error])
                Next
            End If

            If ModelState.IsValid Then
                ' No hay disponibles errores ModelState para enviar, por lo que simplemente devuelva un BadRequest vacío.
                Return BadRequest()
            End If

            Return BadRequest(ModelState)
        End If

        Return Nothing
    End Function

    Private Class ExternalLoginData
        Public Property LoginProvider As String
        Public Property ProviderKey As String
        Public Property UserName As String

        Public Function GetClaims() As IList(Of Claim)
            Dim claims As IList(Of Claim) = New List(Of Claim)()
            claims.Add(New Claim(ClaimTypes.NameIdentifier, ProviderKey, Nothing, LoginProvider))

            If UserName IsNot Nothing Then
                claims.Add(New Claim(ClaimTypes.Name, UserName, Nothing, LoginProvider))
            End If

            Return claims
        End Function

        Public Shared Function FromIdentity(identity As ClaimsIdentity) As ExternalLoginData
            If identity Is Nothing Then
              Return Nothing
            End If

            Dim providerKeyClaim As Claim = identity.FindFirst(ClaimTypes.NameIdentifier)

            If providerKeyClaim Is Nothing OrElse [String].IsNullOrEmpty(providerKeyClaim.Issuer) OrElse [String].IsNullOrEmpty(providerKeyClaim.Value) Then
              Return Nothing
            End If

            If providerKeyClaim.Issuer = ClaimsIdentity.DefaultIssuer Then
              Return Nothing
            End If

            Return New ExternalLoginData() With {
                .LoginProvider = providerKeyClaim.Issuer,
                .ProviderKey = providerKeyClaim.Value,
                .UserName = identity.FindFirstValue(ClaimTypes.Name)
            }
        End Function
    End Class

    Private NotInheritable Class RandomOAuthStateGenerator
        Private Sub New()
        End Sub
        Private Shared _random As RandomNumberGenerator = New RNGCryptoServiceProvider()

        Public Shared Function Generate(strengthInBits As Integer) As String
            Const  bitsPerByte As Integer = 8

            If strengthInBits Mod bitsPerByte <> 0 Then
                Throw New ArgumentException("strengthInBits debe ser uniformemente divisible por 8.", "strengthInBits")
            End If

            Dim strengthInBytes As Integer = strengthInBits \ bitsPerByte
  
            Dim data As Byte() = New Byte(strengthInBytes - 1) {}
            _random.GetBytes(data)
            Return HttpServerUtility.UrlTokenEncode(data)
        End Function
    End Class
    #End Region
End Class
