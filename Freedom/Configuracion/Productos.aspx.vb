Public Class Productos
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)

    End Sub

    Protected Sub btnAgregarProducto_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnEditarProducto_Click(sender As Object, e As CommandEventArgs)
        Dim productoId = e.CommandArgument
    End Sub

    Protected Sub btnEliminarProducto_Click(sender As Object, e As CommandEventArgs)
        Dim productoId = e.CommandArgument
    End Sub
End Class