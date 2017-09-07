
Public Class Usuario
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer

    Public Property Nombre() As String
        Get
            Return m_Nombre
        End Get
        Set
            m_Nombre = Value
        End Set
    End Property
    Private m_Nombre As String

    Public Property ApellidoPaterno() As String
        Get
            Return m_ApellidoPaterno
        End Get
        Set
            m_ApellidoPaterno = Value
        End Set
    End Property
    Private m_ApellidoPaterno As String

    Public Property ApellidoMaterno() As String
        Get
            Return m_ApellidoMaterno
        End Get
        Set
            m_ApellidoMaterno = Value
        End Set
    End Property
    Private m_ApellidoMaterno As String

    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set
            m_Email = Value
        End Set
    End Property
    Private m_Email As String

    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set
            m_Telefono = Value
        End Set
    End Property
    Private m_Telefono As String

    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set
            m_Password = Value
        End Set
    End Property
    Private m_Password As String

    Public Property Rol() As String
        Get
            Return m_Rol
        End Get
        Set
            m_Rol = Value
        End Set
    End Property
    Private m_Rol As String
End Class
