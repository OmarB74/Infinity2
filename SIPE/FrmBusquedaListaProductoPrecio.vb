Public Class FrmBusquedaListaProductoPrecio
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
            If Trim(txtCodigodeBarras.Text) <> "" Then
                sCodigodeBarras = txtCodigodeBarras.Text
                bRealizarBusquedaCondicionada = True
            End If
            If Trim(txtProducto.Text) <> "" Then
                sProducto = txtProducto.Text
                bRealizarBusquedaCondicionada = True
            End If
            '
            bRealizarBusqueda = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmBusquedaListaProductoPrecio_Load1(sender As Object, e As EventArgs) Handles Me.Load
        sProducto = ""
        '
        If bRealizaBusquedaVentanilla Then
            Label5.Visible = False
            txtCodigodeBarras.Visible = False
            Panel1.Visible = True
        End If
    End Sub

    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscar.Focus()
        End If
    End Sub
End Class