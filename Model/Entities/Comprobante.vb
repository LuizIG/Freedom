Public Class Comprobante
    Public Property TipoComprobanteId() As Integer
        Get
            Return m_TipoComprobanteId
        End Get
        Set
            m_TipoComprobanteId = Value
        End Set
    End Property
    Private m_TipoComprobanteId As Integer

    Public Property TipoComprobante() As String
        Get
            Return m_TipoComprobante
        End Get
        Set
            m_TipoComprobante = Value
        End Set
    End Property
    Private m_TipoComprobante As String

    Public Property EsquemaFiscal() As String
        Get
            Return m_EsquemaFiscal
        End Get
        Set
            m_EsquemaFiscal = Value
        End Set
    End Property
    Private m_EsquemaFiscal As String
End Class
