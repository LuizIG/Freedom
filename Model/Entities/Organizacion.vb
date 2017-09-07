Public Class Organizacion
    Public Property OrganizacionId() As Integer
        Get
            Return m_OrganizacionId
        End Get
        Set
            m_OrganizacionId = Value
        End Set
    End Property
    Private m_OrganizacionId As Integer

    Public Property NombreOrganizacion() As String
        Get
            Return m_NombreOrganizacion
        End Get
        Set
            m_NombreOrganizacion = Value
        End Set
    End Property
    Private m_NombreOrganizacion As String

    Public Property UsuarioId() As String
        Get
            Return m_UsuarioId
        End Get
        Set
            m_UsuarioId = Value
        End Set
    End Property
    Private m_UsuarioId As String

    Public Property ActivoFlg() As Boolean
        Get
            Return m_ActivoFlg
        End Get
        Set
            m_ActivoFlg = Value
        End Set
    End Property
    Private m_ActivoFlg As Boolean

    Public Property Fecha() As String
        Get
            Return m_Fecha
        End Get
        Set
            m_Fecha = Value
        End Set
    End Property
    Private m_Fecha As String
End Class
