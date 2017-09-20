Public Class PersonalizacionEmpresa
    Public Property idEmpresa() As Integer
        Get
            Return m_idEmpresa
        End Get
        Set
            m_idEmpresa = Value
        End Set
    End Property
    Private m_idEmpresa As Integer

    Public Property idOrganizacion() As Integer
        Get
            Return m_idOrganizacion
        End Get
        Set
            m_idOrganizacion = Value
        End Set
    End Property
    Private m_idOrganizacion As Integer

    Public Property nombreComercial() As String
        Get
            Return m_nombreComercial
        End Get
        Set
            m_nombreComercial = Value
        End Set
    End Property
    Private m_nombreComercial As String

    Public Property logo() As String
        Get
            Return m_logo
        End Get
        Set
            m_logo = Value
        End Set
    End Property
    Private m_logo As String

    Public Property mensajeAdicionalFactura() As String
        Get
            Return m_mensajeAdicionalFactura
        End Get
        Set
            m_mensajeAdicionalFactura = Value
        End Set
    End Property
    Private m_mensajeAdicionalFactura As String

    Public Property telefono() As String
        Get
            Return m_telefono
        End Get
        Set
            m_telefono = Value
        End Set
    End Property
    Private m_telefono As String

    Public Property correo() As String
        Get
            Return m_correo
        End Get
        Set
            m_correo = Value
        End Set
    End Property
    Private m_correo As String

    Public Property tituloCorreo() As String
        Get
            Return m_tituloCorreo
        End Get
        Set
            m_tituloCorreo = Value
        End Set
    End Property
    Private m_tituloCorreo As String

    Public Property cuerpoCorreo() As String
        Get
            Return m_cuerpoCorreo
        End Get
        Set
            m_cuerpoCorreo = Value
        End Set
    End Property
    Private m_cuerpoCorreo As String
End Class
