Public Class FrmBusquedaPM

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        bRealizarBusqueda = False
        '
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ArmaSentencia()
        '
        Me.Close()
    End Sub
    Private Sub ArmaSentencia()
        Try
            If Trim(txtFolioProveedorCliente.Text) <> "" Then
                iFoliobusqueda = txtFolioProveedorCliente.Text
            End If
            If Trim(txtRazonSocial.Text) <> "" Then
                sRazonSocialbusqueda = txtRazonSocial.Text
            End If
            '
            bRealizarBusqueda = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmBusquedaPM_Load(sender As Object, e As EventArgs) Handles Me.Load
        bRealizarBusqueda = False
        iFoliobusqueda = 0
        sNombresbusqueda = ""
        sApellidosbusqueda = ""
        sRazonSocialbusqueda = ""
    End Sub
End Class