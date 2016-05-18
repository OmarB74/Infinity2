Option Explicit On
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Public Class FrmImportarPrecios
    Dim sArchivoSelec As String
    Dim sRutaSelec As String
    Dim gConexionsql As New SqlClient.SqlConnection
    Dim gConexionDBText As New Odbc.OdbcConnection
    Private Sub FrmImportarPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim Indice As Int16
        Dim sqlcmd As New OdbcCommand
        Try
            ' Definir las extensiones que se podran abrir(*.csv)
            OpenFileDialog1.Filter = "Archivos separados por comas (*.csv)|*.csv"
            OpenFileDialog1.Title = "Seleccione un archivo para Importar"
            'Abrir la ventana de dialogo, y definisr si se abrio el archivo
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

                ' Separar la ruta del Archivo y el Nombre del archivo
                Indice = OpenFileDialog1.FileName.LastIndexOfAny("\")
                sArchivoSelec = OpenFileDialog1.FileName.Substring(Indice + 1).ToUpper
                sRutaSelec = OpenFileDialog1.FileName.Substring(0, Indice)
                txtRutaArchivo.Text = OpenFileDialog1.FileName & " ....(Cargando Datos)"
                Application.DoEvents()


                ' Checar si ya existe el archivo de esquema
                Dim sw As System.IO.File
                If sw.Exists(sRutaSelec & "\schema.ini") Then
                    sw.Delete(sRutaSelec & "\schema.ini")
                End If
                ' Volver a crear el esquema
                CreaEsquemaDBText(sRutaSelec)

                ' Abrir la conexion a la base de datos
                AbrirConexionDBtext(sRutaSelec)

                'llenar el Listview con los datos del Archivo seleccionado
                Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                LlenaListView(ListaDatos, "Select * from " & sArchivoSelec)
                ' Activar el boton de impórtar datos, solo li la lista tiene mas de 1 elemento
                If ListaDatos.Items.Count > 0 Then
                    btnImportar.Enabled = True
                End If
                txtRutaArchivo.Text = OpenFileDialog1.FileName
                Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                ' Despues de obtener los datos del archivo de texto, cerrar la conexion
                CerrarConexionDBtext()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CreaEsquemaDBText(ByVal Ruta As String)
        Dim Archivo As New System.IO.StreamWriter(Ruta & "\schema.Ini")
        Archivo.WriteLine("Here is the first line.")
        Archivo.WriteLine("[ListaPrecio.csv]")
        Archivo.WriteLine("ColNameHeader = False")
        Archivo.WriteLine("Format = CSVDelimited")
        Archivo.WriteLine("Col1=ProductoId Integer")
        Archivo.WriteLine("Col2=Codigo Char Width 100")
        Archivo.WriteLine("Col3=Descripcion Char Width 250")
        Archivo.WriteLine("Col4=Precio_Mayoreo Char Width 250")
        Archivo.WriteLine("Col5=Precio_Especial Char Width 100")
        Archivo.WriteLine("Col6=Precio_Super_Especial Char Width 100")
        Archivo.Close()
    End Sub
    ' Abrir la conexion del archivo de texto
    Public Function AbrirConexionDBtext(ByVal Ruta As String) As Boolean
        Try
            gConexionDBText.ConnectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=" & Ruta & ";Extensions=asc,csv,tab,txt;HDR=NO;"
            gConexionDBText.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Err.Clear()
            Return False
        End Try
    End Function

    'Procedimiento que llena el listview en base a una consulta
    Private Sub LlenaListView(ByRef pLvw As ListView, ByVal psConsulta As String)
        'Variable para llenar el listview
        Dim lrenglonLvw As ListViewItem
        'Variables para ejecutar la consulta
        Dim lsqlcomand As Odbc.OdbcCommand
        Dim lsqlreader As Odbc.OdbcDataReader
        'Contadores
        Dim c As Integer
        'Valida si la consulta no tiene nada
        If psConsulta = "" Then
            MessageBox.Show("La consulta no es valida", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            'Instancia el comando
            lsqlcomand = New Odbc.OdbcCommand
            lsqlcomand.Connection = gConexionDBText
            lsqlcomand.CommandType = CommandType.Text
            lsqlcomand.CommandText = psConsulta
            'Ejecuta la consulta
            lsqlreader = lsqlcomand.ExecuteReader
            'Limpia el listview de los datos q pueda tener asi como las columnas
            pLvw.Items.Clear()
            pLvw.Columns.Clear()
            'Inicializa el listview
            pLvw.HideSelection = False
            pLvw.FullRowSelect = True
            pLvw.View = View.Details
            pLvw.BeginUpdate()
            'Llena las columnas en el listview segun la consulta
            For c = 0 To lsqlreader.FieldCount - 1
                pLvw.Columns.Add(lsqlreader.GetName(c).ToString, 50, HorizontalAlignment.Left)
            Next c
            'Empieza a llenar los elementos del listview
            While lsqlreader.Read
                For c = 0 To lsqlreader.FieldCount - 1
                    'Si es la columna 0 entonces 
                    If c = 0 Then
                        lrenglonLvw = New ListViewItem
                        If IsDBNull(lsqlreader.Item(lsqlreader.GetName(c).ToString)) = False Then
                            lrenglonLvw.Text = lsqlreader.Item(lsqlreader.GetName(c).ToString)
                        Else
                            lrenglonLvw.Text = ""
                        End If
                        pLvw.Items.Add(lrenglonLvw)
                    Else
                        If IsDBNull(lsqlreader.Item(lsqlreader.GetName(c).ToString.ToString)) = False Then
                            lrenglonLvw.SubItems.Add(lsqlreader.Item(lsqlreader.GetName(c).ToString.ToString))
                        Else
                            lrenglonLvw.SubItems.Add("")
                        End If
                    End If
                Next c
            End While
            pLvw.EndUpdate()
            'Cierra el sqldatareader y el sqlcommand
            lsqlreader.Close()
            lsqlcomand.Dispose()
        Catch
            MessageBox.Show(Err.Number & " - " & Err.Description, "Error en LlenaLvw", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Err.Clear()
            Try
                lsqlreader.Close()
                lsqlcomand.Dispose()
            Catch
                MessageBox.Show(Err.Number & " - " & Err.Description, "LlenaLvw al cerrar el sqldatareader ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Err.Clear()
            End Try
        End Try
    End Sub
    'Cierra la conexion del archivo de texto
    Private Sub CerrarConexionDBtext()
        Try
            If IsNothing(gConexionDBText) = False Then
                If gConexionDBText.State = ConnectionState.Open Then
                    gConexionDBText.Close()
                    gConexionDBText.Dispose()
                End If
            End If
        Catch
            MsgBox(Err.Number.ToString & " - " & Err.Description.ToString, MsgBoxStyle.Exclamation, "Modulo.CierraConexion")
            Err.Clear()
        End Try
    End Sub
End Class