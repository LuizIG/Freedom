Public Class DomicilioEmpresa
    Public Property IdEmpresa() As Integer
        Get
            Return m_IdEmpresa
        End Get
        Set
            m_IdEmpresa = Value
        End Set
    End Property
    Private m_IdEmpresa As Integer

    Public Property calle() As String
        Get
            Return m_calle
        End Get
        Set
            m_calle = Value
        End Set
    End Property
    Private m_calle As String

    Public Property numeroExterno() As String
        Get
            Return m_numeroExterno
        End Get
        Set
            m_numeroExterno = Value
        End Set
    End Property
    Private m_numeroExterno As String

    Public Property numeroInterno() As String
        Get
            Return m_numeroInterno
        End Get
        Set
            m_numeroInterno = Value
        End Set
    End Property
    Private m_numeroInterno As String

    Public Property entreCalles() As String
        Get
            Return m_entreCalles
        End Get
        Set
            m_entreCalles = Value
        End Set
    End Property
    Private m_entreCalles As String

    Public Property colonia() As String
        Get
            Return m_colonia
        End Get
        Set
            m_colonia = Value
        End Set
    End Property
    Private m_colonia As String

    Public Property cp() As String
        Get
            Return m_cp
        End Get
        Set
            m_cp = Value
        End Set
    End Property
    Private m_cp As String

    Public Property municipio() As String
        Get
            Return m_municipio
        End Get
        Set
            m_municipio = Value
        End Set
    End Property
    Private m_municipio As String

    Public Property estadoId() As Integer
        Get
            Return m_estadoId
        End Get
        Set
            m_estadoId = Value
        End Set
    End Property
    Private m_estadoId As Integer

    Public Property fiscalFlg() As Boolean
        Get
            Return m_fiscalFlg
        End Get
        Set
            m_fiscalFlg = Value
        End Set
    End Property
    Private m_fiscalFlg As Boolean

    Public Property emisionFlg() As Boolean
        Get
            Return m_emisionFlg
        End Get
        Set
            m_emisionFlg = Value
        End Set
    End Property
    Private m_emisionFlg As Boolean

    Public Property activoFlg() As Boolean
        Get
            Return m_activoFlg
        End Get
        Set
            m_activoFlg = Value
        End Set
    End Property
    Private m_activoFlg As Boolean
End Class
