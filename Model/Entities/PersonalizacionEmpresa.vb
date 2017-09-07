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

    Public Property mensajeFactura() As String
        Get
            Return m_mensajeFactura
        End Get
        Set
            m_mensajeFactura = Value
        End Set
    End Property
    Private m_mensajeFactura As String

    Public Property telefonoFactura() As String
        Get
            Return m_telefonoFactura
        End Get
        Set
            m_telefonoFactura = Value
        End Set
    End Property
    Private m_telefonoFactura As String

    Public Property correoFactura() As String
        Get
            Return m_correoFactura
        End Get
        Set
            m_correoFactura = Value
        End Set
    End Property
    Private m_correoFactura As String
End Class
