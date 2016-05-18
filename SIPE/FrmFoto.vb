Option Explicit On

Imports System.Data.SqlClient
Imports System.IO
Imports AForge.Video.DirectShow
Public Class FrmFoto
    Private Dispositivos As FilterInfoCollection
    Private FuenteVideo As VideoCaptureDevice
    Public iProveedorClienteId As Integer = 0
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter

    Private Sub FrmFoto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        VideoSourcePlayer1.SignalToStop()
    End Sub

    Private Sub FrmFoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
        Dispositivos = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        'If Dispositivos <> Nothing Then
        For Each x As FilterInfo In Dispositivos
            cboDispositivos.Items.Add(x.Name)
        Next
        cboDispositivos.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MsgBox("No se cuenta con dispositivos conectados")
        End Try
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        FuenteVideo = New VideoCaptureDevice(Dispositivos(cboDispositivos.SelectedIndex).MonikerString)
        VideoSourcePlayer1.VideoSource = FuenteVideo
        VideoSourcePlayer1.Start()
    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        VideoSourcePlayer1.SignalToStop()
    End Sub

    Private Sub btnFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        Dim sf As New SaveFileDialog
        sf.Filter = "Imagenes JPG | *.jpg"
        sf.ShowDialog()
        'Asegurar ruta
        If sf.FileName IsNot Nothing And sf.FileName.Length > 0 Then
            Dim img As Bitmap = VideoSourcePlayer1.GetCurrentVideoFrame
            'Guardar imagen
            img.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
            'Liberar
            img.Dispose()
            '
            Foto(sf.FileName)
        End If
    End Sub
    Private Sub Foto(Ruta As String)
        Try
            If PictureBox1.Image Is Nothing Then
            Else
                PictureBox1.Image = Nothing
                PictureBox1.SizeMode = Nothing
            End If

            PictureBox1.AutoSize = True
            PictureBox1.Image = System.Drawing.Image.FromFile(Ruta)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Agregar_Foto(Me)
    End Sub
    Private Sub Agregar_Foto(ByVal objeto As FrmFoto)
        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            Transaccion = Cnn.BeginTransaction
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spGuardaFoto_ProveedorCliente"
            cmd.CommandType = CommandType.StoredProcedure
            With objeto

                cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", iProveedorClienteId))
                If .PictureBox1.Image IsNot Nothing Then
                    Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream()
                    .PictureBox1.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Png)

                    cmd.Parameters.Add(New SqlClient.SqlParameter("@Foto", MS.GetBuffer()))
                End If
            End With
            '
            cmd.Transaction = Transaccion
            cmd.ExecuteNonQuery()
            MsgBox("Foto registrada con exito")
            '
            Transaccion.Commit()
            '
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Transaccion.Rollback()
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Sub
End Class