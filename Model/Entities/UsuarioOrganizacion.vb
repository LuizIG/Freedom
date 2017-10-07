Public Class UsuarioOrganizacion
    Public Property OrganizacionId() As Integer
        Get
            Return m_OrganizacionId
        End Get
        Set
            m_OrganizacionId = Value
        End Set
    End Property
    Private m_OrganizacionId As Integer

    Public Property UsuarioId() As Integer
        Get
            Return m_UsuarioId
        End Get
        Set
            m_UsuarioId = Value
        End Set
    End Property
    Private m_UsuarioId As Integer

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property PaternalSurname() As String
        Get
            Return m_PaternalSurname
        End Get
        Set
            m_PaternalSurname = Value
        End Set
    End Property
    Private m_PaternalSurname As String

    Public Property MaternalSurname() As String
        Get
            Return m_MaternalSurname
        End Get
        Set
            m_MaternalSurname = Value
        End Set
    End Property
    Private m_MaternalSurname As String
End Class
