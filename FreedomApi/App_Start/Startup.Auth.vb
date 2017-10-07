Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Google
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Public Partial Class Startup
    Private Shared _OAuthOptions As OAuthAuthorizationServerOptions
    Private Shared _PublicClientId As String

    Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
        Get
            Return _OAuthOptions
        End Get
        Private Set
            _OAuthOptions = Value
        End Set
    End Property

    Public Shared Property PublicClientId() As String
        Get
            Return _PublicClientId
        End Get
        Private Set
            _PublicClientId = Value
        End Set
    End Property

    ' Para obtener más información para configurar la autenticación, visite http://go.microsoft.com/fwlink/?LinkId=301864
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Configure el contexto de base de datos y el administrador de usuarios para usar una única instancia por solicitud
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)

        ' Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
        ' y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
        app.UseCookieAuthentication(New CookieAuthenticationOptions())
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Configure la aplicación para el flujo basado en OAuth
        ' En el modo de producción establezca AllowInsecureHttp = False
        PublicClientId = "self"
        OAuthOptions = New OAuthAuthorizationServerOptions() With {
          .TokenEndpointPath = New PathString("/Token"),
          .Provider = New ApplicationOAuthProvider(PublicClientId),
          .AuthorizeEndpointPath = New PathString("/api/Account/ExternalLogin"),
          .AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
          .AllowInsecureHttp = True
        }

        ' Permitir que la aplicación use tokens portadores para autenticar usuarios
        app.UseOAuthBearerTokens(OAuthOptions)

        ' Quitar los comentarios de las siguientes líneas para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '    consumerKey:="",
        '    consumerSecret:="")

        'app.UseFacebookAuthentication(
        '    appId:="",
        '    appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '    .ClientId = "",
        '    .ClientSecret = ""})
    End Sub
End Class
