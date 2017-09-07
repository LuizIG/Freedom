Public Class Parametros
    Public Property ParamName() As String
        Get
            Return m_ParamName
        End Get
        Set
            m_ParamName = Value
        End Set
    End Property
    Private m_ParamName As String

    Public Property ParamValue() As Object
        Get
            Return m_ParamValue
        End Get
        Set
            m_ParamValue = Value
        End Set
    End Property
    Private m_ParamValue As Object

    Public Property ParamType() As String
        Get
            Return m_ParamType
        End Get
        Set
            m_ParamType = Value
        End Set
    End Property
    Private m_ParamType As String
End Class
