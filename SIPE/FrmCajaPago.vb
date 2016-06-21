Public Class FrmCajaPago
    Public dImporte As Decimal = 0
    Private Llenacbo As Boolean = False
    Dim objPorcentajeDescuento As New cPorcentajeDescuento
    Private Sub FrmCajaPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtImporte.Text = dImporte
        txtNeto.Text = CDbl(txtImporte.Text)
        Llenacbo = False
        LlenarcboPorcentajeDescuento(cboPorcentajeDescuento, cstrConnectBDapp)
        Llenacbo = True
        txtEfectivo.Select()
        txtEfectivo.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        bRealizarCobro = False
        Me.Close()
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If ValidaCantidades() Then
                txtCambio.Text = Format(CDbl(txtEfectivo.Text) - CDbl(txtNeto.Text), "#,#00.00")
                If CDbl(txtCambio.Text) < 0 Then
                    btnAceptar.Enabled = False
                    MsgBox("Favor de verificar el efectivo y el Cambio", vbInformation + vbOKOnly)
                Else
                    btnAceptar.Enabled = True
                    btnAceptar.Focus()
                End If
            End If
            'btnAceptar_Click(sender, e)
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSymbol(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSeparator(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsWhiteSpace(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsPunctuation(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        e.Handled = Numero(e, txtEfectivo)
        '
        Me.txtEfectivo.Text = Trim(Replace(Me.txtEfectivo.Text, "  ", " "))
        '
        txtEfectivo.Select(txtEfectivo.Text.Length, 0)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidaCantidades Then
            Insertar_NotaVenta(Me)
            '
            bRealizarCobro = True
            Me.Close()
        Else
        End If
    End Sub

    Private Sub rbSI_Click(sender As Object, e As EventArgs) Handles rbSI.Click
        If rbSI.Checked Then
            cboPorcentajeDescuento.Enabled = True
            'txtDescuento.Text = 0.1 * CDbl(txtImporte.Text)
            txtDescuento.Text = CInt(cboPorcentajeDescuento.Text) / 100.0 * CDbl(txtImporte.Text)
            txtNeto.Text = CDbl(txtImporte.Text) - CDbl(txtDescuento.Text)
            'Else
            '    txtDescuento.Text = "0.00"
            '    txtNeto.Text = CDbl(txtImporte.Text)

        End If
    End Sub

    Private Sub rbNO_Click(sender As Object, e As EventArgs) Handles rbNO.Click
        If rbNO.Checked Then
            txtDescuento.Text = "0.00"
            cboPorcentajeDescuento.Enabled = False
            txtNeto.Text = CDbl(txtImporte.Text)
        End If
    End Sub
    Private Function ValidaCantidades() As Boolean
        ValidaCantidades = True
        If Trim(txtEfectivo.Text) = "" Or CDbl(txtEfectivo.Text) = 0 Then
            ValidaCantidades = False
            MsgBox("Favor de checar la cantidad de efectivo", MsgBoxStyle.Information + vbOKOnly)
        End If
    End Function

    Private Sub cboPorcentajeDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPorcentajeDescuento.SelectedIndexChanged
        If Llenacbo Then
            txtDescuento.Text = CInt(cboPorcentajeDescuento.Text) / 100.0 * CDbl(txtImporte.Text)
            txtNeto.Text = CDbl(txtImporte.Text) - CDbl(txtDescuento.Text)
        End If
    End Sub
    Public Sub LlenarcboPorcentajeDescuento(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        objCombobox.DataSource = objPorcentajeDescuento.Obtener_PorcentajeDescuento(strConexion).Tables("PorcentajeDescuento")
        objCombobox.DisplayMember = "Porcentaje"
        objCombobox.ValueMember = "PorcentajeId"
    End Sub
End Class