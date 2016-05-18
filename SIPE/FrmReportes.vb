Option Explicit On

Public Class FrmReportes

    Private Sub FrmReportes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmReportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cadena(7, 2) As String
        cadena(0, 0) = "1"
        cadena(0, 1) = "Productos"
        cadena(1, 0) = "2"
        cadena(1, 1) = "Proveedores o Clientes"
        cadena(2, 0) = "3"
        cadena(2, 1) = "Ventas"
        cadena(3, 0) = "4"
        cadena(3, 1) = "Compras"
        cadena(4, 0) = "5"
        cadena(4, 1) = "Usuarios"
        cadena(5, 0) = "6"
        cadena(5, 1) = "Reimpresion Ticket"
        cadena(6, 0) = "7"
        cadena(6, 1) = "Almacen"
        lvReportes.FullRowSelect = True
        lvReportes.GridLines = True
        lvReportes.View = View.Details
        lvReportes.Columns.Add("codigo", 100)
        lvReportes.Columns.Add("Nombre", 300)
        For x As Integer = 0 To 6
            Dim item1 As ListViewItem
            Dim cadena2(2) As String
            cadena2(0) = cadena(x, 0)
            cadena2(1) = cadena(x, 1)
            item1 = New ListViewItem(cadena2)
            '
            lvReportes.Items.Add(item1)
        Next x
    End Sub

    Private Sub lvReportes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvReportes.KeyPress
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.lvReportes.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
        Next
        If AscW(e.KeyChar) = 13 Then

            AbrirReporte(Integer.Parse(selec))

        End If
    End Sub

    Private Sub lvReportes_MouseClick(sender As Object, e As MouseEventArgs) Handles lvReportes.MouseClick
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.lvReportes.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
        Next
        If AscW(e.Clicks) Then

            AbrirReporte(Integer.Parse(selec))

        End If
    End Sub
    Public Sub AbrirReporte(ByVal opcion As Integer)
        If opcion = 1 Then
            Dim Reporte As New FrmReporteProductos
            Reporte.ShowDialog()
        End If
        If opcion = 2 Then
            Dim Reporte As New FrmSeleccionReporteProveedorCliente
            Reporte.ShowDialog()
        End If
        If opcion = 4 Then
            Dim Reporte As New FrmComprasProveedor
            Reporte.ShowDialog()
        End If
        If opcion = 5 Then
            Dim Reporte As New FrmReporteUsuarios
            Reporte.ShowDialog()
        End If
        If opcion = 6 Then
            Dim Reporte As New FrmReimpresionComanda
            Reporte.ShowDialog()
        End If
        If opcion = 7 Then
            Dim Reporte As New FrmReporteAlmacen
            Reporte.ShowDialog()
        End If
    End Sub
End Class