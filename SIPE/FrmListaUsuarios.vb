Option Explicit On
Public Class FrmListaUsuarios

    Private Sub FrmListaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.View = View.Details
        ListView1.Columns.Add("codigo", 70)
        ListView1.Columns.Add("Nombre", 300)
        '
        Busqueda_Usuarios(Me.ListView1)
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        Dim nombre As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
            nombre = item.SubItems(1).Text
        Next

        If AscW(e.KeyChar) = 13 Then
            iUsuarioBusqueda = CInt(selec)
        End If
        Me.Close()
    End Sub
    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        Dim nombre As String = ""
        For Each item In breakfast

            selec = item.SubItems(0).Text
            nombre = item.SubItems(1).Text
        Next
        iUsuarioBusqueda = CInt(selec)
        Me.Close()
    End Sub
End Class