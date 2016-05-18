Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmFotoProveedorCliente
    Public iProveedorCliente As Integer = 0
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub FrmFotoProveedorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaFotoProveedorCliente()
    End Sub
    Private Sub CargaFotoProveedorCliente()
        Try
            Cnn = New SqlConnection(cstrConnectBDapp)
            Cnn.Open()
            cmd = New SqlCommand("select Foto from Proveedor_Cliente where ProveedorClienteId=" & iProveedorCliente & "", Cnn)
            cmd.CommandType = CommandType.Text
            With Me
                Dim resultado As SqlDataReader = cmd.ExecuteReader
                While resultado.Read
                    If .PictureBox1.Image Is Nothing Then
                    Else
                        .PictureBox1.Image = Nothing
                        .PictureBox1.SizeMode = Nothing
                    End If
                    If resultado(0).ToString <> "" Then
                        .PictureBox1.Image = New Bitmap(New MemoryStream(CType(resultado(0), Byte())))

                        .PictureBox1.AutoSize = True
                        .PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    End If
                    '
                End While
            End With

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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class