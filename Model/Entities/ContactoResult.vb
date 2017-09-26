Public Class ContactoResult
    Public Property EmpresaId() As Integer
        Get
            Return m_EmpresaId
        End Get
        Set
            m_EmpresaId = Value
        End Set
    End Property
    Private m_EmpresaId As Integer

    Public Property ContactoId() As Integer
        Get
            Return m_ContactoId
        End Get
        Set
            m_ContactoId = Value
        End Set
    End Property
    Private m_ContactoId As Integer

    Public Property Nombre() As String
        Get
            Return m_nombre
        End Get
        Set
            m_nombre = Value
        End Set
    End Property
    Private m_Nombre As String

    Public Property TelefonoFijo() As String
        Get
            Return m_TelefonoFijo
        End Get
        Set
            m_TelefonoFijo = Value
        End Set
    End Property
    Private m_TelefonoFijo As String

    Public Property TelefonoMovil() As String
        Get
            Return m_TelefonoMovil
        End Get
        Set
            m_TelefonoMovil = Value
        End Set
    End Property
    Private m_TelefonoMovil As String

    Public Property CorreoElectronico() As String
        Get
            Return m_CorreoElectronico
        End Get
        Set
            m_CorreoElectronico = Value
        End Set
    End Property
    Private m_CorreoElectronico As String

    Public Property Puesto() As String
        Get
            Return m_Puesto
        End Get
        Set
            m_Puesto = Value
        End Set
    End Property
    Private m_Puesto As String

    Public Property TipoContacto() As String
        Get
            Return m_TipoContacto
        End Get
        Set
            m_TipoContacto = Value
        End Set
    End Property
    Private m_TipoContacto As String
End Class
