Public Class ConfiguracionImpuesto
    Public Property idEmpresa() As Integer
        Get
            Return m_idEmpresa
        End Get
        Set
            m_idEmpresa = Value
        End Set
    End Property
    Private m_idEmpresa As Integer

    Public Property idTipoComprobante() As Integer
        Get
            Return m_idTipoComprobante
        End Get
        Set
            m_idTipoComprobante = Value
        End Set
    End Property
    Private m_idTipoComprobante As Integer

    Public Property TipoComprobante() As String
        Get
            Return m_TipoComprobante
        End Get
        Set
            m_TipoComprobante = Value
        End Set
    End Property
    Private m_TipoComprobante As String

    Public Property idTipoImpuesto() As Integer
        Get
            Return m_idTipoImpuesto
        End Get
        Set
            m_idTipoImpuesto = Value
        End Set
    End Property
    Private m_idTipoImpuesto As Integer

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
