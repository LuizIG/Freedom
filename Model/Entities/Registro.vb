Public Class Registro

    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set
            m_Email = Value
        End Set
    End Property
    Private m_Email As String

    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set
            m_Password = Value
        End Set
    End Property
    Private m_Password As String

    Public Property ConfirmPassword() As String
        Get
            Return m_ConfirmPassword
        End Get
        Set
            m_ConfirmPassword = Value
        End Set
    End Property
    Private m_ConfirmPassword As String

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property PaternalSurnae() As String
        Get
            Return m_PaternalSurnae
        End Get
        Set
            m_PaternalSurnae = Value
        End Set
    End Property
    Private m_PaternalSurnae As String

    Public Property MaternalSurnae() As String
        Get
            Return m_MaternalSurnae
        End Get
        Set
            m_MaternalSurnae = Value
        End Set
    End Property
    Private m_MaternalSurnae As String


    Public Property Phone() As String
        Get
            Return m_Phone
        End Get
        Set
            m_Phone = Value
        End Set
    End Property
    Private m_Phone As String

    Public Property Organization() As String
        Get
            Return m_Organization
        End Get
        Set
            m_Organization = Value
        End Set
    End Property
    Private m_Organization As String

End Class
