Public Class UserInfo
    Public Property Token() As String
        Get
            Return m_Token
        End Get
        Set
            m_Token = Value
        End Set
    End Property
    Private m_Token As String
    Public Property Usuario() As String
        Get
            Return m_Usuario
        End Get
        Set
            m_Usuario = Value
        End Set
    End Property
    Private m_Usuario As String

    Public Property OrganizacionId() As Integer
        Get
            Return m_OrganizacionId
        End Get
        Set
            m_OrganizacionId = Value
        End Set
    End Property
    Private m_OrganizacionId As Integer

    Public Property EmpresaId() As Integer
        Get
            Return m_EmpresaId
        End Get
        Set
            m_EmpresaId = Value
        End Set
    End Property
    Private m_EmpresaId As Integer

    Public Property TokenVencido() As Boolean
        Get
            Return m_TokenVencido
        End Get
        Set
            m_TokenVencido = Value
        End Set
    End Property
    Private m_TokenVencido As Boolean
End Class
