Imports System.ComponentModel.DataAnnotations

Public Class UsuariosSerieFolioCFDIModel

    Public Property id As Integer

    <Required>
    Public Property idEmpresa As Integer


    <Required>
    Public Property serie As String

    <Required>
    Public Property folioInicial As String

    <Required>
    Public Property tipoComprobante As Integer

    <Required>
    Public Property idOrganizacion As Integer

End Class

Public Class DelUsuariosSerieFolioCFDIModel


    <Required>
    Public Property idEmpresa As Integer

    <Required>
    Public Property idOrganizacion As Integer

End Class