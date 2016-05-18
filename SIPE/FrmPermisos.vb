Imports System.Data
Imports System.Data.SqlClient
Public Class FrmPermisos
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter

    Private Sub FrmPermisos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub
    Private Sub FrmPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        LlenaCombosStatus = False
        LlenarcboPerfil(cboPerfil)
        'Obtener_CatPantallas(lbPantallasDisp, cstrConnectBDapp, cboPerfil.SelectedValue) 'Llenamos la lista con los documentos disponibles en el catálogo
        Obten_PantallasPerfil()
        LlenaCombosStatus = True
        '
    End Sub
    Public Sub LlenarcboPerfil(ByVal objCombobox As ComboBox)
        objCombobox.DataSource = Obtener_Perfil().Tables("Perfil")
        objCombobox.DisplayMember = "DescGrupo"
        objCombobox.ValueMember = "GrupoId"
    End Sub

    Public Sub Vista_PantallasXPerfil(ByVal dsPantallas As DataSet)
        Dim i As Integer
        lbPantallasAgre.Items.Clear() 'Limpiamos el ListView
        For i = 0 To (dsPantallas.Tables(0).Rows.Count - 1) 'Para cargar los registros que trae el DataSet
            With dsPantallas.Tables(0)
                lbPantallasAgre.Items.Insert(i, .Rows(i).Item(2) & " - " & .Rows(i).Item(1))
                lbPantallasAgre.Sorted = True
                Dim j As Integer
                For j = 0 To lbPantallasDisp.Items.Count - 1
                    If Mid(lbPantallasDisp.Items.Item(j), 1, InStr(lbPantallasDisp.Items.Item(j), "-") - 7) = .Rows(i).Item(0) Then
                        lbPantallasDisp.Items.RemoveAt(j)
                        lbPantallasDisp.Sorted = True
                        Exit For
                    End If
                Next
            End With
        Next i
    End Sub
    Public Sub Obtener_CatPantallas(ByVal ListB As ListBox, ByVal strConexion As String)
        Dim i As Integer = 0
        Dim dr As SqlDataReader
        lbPantallasDisp.Items.Clear()
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spListaPantallas", Cnn)
            cmd.CommandType = CommandType.StoredProcedure 'asignar tipo de instruccion a ejecutar
            '
            'cmd.Parameters.Add(New SqlClient.SqlParameter("@Perfil", iPerfilId))
            '
            Cnn.Open()
            dr = cmd.ExecuteReader
            While dr.Read
                lbPantallasDisp.Items.Insert(i, dr.Item("Pantalla") & " - " & dr.Item("Nombre"))
                lbPantallasDisp.Sorted = True
                i += 1
            End While
        Catch ex As SqlException
            MsgBox(ex.Number & "-" & ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox(ex.Source & "-" & ex.Message, MsgBoxStyle.Critical)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close() 'cerrar conexion
                    Cnn = Nothing 'destruir objeto
                End If
            End If
        End Try
    End Sub

    Private Sub btnAddDocto_Click(sender As Object, e As EventArgs) Handles btnAddDocto.Click
        If lbPantallasDisp.SelectedIndex <> -1 Then
            lbPantallasAgre.Items.Insert(lbPantallasAgre.Items.Count, lbPantallasDisp.Text) 'Insertamos un elemento al ListBox
            lbPantallasAgre.Sorted = True 'Hace que se ordenen los datos alfabéticamente
            lbPantallasDisp.Items.RemoveAt(lbPantallasDisp.SelectedIndex) 'Removemos un elemento del ListBox
            lbPantallasDisp.Sorted = True 'Hace que se ordenen los datos alfabéticamente
        Else
            MsgBox("¡Elige un elemento de la lista de Pantallas Disponibles!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnAddAllDocto_Click(sender As Object, e As EventArgs) Handles btnAddAllDocto.Click
        Dim i As Integer
        For i = 0 To lbPantallasDisp.Items.Count - 1
            lbPantallasAgre.Items.Insert(lbPantallasAgre.Items.Count, lbPantallasDisp.Items.Item(i)) 'Insertamos un elemento al ListBox
            lbPantallasAgre.Sorted = True 'Hace que se ordenen los datos alfabéticamente
        Next
        lbPantallasDisp.Items.Clear() 'Limpiamos el ListBox
    End Sub

    Private Sub btnRemoveDoc_Click(sender As Object, e As EventArgs) Handles btnRemoveDoc.Click
        If lbPantallasAgre.SelectedIndex <> -1 Then
            lbPantallasDisp.Items.Insert(lbPantallasDisp.Items.Count, lbPantallasAgre.Text) 'Removemos un elemento del ListBox
            lbPantallasDisp.Sorted = True 'Hace que se ordenen los datos alfabéticamente
            lbPantallasAgre.Items.RemoveAt(lbPantallasAgre.SelectedIndex) 'Insertamos un elemento al ListBox
            lbPantallasAgre.Sorted = True 'Hace que se ordenen los datos alfabéticamente
        Else
            MsgBox("¡Elige un elemento de la lista de Pantallas Agregadas!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnRemoveAllDoc_Click(sender As Object, e As EventArgs) Handles btnRemoveAllDoc.Click
        Dim i As Integer
        For i = 0 To lbPantallasAgre.Items.Count - 1
            lbPantallasDisp.Items.Insert(lbPantallasDisp.Items.Count, lbPantallasAgre.Items.Item(i)) 'Insertamos un elemento al ListBox
            lbPantallasDisp.Sorted = True 'Hace que se ordenen los datos alfabéticamente
        Next
        lbPantallasAgre.Items.Clear() 'Limpiamos el ListBox
    End Sub

    Private Sub cboPerfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPerfil.SelectedIndexChanged
        If LlenaCombosStatus Then
            '
            Obtener_CatPantallas(lbPantallasDisp, cstrConnectBDapp) 'Llenamos la lista con los documentos disponibles en el catálogo
            '
            Obten_PantallasPerfil()
        End If
    End Sub

    Private Sub Obten_PantallasPerfil()
        Dim DSet As DataSet
        DSet = PantallasXPerfil(cstrConnectBDapp, cboPerfil.SelectedValue)
        '
        If DSet.Tables.Count > 0 Then
            If DSet.Tables(0).Rows.Count > 0 Then
                Vista_PantallasXPerfil(DSet)
            Else
                lbPantallasDisp.Items.Clear()
                lbPantallasAgre.Items.Clear()
                Obtener_CatPantallas(lbPantallasDisp, cstrConnectBDapp) 'Llenamos la lista con los documentos disponibles en el catálogo
            End If
        End If

    End Sub

    Private Function PantallasXPerfil(ByVal strConexion As String, ByVal iPerfil As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spListaPantallasPerfil", Cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
                '
                param = New SqlParameter("@Perfil", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iPerfil        'asignar pIdCliente
                .Parameters.Add(param)
            End With
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Pantallas")       'llenar dataset
        Catch ex As SqlException
            'sError = ex.Number & "-" & ex.Message
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Source & "-" & ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        GuardarPantallas()
    End Sub

    Private Sub GuardarPantallas()
        Dim XML As String
        XML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & "?>" & vbCrLf
        XML &= "<Perfil>" & vbCrLf
        XML &= Genera_Detalle_XML("Pantallas")
        XML &= "</Perfil>"
        '
        Insertar_Actualizar_Permisos(cboPerfil.SelectedValue, XML)
        'Dim Pantalla As String = ""
        'Dim i As Int16
        'For i = 0 To lbPantallasAgre.Items.Count - 1
        '    If i = 0 Then
        '        Pantalla = CStr(Microsoft.VisualBasic.Mid(lbPantallasAgre.Items.Item(i).ToString, 1, InStr(lbPantallasAgre.Items.Item(i).ToString, "-", CompareMethod.Text) - 7))
        '    Else
        '        Pantalla = CStr(Microsoft.VisualBasic.Mid(lbPantallasAgre.Items.Item(i).ToString, 1, InStr(lbPantallasAgre.Items.Item(i).ToString, "-", CompareMethod.Text) - 7))
        '    End If

        '    'MsgBox(Microsoft.VisualBasic.Left(lbDoctosAgre.Items.Item(0).ToString, 1), MsgBoxStyle.Information)
        'Next
    End Sub

    Private Function Genera_Detalle_XML(ByVal Tabla As String) As String
        Dim str_XML As String = ""
        Dim i As Int16
        Dim campo As String, valor As String
        '
        For i = 0 To lbPantallasAgre.Items.Count - 1
            If i > 0 Then
                str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
            Else
                str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
            End If
            campo = "Codigo"
            valor = CStr(Microsoft.VisualBasic.Mid(lbPantallasAgre.Items.Item(i).ToString, 1, InStr(lbPantallasAgre.Items.Item(i).ToString, "-", CompareMethod.Text) - 2))
            '
            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
            '
            str_XML &= "/>"
        Next
        Return str_XML
    End Function
End Class