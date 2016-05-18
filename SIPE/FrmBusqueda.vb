Public Class FrmBusqueda

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ArmaSentencia()
        '
        Me.Close()
    End Sub
    Private Sub ArmaSentencia()
        Try
            If Trim(txtFolioProveedorCliente.Text) <> "" Then
                iFoliobusqueda = txtFolioProveedorCliente.Text
                bRealizarBusquedaCondicionada = True
            End If
            If Trim(txtNombres.Text) <> "" Then
                sNombresbusqueda = txtNombres.Text
                bRealizarBusquedaCondicionada = True
            End If
            If Trim(txtApellidosProveedor.Text) <> "" Then
                sApellidosbusqueda = txtApellidosProveedor.Text
                bRealizarBusquedaCondicionada = True
            End If
            '
            bRealizarBusqueda = True
         Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmBusqueda_Load(sender As Object, e As EventArgs) Handles Me.Load
        bRealizarBusqueda = False
        iFoliobusqueda = 0
        sNombresbusqueda = ""
        sApellidosbusqueda = ""
        sRazonSocialbusqueda = ""
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        bRealizarBusqueda = False
        '
        Me.Close()
    End Sub
End Class