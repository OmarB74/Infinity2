Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmListaProductoPrecio
    Dim objProducto As New cProductos
    Dim objMedida As New cMedida
    Dim objPeso As New cPeso
    Dim objTipoListas As New cTipoListas
    Dim objABMLPP As New clistaProductoPrecio
    Dim objTipoRelleno As New cTipoRelleno
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmListaProductoPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiaCampos()
    End Sub
    Private Sub LimpiaCampos()
        Me.txtIdentificadorId.Text = "0"
        Me.txtCodigoBarras.Text = ""
        Me.txtPrecio.Text = "0.00"
        '
        LlenarComboProductos(cboProducto, cstrConnectBDapp) 'Llena el combo
        LlenarComboMedida(cboMedida, cstrConnectBDapp) 'Llena el combo
        LlenarComboPeso(cboPeso, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoListas(cboListaPrecios, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoRelleno(cboTipoRelleno, cstrConnectBDapp) 'Llena el combo
    End Sub
    '
    Private Sub LlenarComboTipoRelleno(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objTipoRelleno.Obtener_TipoRelleno(strConexion).Tables("TipoRelleno")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "TipoRellenoId"
    End Sub
    '
    Private Sub LlenarComboProductos(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objProducto.Obtener_Producto(strConexion).Tables("ProductosPerfumes")
        objCombobox.DisplayMember = "Nombre"
        objCombobox.ValueMember = "Productoid"
    End Sub
    '
    Private Sub LlenarComboMedida(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objMedida.Obtener_Medidas(strConexion).Tables("Medidas")
        objCombobox.DisplayMember = "Contenido"
        objCombobox.ValueMember = "MedidaId"
    End Sub
    '
    Private Sub LlenarComboPeso(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objPeso.Obtener_Peso(strConexion).Tables("Peso")
        objCombobox.DisplayMember = "Peso"
        objCombobox.ValueMember = "PesoId"
    End Sub
    '
    Private Sub LlenarComboTipoListas(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objTipoListas.Obtener_NombreListas(strConexion).Tables("TipoListas")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "ListaId"
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIdentificadorId.Text = "" Then
            txtIdentificadorId.Text = "0"
        End If
        objABMLPP.Insertar_Actualizar_LPP(Me, IIf(CInt(txtIdentificadorId.Text) = 0, 1, 3), txtIdentificadorId.Text)
        '
        LimpiaCampos()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frmbusqueda As New FrmBusquedaListaProductoPrecio
        frmbusqueda.ShowDialog()
        If bRealizarBusqueda Then
            '
            Dim frmELPP As New FrmEncontradosListaProductoPrecio

            frmELPP.ShowDialog()
            If iLPPBusqueda > 0 Then
                CargaDatos(Me)
            End If
        End If
    End Sub

    Public Sub CargaDatos(ByVal ListaProductoPrecio As FrmListaProductoPrecio)
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spDatosIndListaProductoPrecio"
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@IdentificadorId", iLPPBusqueda))
            '
            With ListaProductoPrecio
                '
                Dim read As SqlDataReader = cmd.ExecuteReader()
                If read.HasRows Then
                    While read.Read
                        .txtIdentificadorId.Text = iLPPBusqueda
                        .txtCodigoBarras.Text = CStr(read(1))
                        .txtPrecio.Text = CStr(read(2))
                        .cboProducto.SelectedValue = CInt(read(3))
                        .cboMedida.SelectedValue = CInt(read(4))
                        .cboPeso.SelectedValue = CInt(read(5))
                        .cboListaPrecios.SelectedValue = CInt(read(6))
                    End While
                End If
            End With
            '
            cmd.Dispose()
            '
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

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Or e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        If txtPrecio.Text.Length = 0 Then
            txtPrecio.Text = "0.00"
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub
End Class