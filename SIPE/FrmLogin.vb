Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Xml
Public Class FrmLogin
    Private CombosLlenos As Boolean = False

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        ' Variables para la consulta.
        Dim lSentencia As String = ""
        Dim ValPass As Integer = 0
        Dim ValSesion As Integer = 0
        Dim TempPassword As String
        '
        Dim cnnExecAL As SqlConnection
        Try
            '
            ' Pon el cursor en espera
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            '
            'Primero si no tiene Login ni Password no te conectes
            If Trim(Me.txtusername.Text) = "" Then MsgBox("NECESITA TECLEAR SU CLAVE DE USUARIO", MsgBoxStyle.Information, "Informacion") : Me.txtusername.Focus() : Me.Cursor = System.Windows.Forms.Cursors.Default : Exit Sub
            If Trim(Me.txtPassword.Text) = "" Then MsgBox("NECESITA TECLEAR SU CONTRASEÑA/PASSWORD", MsgBoxStyle.Information, "Informacion") : Me.txtPassword.Focus() : Me.Cursor = System.Windows.Forms.Cursors.Default : Exit Sub
            '
            'Evalua el nombre del servidor si no tiene sal. 
            If Me.cboServer.Text = "" Then
                MsgBox("SELECCIONE UN SERVIDOR POR FAVOR", MsgBoxStyle.Information, "SELECCIONA SERVIDOR")
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            '
            ' Verifica q el combo de empresa tenga seleccionado un item
            'If IsNothing(Me.CmbEmpresas.SelectedItem) Then
            '    MsgBox("SELECCIONE UNA EMPRESA POR FAVOR", MsgBoxStyle.Information, "SELECCIONA EMPRESA")
            '    Me.Cursor = System.Windows.Forms.Cursors.Default
            '    Exit Sub
            'End If
            '
            'obtener el string de conexion
            cstrConnectBDapp = GetcstrConnectBDapp(cboServer.Text)
            cnnExecAL = New SqlConnection(cstrConnectBDapp)
            'Primero comparar sesion usuario
            lSentencia = "SELECT count(*) From Usuarios where Nombre_Usuario = '" & Me.txtusername.Text & "'"
            Dim cmdSesion As New SqlCommand(lSentencia, cnnExecAL)
            Try
                cnnExecAL.Open()
                Dim readerInfo As SqlDataReader = cmdSesion.ExecuteReader()
                While readerInfo.Read
                    ValSesion = RTrim((readerInfo.GetValue(0)))
                End While
                readerInfo.Close()
            Catch
                MsgBox("ERROR : " & Err.Description.ToString & " no. " & Err.Number.ToString)
            Finally
                cnnExecAL.Close()
            End Try
            If ValSesion = 0 Then
                MsgBox("SU SESION NO ES CORRECTA", MsgBoxStyle.Information, "Informacion")
                Me.txtusername.SelectAll()
                Me.txtusername.Focus()
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            '
            ' Se va a conectar a la base al servidor establecido y login establecido para la aplicacion            
            lSentencia = ""
            '
            lSentencia = "SELECT Pwd From Usuarios where Nombre_Usuario = '" & Me.txtusername.Text & "'"
            '
            Dim cmdInfo As New SqlCommand(lSentencia, cnnExecAL)
            Try
                cnnExecAL.Open()
                Dim readerInfo As SqlDataReader = cmdInfo.ExecuteReader()
                While readerInfo.Read
                    TempPassword = EncryptionDecryption.Decrypt(RTrim((readerInfo.GetValue(0))), Key)
                    If TempPassword = Me.txtPassword.Text Then
                        ValPass = 1
                    End If
                End While
                readerInfo.Close()
            Catch
                MsgBox("ERROR : " & Err.Description.ToString & " no. " & Err.Number.ToString)
            Finally
                cnnExecAL.Close()
            End Try
            '
            If ValPass = 0 Then
                MsgBox("SU PASSWORD ESTA INCORRECTO, VUELVA A INTENTARLO", MsgBoxStyle.Information, "Informacion")
                Me.txtPassword.Focus()
                cnnExecAL.Close()
                Exit Sub
            End If
            'Obtiene datos de usuario 
            lSentencia = "Exec spAD_RevisaUsuario 1,'" & Me.txtusername.Text & "' "
            '
            Dim cmdInfo2 As New SqlCommand(lSentencia, cnnExecAL)
            Try
                cnnExecAL.Open()
                Dim readerInfo As SqlDataReader = cmdInfo2.ExecuteReader()
                While readerInfo.Read
                    '
                    iRenovar = readerInfo.GetInt32(1) 'Agregado 
                    NombreUsuario = RTrim((readerInfo.GetValue(2)))
                    iUsuario = RTrim((readerInfo.GetValue(3)))
                    iProfileId = readerInfo.GetValue(4)
                    sFechaSistema = FormatDateTime(readerInfo.GetValue(6), DateFormat.ShortDate)
                    sSucursal = RTrim((readerInfo.GetValue(8)))
                End While
                readerInfo.Close()
            Catch
                MsgBox("ERROR : " & Err.Description.ToString, MsgBoxStyle.Critical)
                Me.txtPassword.SelectAll()
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Finally
                cnnExecAL.Close()
            End Try
            '
            'Cierra la conexion si todo esta bien.
            cnnExecAL.Close()
            'Pon el cursor en default
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Dim frmPrincipal As New FrmMenuPrincipal
            frmPrincipal.Show()

            ' Cierra la pantalla
            Me.Close()
        Catch
            cnnExecAL.Close()
            MsgBox(Err.Number.ToString & " - " & Err.Description.ToString, MsgBoxStyle.Exclamation, "Error al conectar")
            Err.Clear()
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FrmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtusername.Focus()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CombosLlenos = False
        Me.cboServer.Items.Clear()
        Me.cboServer.Items.Add("PRODUCCION")
        cboServer.SelectedIndex = 0
        CombosLlenos = True
        Me.ActiveControl = Me.Controls(8)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Application.ExitThread()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnEntrar.Focus()
        End If
    End Sub

    Private Sub txtusername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPassword.Focus()
        End If
    End Sub
End Class