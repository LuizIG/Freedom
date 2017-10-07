Imports System.ComponentModel.DataAnnotations

Public Class EmpresasModel

    Public Property NombreEmpresa As String

    Public Property RFC As String

    Public Property RegimenFiscalId As String

    Public Property ActivoFlg As Boolean

    Public Property DefaultFlg As Boolean

    Public Property CURP As String

    Public Property OrganizacionId As String

End Class

Public Class EmpresasModelResult
    Inherits EmpresasModel

    Public Property Id As Integer


End Class



Public Class EmpresasUpdateModel

    Public Property IdEmpresa As Integer

    Public Property NombreEmpresa As String

    Public Property RFC As String

    Public Property RegimenFiscalId As String

    Public Property ActivoFlg As Boolean

    Public Property DefaultFlg As Boolean

    Public Property CURP As String

    Public Property OrganizacionId As String

End Class


Public Class EmpresasActivoModel

    Public Property IdEmpresa As Integer

    Public Property IdOrganizacion As Integer

End Class

Public Class DomicilioEmpresasModel

    Public Property IdEmpresa As Integer

    Public Property calle As String

    Public Property numeroExterno As String

    Public Property numeroInterno As String

    Public Property entreCalles As String

    Public Property colonia As String

    Public Property cp As String

    Public Property municipio As String

    Public Property estadoId As Integer

    Public Property fiscalFlg As Boolean

    Public Property emisionFlg As Boolean

    Public Property activoFlg As Boolean

End Class

Public Class DomicilioEmpresasUpdateModel
    Inherits DomicilioEmpresasModel
    Public Property IdDomicilio As Integer

End Class


Public Class OrganizacionModel

    Public Property id As Integer

    <Required>
    Public Property NombreOrganizacion As String

End Class


Public Class OrganizacionUpdateModel

    Public Property organizacionId As Integer
    Public Property NombreOrganizacion As String

    Public Property activoFlg As Boolean

End Class
