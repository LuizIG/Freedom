Imports System.Net
Imports System.Net.Mail
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin

' Configure el administrador de usuarios de aplicación que se usa en esta aplicación. UserManager se define en ASP.NET Identity y se usa en la aplicación.
Public Class ApplicationUserManager
    Inherits UserManager(Of ApplicationUser)

    Public Sub New(store As IUserStore(Of ApplicationUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationUserManager), context As IOwinContext) As ApplicationUserManager
        Dim manager = New ApplicationUserManager(New UserStore(Of ApplicationUser)(context.Get(Of ApplicationDbContext)()))

        ' Configure la lógica de validación de nombres de usuario
        manager.UserValidator = New UserValidator(Of ApplicationUser)(manager) With {
            .AllowOnlyAlphanumericUserNames = False,
            .RequireUniqueEmail = True
        }

        ' Configure la lógica de validación de contraseñas
        manager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 6,
            .RequireNonLetterOrDigit = False,
            .RequireDigit = False,
            .RequireLowercase = False,
            .RequireUppercase = False
        }

        manager.EmailService = New EmailService()

        Dim dataProtectionProvider = options.DataProtectionProvider
        If (dataProtectionProvider IsNot Nothing) Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of ApplicationUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If

        Return manager
    End Function
End Class

Public Class EmailService
    Implements IIdentityMessageService
    Public Function SendAsync(message As IdentityMessage) As Task
        Dim client As New SmtpClient("smtp.live.com")
        client.Port = 25
        client.Credentials = New System.Net.NetworkCredential("luis_mty_13@hotmail.com", "")
        client.EnableSsl = False
        Return client.SendMailAsync("luis.ibarra0992@gmail.com", message.Destination, message.Subject, message.Body)
    End Function

    Public Function IIdentityMessageService_SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        Dim fromAddress = New MailAddress("luis.ibarra0992@gmail.com", "Freedom")
        Dim toAddress = New MailAddress(message.Destination, "To Name")
        Const fromPassword As String = ""
        Dim subject As String = message.Subject
        Dim body As String = message.Body

        Dim smtp = New SmtpClient() With {
            .Host = "smtp.gmail.com",
            .Port = 587,
            .EnableSsl = True,
            .DeliveryMethod = SmtpDeliveryMethod.Network,
            .UseDefaultCredentials = False,
            .Credentials = New NetworkCredential(fromAddress.Address, fromPassword)
        }

        Return smtp.SendMailAsync("luis.ibarra0992@gmail.com", message.Destination, message.Subject, message.Body)
    End Function
End Class

