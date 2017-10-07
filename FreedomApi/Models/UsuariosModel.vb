Imports System.ComponentModel.DataAnnotations
Imports Newtonsoft.Json

' Modelos usados como parámetros para las acciones de AccountController.

Public Class PermisoUsarioEmpresa
    <Required>
    <Display(Name:="Id Organizacion")>
    Public Property idOrganizacion As Integer
    <Required>
    <Display(Name:="Id Empresa")>
    Public Property idEmpresa As Integer
    <Required>
    <Display(Name:="Id Usuario")>
    Public Property idUsuario As String
    <Required>
    <Display(Name:="Id Permiso")>
    Public Property idPermiso As Integer
End Class

Public Class DeletePermisoUsarioEmpresa
    <Required>
    <Display(Name:="Id Organizacion")>
    Public Property idOrganizacion As Integer
    <Required>
    <Display(Name:="Id Empresa")>
    Public Property idEmpresa As Integer
    <Required>
    <Display(Name:="Id Usuario")>
    Public Property idUsuario As String
End Class
