Option Explicit On
Public Class FrmSeleccionReporteProveedorCliente
    Private iTipo As Integer = 0
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim frmrptroveedorCliente As FrmReporteProveedoresClientes = Nothing
        frmrptroveedorCliente = New FrmReporteProveedoresClientes
        iTipo = IIf(cboTipoProveedorCliente.SelectedIndex = 0, 1, 2)

        frmrptroveedorCliente.iTipoPersonaProveedorCliente = iTipo
        frmrptroveedorCliente.iTipoProveedorCliente = IIf(rbProveedor.Checked, 1, 2)
        frmrptroveedorCliente.ShowDialog()
    End Sub

    Private Sub FrmSeleccionReporteProveedorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboTipoProveedorCliente.SelectedIndex = 0
    End Sub
End Class