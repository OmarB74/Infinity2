Option Explicit On
Public Class FrmListaProveedorCliente
    Public iTipoPersona As Integer = 0
    Public iTipoProveedorCliente As Integer
    Dim sortColumn As Integer = -1
    Private Sub FrmListaProveedorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.View = View.Details
        If iTipoProveedorCliente = 2 Then
            Me.Text = "Lista Clientes"
        End If
        If iTipoPersona = 1 Then

            ListView1.Columns.Add(IIf(iTipoProveedorCliente = 1, "Numero Proveedor", "Numero Cliente"), 70)
            ListView1.Columns.Add("Nombres", 300)
            ListView1.Columns.Add("Apellidos", 300)
            ListView1.Columns.Add("Pais", 300)
            ListView1.Columns.Add("Estado", 300)
            ListView1.Columns.Add("Municipio", 300)
            ListView1.Columns.Add("Colonia", 300)
            ListView1.Columns.Add("Calle", 300)
            ListView1.Columns.Add("Numero Exterior", 300)
            ListView1.Columns.Add("Numero Interior", 300)
            ListView1.Columns.Add("CP", 300)
            ListView1.Columns.Add("Fecha Alta", 300)
            ListView1.Columns.Add("Telefono", 30)
            ListView1.Columns.Add("Correo Electronico", 300)
            ListView1.Columns.Add("Tipo identificacion", 100)
            ListView1.Columns.Add("Numero Identificacion", 100)
        Else
            ListView1.Columns.Add(IIf(iTipoProveedorCliente = 1, "Numero Proveedor", "Numero Cliente"), 70)
            ListView1.Columns.Add("Razon Social", 300)
            ListView1.Columns.Add("Representante", 300)
            ListView1.Columns.Add("Pais", 300)
            ListView1.Columns.Add("Estado", 300)
            ListView1.Columns.Add("Municipio", 300)
            ListView1.Columns.Add("Colonia", 300)
            ListView1.Columns.Add("Calle", 300)
            ListView1.Columns.Add("Numero Exterior", 300)
            ListView1.Columns.Add("Numero Interior", 300)
            ListView1.Columns.Add("CP", 300)
            ListView1.Columns.Add("Fecha Alta", 300)
            ListView1.Columns.Add("Telefono", 30)
            ListView1.Columns.Add("Correo Electronico", 300)
        End If
        '
        If bRealizarBusquedaCondicionada = False Then
            Busqueda_ProveedorCliente(Me.ListView1, iTipoPersona, iTipoProveedorCliente)
        Else
            BusquedaCondicionada(Me.ListView1, iTipoPersona, iTipoProveedorCliente)
        End If
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick

        If ListView1.Columns.Item(e.Column).ListView.Sorting <> SortOrder.Descending Then
            ListView1.Columns.Item(e.Column).ListView.Sorting = SortOrder.Descending
        ElseIf ListView1.Columns.Item(e.Column).ListView.Sorting <> SortOrder.Ascending Then
            ListView1.Columns.Item(e.Column).ListView.Sorting = SortOrder.Ascending
        End If
        '' Determine whether the column is the same as the last column clicked.
        'If e.Column <> sortColumn Then
        '    ' Set the sort column to the new column.
        '    sortColumn = e.Column
        '    ' Set the sort order to ascending by default.
        '    ListView1.Sorting = SortOrder.Ascending
        'Else

        '    ' Determine what the last sort order was and change it.
        '    If ListView1.Sorting = SortOrder.Ascending Then
        '        ListView1.Sorting = SortOrder.Descending
        '    Else
        '        ListView1.Sorting = SortOrder.Ascending
        '    End If
        'End If
    End Sub
    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
        Next

        If AscW(e.KeyChar) = 13 Then
            iProveedorBusqueda = CInt(selec)
        End If
        Me.Close()
    End Sub
    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
        Next
        iProveedorBusqueda = CInt(selec)
        Me.Close()
    End Sub


End Class