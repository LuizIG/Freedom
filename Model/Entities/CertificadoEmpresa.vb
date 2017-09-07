Public Class CertificadoEmpresa
    Public Property idEmpresa() As Integer
        Get
            Return m_idEmpresa
        End Get
        Set
            m_idEmpresa = Value
        End Set
    End Property
    Private m_idEmpresa As Integer

    Public Property idOrganizacion() As Integer
        Get
            Return m_idOrganizacion
        End Get
        Set
            m_idOrganizacion = Value
        End Set
    End Property
    Private m_idOrganizacion As Integer

    Public Property certificado() As String
        Get
            Return m_certificado
        End Get
        Set
            m_certificado = Value
        End Set
    End Property
    Private m_certificado As String

    Public Property llavePrivada() As String
        Get
            Return m_llavePrivada
        End Get
        Set
            m_llavePrivada = Value
        End Set
    End Property
    Private m_llavePrivada As String

    Public Property llavePublica() As String
        Get
            Return m_llavePublica
        End Get
        Set
            m_llavePublica = Value
        End Set
    End Property
    Private m_llavePublica As String
End Class
