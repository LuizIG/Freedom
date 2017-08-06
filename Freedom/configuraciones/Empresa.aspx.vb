Public Class Empresa
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)
        SelectMenuItem("menu_span_configuracion")
        SelectMenuItem("menu_span_configuracion_sistema")
        SelectMenuItem("menu_span_configuracion_sistema_empresa")

    End Sub

End Class