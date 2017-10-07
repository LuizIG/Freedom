Imports System.ComponentModel.DataAnnotations

Public Class ConfiguracionCorreoModel
    <Required>
    Public Property idEmpresa As Integer
    <Required>
    Public Property servidor As String
    <Required>
    Public Property puerto As Integer
    <Required>
    Public Property cuenta As String
    <Required>
    Public Property contrasena As String
    <Required>
    Public Property ssl As Boolean
    <Required>
    Public Property active As Boolean
End Class


Public Class ConfiguracionCorreoUpdModel
    Inherits ConfiguracionCorreoModel

    Public Property idOrganizacion As Integer

End Class
