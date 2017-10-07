Imports System.ComponentModel.DataAnnotations

Public Class ContactoEmpresaModel

    Public Property id As Integer
    <Required>
    Public Property idEmpresa As Integer
    <Required>
    Public Property nombre As String
    Public Property telefono As String
    Public Property telefonoMovil As String
    Public Property correoElectronico As String
    Public Property puesto As String
    Public Property tipoContacto As String

End Class

Public Class ContactoDelEmpresaModel
    <Required>
    Public Property id As Integer
    <Required>
    Public Property idEmpresa As Integer
    <Required>
    Public Property idOrganizacion As Integer


End Class
