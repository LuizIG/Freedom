Imports System.ComponentModel.DataAnnotations

Public Class CertificadoEmpresa
    Public Property idEmpresa As Integer

    Public Property idOrganizacion As Integer

    ''' <summary>
    ''' CERTIFICADO CODIFICADO EN BASE 64
    ''' </summary>
    ''' <returns></returns>
    Public Property certificado As String
    ''' <summary>
    ''' LLAVE CODIFICADO EN BASE 64
    ''' </summary>
    ''' <returns></returns>
    Public Property llavePrivada As String

    Public Property llavePublica As String

End Class


Public Class ConfiguracionEmpresa

    <Required>
    Public Property idEmpresa As Integer

    <Required>
    Public Property idOrganizacion As Integer

    <Required>
    Public Property nombreComercial As String

    Public Property telefono As String

    Public Property correo As String

    Public Property mensajeAdicionalFactura As String
    ''' <summary>
    ''' LOGO CODIFICADO EN BASE 64
    ''' </summary>
    ''' <returns></returns>
    Public Property logo As String

    Public Property tituloCorreo As String

    Public Property cuerpoCorreo As String
End Class