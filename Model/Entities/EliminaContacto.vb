Public Class EliminaContacto
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
End Class
