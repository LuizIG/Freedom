Public Class PersonalizacionResult
    Public Property EmpresaId() As Integer
        Get
            Return m_EmpresaId
        End Get
        Set
            m_EmpresaId = Value
        End Set
    End Property
    Private m_EmpresaId As Integer

    Public Property NombreComercial() As String
        Get
            Return m_nombreComercial
        End Get
        Set
            m_nombreComercial = Value
        End Set
    End Property
    Private m_nombreComercial As String

    Public Property IVAPredeterminado() As Integer
        Get
            Return m_IVAPredeterminado
        End Get
        Set
            m_IVAPredeterminado = Value
        End Set
    End Property
    Private m_IVAPredeterminado As Integer

    Public Property LogoTipoNombre() As String
        Get
            Return m_LogoTipoNombre
        End Get
        Set
            m_LogoTipoNombre = Value
        End Set
    End Property
    Private m_LogoTipoNombre As String

    Public Property MensajeAdicionalFactura() As String
        Get
            Return m_mensajeAdicionalFactura
        End Get
        Set
            m_mensajeAdicionalFactura = Value
        End Set
    End Property
    Private m_mensajeAdicionalFactura As String

    Public Property Telefono() As String
        Get
            Return m_telefono
        End Get
        Set
            m_telefono = Value
        End Set
    End Property
    Private m_telefono As String

    Public Property CorreoElectronico() As String
        Get
            Return m_CorreoElectronico
        End Get
        Set
            m_CorreoElectronico = Value
        End Set
    End Property
    Private m_CorreoElectronico As String

    Public Property TituloCorreo() As String
        Get
            Return m_tituloCorreo
        End Get
        Set
            m_tituloCorreo = Value
        End Set
    End Property
    Private m_tituloCorreo As String

    Public Property CuerpoCorreo() As String
        Get
            Return m_cuerpoCorreo
        End Get
        Set
            m_cuerpoCorreo = Value
        End Set
    End Property
    Private m_cuerpoCorreo As String
End Class
