Public Class ClienteModel
    Public Property ClienteEmpresaId As Integer
    Public Property OrganizacionId As Integer
    Public Property EmpresaId As Integer
    Public Property ClienteEmpresaNombre As String
    Public Property RegimenFiscalId As Integer
    Public Property RegimenFiscal As String
    Public Property RFC As String
End Class

Public Class ClienteDomicilioModel
    Public Property DomicilioId As Integer
    Public Property OrganizacionId As Integer
    Public Property EmpresaId As Integer
    Public Property ClienteId As Integer
    Public Property Calle As String
    Public Property NumeroExterno As String
    Public Property NumeroInterno As String
    Public Property EntreCalles As String
    Public Property Colonia As String
    Public Property CP As String
    Public Property Municipio As String
    Public Property EstadoId As Integer
    Public Property Estado As String
    Public Property PaisId As Integer
    Public Property Pais As String
End Class

Public Class ClienteConfiguracionModel
    Public Property ConfiguracionId As Integer
    Public Property ClienteId As Integer
    Public Property OrganizacionId As Integer
    Public Property EmpresaId As Integer
    Public Property Telefono As String
    Public Property CorreoElectronico As String
    Public Property DiasCredito As Integer
End Class

Public Class ClienteContactoModel
    Public Property ContactoId As Integer
    Public Property ClienteId As Integer
    Public Property OrganizacionId As Integer
    Public Property EmpresaId As Integer
    Public Property Nombre As String
    Public Property TelefonoFijo As String
    Public Property TelefonoMovil As String
    Public Property CorreoElectronico As String
    Public Property Puesto As String
    Public Property TipoContactoClienteId As Integer
    Public Property TipoContactoClienteNombre As String
End Class

Public Class ClienteContactoDeleteModel
    Public Property ContactoId As Integer
    Public Property ClienteId As Integer
End Class

Public Class ClienteMetodoPagoModel
    Public Property MetodoPagoId As Integer
    Public Property ClienteId As Integer
    Public Property MetodoPago As String
    Public Property Activo As Boolean
End Class

Public Class ClienteNumCtaPagoModel
    Public Property NumCtaPagoId As Integer
    Public Property ClienteId As Integer
    Public Property NumCtaPago As String
    Public Property Activo As Boolean
End Class

Public Class ClienteFormasPagoModel
    Public Property NumCtaPago As String
    Public Property MetodoPago As String
End Class


