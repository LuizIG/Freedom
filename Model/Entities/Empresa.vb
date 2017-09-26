Public Class Empresa
    Public Property IdEmpresa() As Integer
        Get
            Return m_IdEmpresa
        End Get
        Set
            m_IdEmpresa = Value
        End Set
    End Property
    Private m_IdEmpresa As Integer

    Public Property EmpresaId() As Integer
        Get
            Return m_EmpresaId
        End Get
        Set
            m_EmpresaId = Value
        End Set
    End Property
    Private m_EmpresaId As Integer

    Public Property NombreEmpresa() As String
        Get
            Return m_NombreEmpresa
        End Get
        Set
            m_NombreEmpresa = Value
        End Set
    End Property
    Private m_NombreEmpresa As String

    Public Property RFC() As String
        Get
            Return m_RFC
        End Get
        Set
            m_RFC = Value
        End Set
    End Property
    Private m_RFC As String

    Public Property RegimenFiscal() As String
        Get
            Return m_RegimenFiscal
        End Get
        Set
            m_RegimenFiscal = Value
        End Set
    End Property
    Private m_RegimenFiscal As String

    Public Property RegimenFiscalId() As String
        Get
            Return m_RegimenFiscalId
        End Get
        Set
            m_RegimenFiscalId = Value
        End Set
    End Property
    Private m_RegimenFiscalId As String

    Public Property ActivoFlg() As Boolean
        Get
            Return m_ActivoFlg
        End Get
        Set
            m_ActivoFlg = Value
        End Set
    End Property
    Private m_ActivoFlg As Boolean

    Public Property DefaultFlg() As Boolean
        Get
            Return m_DefaultFlg
        End Get
        Set
            m_DefaultFlg = Value
        End Set
    End Property
    Private m_DefaultFlg As Boolean

    Public Property CURP() As String
        Get
            Return m_CURP
        End Get
        Set
            m_CURP = Value
        End Set
    End Property
    Private m_CURP As String

    Public Property OrganizacionId() As String
        Get
            Return m_OrganizacionId
        End Get
        Set
            m_OrganizacionId = Value
        End Set
    End Property
    Private m_OrganizacionId As String

    Public Property EstatusEmpresa() As String
        Get
            Return m_EstatusEmpresa
        End Get
        Set
            m_EstatusEmpresa = Value
        End Set
    End Property
    Private m_EstatusEmpresa As String

    Public Property EmpresaDefault() As String
        Get
            Return m_EmpresaDefault
        End Get
        Set
            m_EmpresaDefault = Value
        End Set
    End Property
    Private m_EmpresaDefault As String

    Public Property CertificadoDigital() As String
        Get
            Return m_CertificadoDigital
        End Get
        Set
            m_CertificadoDigital = Value
        End Set
    End Property
    Private m_CertificadoDigital As String

    Public Property LlavePrivada() As String
        Get
            Return m_LlavePrivada
        End Get
        Set
            m_LlavePrivada = Value
        End Set
    End Property
    Private m_LlavePrivada As String

    Public Property LlavePublica() As String
        Get
            Return m_LlavePublica
        End Get
        Set
            m_LlavePublica = Value
        End Set
    End Property
    Private m_LlavePublica As String

    Public Property EmpresaEmision() As String
        Get
            Return m_EmpresaEmision
        End Get
        Set
            m_EmpresaEmision = Value
        End Set
    End Property
    Private m_EmpresaEmision As String

    Public Property NombreComercial() As String
        Get
            Return m_NombreComercial
        End Get
        Set
            m_NombreComercial = Value
        End Set
    End Property
    Private m_NombreComercial As String
End Class
