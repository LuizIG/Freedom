Public Class TipoImpuesto
    Public Property Seleccionada() As Integer
        Get
            Return m_Seleccionada
        End Get
        Set
            m_Seleccionada = Value
        End Set
    End Property
    Private m_Seleccionada As Integer

    Public Property Clasificacion() As String
        Get
            Return m_Clasificacion
        End Get
        Set
            m_Clasificacion = Value
        End Set
    End Property
    Private m_Clasificacion As String

    Public Property Familia() As String
        Get
            Return m_Familia
        End Get
        Set
            m_Familia = Value
        End Set
    End Property
    Private m_Familia As String

    Public Property TipoImpuestoId() As Integer
        Get
            Return m_TipoImpuestoId
        End Get
        Set
            m_TipoImpuestoId = Value
        End Set
    End Property
    Private m_TipoImpuestoId As Integer

    Public Property TipoImpuesto() As String
        Get
            Return m_TipoImpuesto
        End Get
        Set
            m_TipoImpuesto = Value
        End Set
    End Property
    Private m_TipoImpuesto As String
End Class
