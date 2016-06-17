Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmEncontradosListaProductoPrecio
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub FrmEncontradosListaProductoPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.View = View.Details


        ListView1.Columns.Add("Identificador", 0)
        ListView1.Columns.Add("Codigo de Barras", 150)
        ListView1.Columns.Add("Producto", 350)
        ListView1.Columns.Add("Precio", 100)
        ListView1.Columns.Add("Contenido", 100)
        ListView1.Columns.Add("Peso", 100)
        ListView1.Columns.Add("Lista", 200)
        ListView1.Columns.Add("Genero", 200)
        '
        BusquedaCondicionada(Me.ListView1)
    End Sub

    Private Sub BusquedaCondicionada(ByVal listado As ListView)
        Dim cadena(16) As String
        Dim iTipoBusqueda As Int16
        iTipoBusqueda = 1
        Try

            If sCodigoProducto <> "" Then
                iTipoBusqueda = 2
            Else
                If sProducto <> "" Then
                    iTipoBusqueda = 3
                End If
            End If
            '
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spBusquedaListaProductoPrecio"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoBusqueda", iTipoBusqueda))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@CodigoProducto", sCodigoProducto))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@Producto", sProducto))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@CodigodeBarras", sCodigodeBarras))

            Dim read As SqlDataReader = cmd.ExecuteReader()
            listado.Items.Clear()
            If read.HasRows Then
                While read.Read
                    '
                    Dim item1 As ListViewItem
                    '
                    cadena(0) = CStr(read(0))
                    cadena(1) = CStr(read(1))
                    cadena(2) = CStr(read(2))
                    cadena(3) = CStr(read(3))
                    cadena(4) = CStr(read(4))
                    cadena(5) = CStr(read(5))
                    cadena(6) = CStr(read(6))
                    cadena(7) = CStr(read(7))
                    item1 = New ListViewItem(cadena)
                    '
                    listado.Items.Add(item1)
                End While
            Else
                MsgBox("No se han encontrado Información")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Sub
    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
            sCodigoBarrasV = item.SubItems(1).Text
        Next

        If AscW(e.KeyChar) = 13 Then
            iLPPBusqueda = CInt(selec)
        End If
        Me.Close()
    End Sub
    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        Dim breakfast As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim selec As String = ""
        For Each item In breakfast
            selec = item.SubItems(0).Text
            sCodigoBarrasV = item.SubItems(1).Text
        Next
        iLPPBusqueda = CInt(selec)
        Me.Close()
    End Sub
End Class