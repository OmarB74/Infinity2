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
            If rbCodigoProducto.Checked Then
                sCodigoProducto = txtCodigoProducto.Text
                bRealizarBusquedaCondicionada = True
            End If
            If rbNombreproducto.Checked Then
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
        'If bRealizaBusquedaVentanilla Then
        '    txtCodigoProducto.Visible = False
        'End If
    End Sub

    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscar.Focus()
        End If
    End Sub


    Private Sub rbCodigoProducto_Click(sender As Object, e As EventArgs) Handles rbCodigoProducto.Click
        If rbCodigoProducto.Checked Then
            txtProducto.Enabled = False
            txtCodigoProducto.Enabled = True
            txtCodigoProducto.Select()
            txtCodigoProducto.Focus()
        Else
            txtProducto.Enabled = True
            txtCodigoProducto.Enabled = False
        End If
    End Sub

    Private Sub rbNombreproducto_Click(sender As Object, e As EventArgs) Handles rbNombreproducto.Click
        If rbNombreproducto.Checked Then
            txtProducto.Enabled = True
            txtCodigoProducto.Enabled = False
            txtProducto.Select()
            txtProducto.Focus()
        Else
            txtProducto.Enabled = False
            txtCodigoProducto.Enabled = True
        End If
    End Sub

    Private Sub txtCodigoProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscar.Focus()
        End If
    End Sub
End Class