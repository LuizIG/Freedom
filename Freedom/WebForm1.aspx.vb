Public Class WebForm1
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)
        SelectMenuItem("menu_span_inicio")
    End Sub
End Class