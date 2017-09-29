Public Class ContactoEmpresa
    Public Property id() As Integer
        Get
            Return m_id
        End Get
        Set
            m_id = Value
        End Set
    End Property
    Private m_id As Integer

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

    Public Property nombre() As String
        Get
            Return m_nombre
        End Get
        Set
            m_nombre = Value
        End Set
    End Property
    Private m_nombre As String

    Public Property telefono() As String
        Get
            Return m_telefono
        End Get
        Set
            m_telefono = Value
        End Set
    End Property
    Private m_telefono As String

    Public Property telefonoMovil() As String
        Get
            Return m_telefonoMovil
        End Get
        Set
            m_telefonoMovil = Value
        End Set
    End Property
    Private m_telefonoMovil As String

    Public Property correoElectronico() As String
        Get
            Return m_correoElectronico
        End Get
        Set
            m_correoElectronico = Value
        End Set
    End Property
    Private m_correoElectronico As String

    Public Property puesto() As String
        Get
            Return m_puesto
        End Get
        Set
            m_puesto = Value
        End Set
    End Property
    Private m_puesto As String

    Public Property tipoContacto() As String
        Get
            Return m_tipoContacto
        End Get
        Set
            m_tipoContacto = Value
        End Set
    End Property
    Private m_tipoContacto As String
End Class
