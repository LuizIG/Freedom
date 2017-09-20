Imports Model
Imports Newtonsoft.Json.Linq

Public Class SeriesFolios
    Inherits FreedomPage

    Protected Overrides Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.Page_Load(sender, e)

        CargarComprobante()

        If Not IsPostBack Then
            Session("tblFolios") = Nothing
        End If
    End Sub

    Public Sub CargarTablaFolios()
        Dim tbl = New DataTable()
        Dim comprobante = cbxComprobante.Value
        Dim serie = txtSerie.Text
        Dim folioInicial = txtFolioInicial.Text
        Dim folioFinal = txtFolioFinal.Text

        If Session("tblFolios") Is Nothing Then
            tbl.Columns.Add("Id")
            tbl.Columns.Add("Empresa")
            tbl.Columns.Add("Serie")
            tbl.Columns.Add("FolioInicial")
            tbl.Columns.Add("FolioFinal")
            tbl.Columns.Add("TipoComprobante")
            tbl.Columns.Add("FechaRegistro")
            tbl.Columns.Add("Activa")

            tbl.Rows.Add(0, "", serie, folioInicial, folioFinal, comprobante, Now.ToString(), "Activo")
        Else
            tbl = DirectCast(Session("tblFolios"), DataTable)
            Dim newRow = tbl.NewRow

            newRow(0) = tbl.Rows.Count + 1
            newRow(1) = ""
            newRow(2) = serie
            newRow(3) = folioInicial
            newRow(4) = folioFinal
            newRow(5) = comprobante
            newRow(6) = Now.ToString()
            newRow(7) = "Activo"

            tbl.Rows.Add(newRow)
        End If

        txtSerie.Text = ""
        txtFolioInicial.Text = ""
        txtFolioFinal.Text = ""

        tbl.AcceptChanges()
        repFolios.DataSource = tbl
        repFolios.DataBind()
        Session("tblFolios") = tbl
    End Sub

    Public Sub CargarComprobante()
        Dim req = GetRequest("api/TipoComprobanteEsquemaFiscal?esquemafiscal=CFDI", UserSession.Token)
        Dim result = JObject.Parse(req)
        Dim statusCode = result.GetValue("statusCode").Value(Of Integer)

        If (statusCode >= 200 And statusCode < 400) Then
            Dim detail = result.GetValue("detail").Value(Of JArray)
            Dim comprobantes As List(Of Comprobante) = StringToValue(detail.ToString(), GetType(List(Of Comprobante)))

            cbxComprobante.DataSource = comprobantes
            cbxComprobante.DataValueField = "TipoComprobanteId"
            cbxComprobante.DataTextField = "TipoComprobante"
            cbxComprobante.DataBind()
        End If
    End Sub

    Protected Sub btnAgregarFolio_ServerClick(sender As Object, e As EventArgs)
        CargarTablaFolios()
    End Sub
End Class