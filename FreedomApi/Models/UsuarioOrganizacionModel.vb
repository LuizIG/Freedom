Imports System.ComponentModel.DataAnnotations

Public Class UsuarioOrganizacionModel

    Public Property id As Integer

    <Required>
    Public Property email As String

    <Required>
    Public Property soloLectura As Boolean


    <Required>
    Public Property idOrganizacion As Integer

End Class


Public Class DeleteUsuarioOrganizacionModel

    <Required>
    Public Property email As String

    <Required>
    Public Property idOrganizacion As Integer

End Class
