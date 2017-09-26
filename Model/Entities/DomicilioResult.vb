Public Class DomicilioResult
    Public Property EmpresaId() As Integer
        Get
            Return m_EmpresaId
        End Get
        Set
            m_EmpresaId = Value
        End Set
    End Property
    Private m_EmpresaId As Integer

    Public Property DomicilioId() As Integer
        Get
            Return m_DomicilioId
        End Get
        Set
            m_DomicilioId = Value
        End Set
    End Property
    Private m_DomicilioId As Integer

    Public Property Calle() As String
        Get
            Return m_Calle
        End Get
        Set
            m_Calle = Value
        End Set
    End Property
    Private m_Calle As String

    Public Property NumeroExterno() As String
        Get
            Return m_numeroExterno
        End Get
        Set
            m_numeroExterno = Value
        End Set
    End Property
    Private m_numeroExterno As String

    Public Property NumeroInterno() As String
        Get
            Return m_numeroInterno
        End Get
        Set
            m_numeroInterno = Value
        End Set
    End Property
    Private m_numeroInterno As String

    Public Property EntreCalles() As String
        Get
            Return m_entreCalles
        End Get
        Set
            m_entreCalles = Value
        End Set
    End Property
    Private m_entreCalles As String

    Public Property Colonia() As String
        Get
            Return m_colonia
        End Get
        Set
            m_colonia = Value
        End Set
    End Property
    Private m_colonia As String

    Public Property CP() As String
        Get
            Return m_cp
        End Get
        Set
            m_cp = Value
        End Set
    End Property
    Private m_cp As String

    Public Property Municipio() As String
        Get
            Return m_municipio
        End Get
        Set
            m_municipio = Value
        End Set
    End Property
    Private m_municipio As String

    Public Property EstadoId() As Integer
        Get
            Return m_estadoId
        End Get
        Set
            m_estadoId = Value
        End Set
    End Property
    Private m_estadoId As Integer

    Public Property FiscalFlg() As Boolean
        Get
            Return m_fiscalFlg
        End Get
        Set
            m_fiscalFlg = Value
        End Set
    End Property
    Private m_fiscalFlg As Boolean

    Public Property EmisionFlg() As Boolean
        Get
            Return m_emisionFlg
        End Get
        Set
            m_emisionFlg = Value
        End Set
    End Property
    Private m_emisionFlg As Boolean
End Class
