<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsuario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim NombreLabel As System.Windows.Forms.Label
        Dim UserIdLabel As System.Windows.Forms.Label
        Dim LoginLabel As System.Windows.Forms.Label
        Dim PasswordLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuario))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.chkSupervisor = New System.Windows.Forms.CheckBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.chkAdministrador = New System.Windows.Forms.CheckBox()
        Me.cboPerfil = New System.Windows.Forms.ComboBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.TxtUserId = New System.Windows.Forms.TextBox()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        NombreLabel = New System.Windows.Forms.Label()
        UserIdLabel = New System.Windows.Forms.Label()
        LoginLabel = New System.Windows.Forms.Label()
        PasswordLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(9, 80)
        NombreLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(69, 20)
        NombreLabel.TabIndex = 5
        NombreLabel.Text = "Nombre:"
        '
        'UserIdLabel
        '
        UserIdLabel.AutoSize = True
        UserIdLabel.Location = New System.Drawing.Point(458, 38)
        UserIdLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        UserIdLabel.Name = "UserIdLabel"
        UserIdLabel.Size = New System.Drawing.Size(65, 20)
        UserIdLabel.TabIndex = 1
        UserIdLabel.Text = "User Id:"
        UserIdLabel.Visible = False
        '
        'LoginLabel
        '
        LoginLabel.AutoSize = True
        LoginLabel.Location = New System.Drawing.Point(9, 38)
        LoginLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        LoginLabel.Name = "LoginLabel"
        LoginLabel.Size = New System.Drawing.Size(68, 20)
        LoginLabel.TabIndex = 3
        LoginLabel.Text = "Usuario:"
        '
        'PasswordLabel
        '
        PasswordLabel.AutoSize = True
        PasswordLabel.Location = New System.Drawing.Point(6, 120)
        PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New System.Drawing.Size(96, 20)
        PasswordLabel.TabIndex = 51
        PasswordLabel.Text = "Contraseña:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(9, 163)
        Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(48, 20)
        Label1.TabIndex = 53
        Label1.Text = "Perfil:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(366, 120)
        Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(68, 20)
        Label2.TabIndex = 55
        Label2.Text = "Estatus:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 204)
        Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(75, 20)
        Label3.TabIndex = 58
        Label3.Text = "Sucursal:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSucursal)
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Me.chkSupervisor)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Me.chkAdministrador)
        Me.GroupBox1.Controls.Add(Me.cboPerfil)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPassword)
        Me.GroupBox1.Controls.Add(PasswordLabel)
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.TxtUserId)
        Me.GroupBox1.Controls.Add(NombreLabel)
        Me.GroupBox1.Controls.Add(UserIdLabel)
        Me.GroupBox1.Controls.Add(Me.TxtLogin)
        Me.GroupBox1.Controls.Add(LoginLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 18)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(720, 310)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuario"
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(99, 196)
        Me.cboSucursal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(348, 28)
        Me.cboSucursal.TabIndex = 59
        '
        'chkSupervisor
        '
        Me.chkSupervisor.AutoSize = True
        Me.chkSupervisor.Location = New System.Drawing.Point(99, 276)
        Me.chkSupervisor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkSupervisor.Name = "chkSupervisor"
        Me.chkSupervisor.Size = New System.Drawing.Size(103, 24)
        Me.chkSupervisor.TabIndex = 57
        Me.chkSupervisor.Text = "Supervisor"
        Me.chkSupervisor.UseVisualStyleBackColor = True
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(459, 122)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(49, 20)
        Me.LblEstatus.TabIndex = 56
        Me.LblEstatus.Text = "ALTA"
        '
        'chkAdministrador
        '
        Me.chkAdministrador.AutoSize = True
        Me.chkAdministrador.Location = New System.Drawing.Point(225, 276)
        Me.chkAdministrador.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkAdministrador.Name = "chkAdministrador"
        Me.chkAdministrador.Size = New System.Drawing.Size(126, 24)
        Me.chkAdministrador.TabIndex = 54
        Me.chkAdministrador.Text = "Administrador"
        Me.chkAdministrador.UseVisualStyleBackColor = True
        Me.chkAdministrador.Visible = False
        '
        'cboPerfil
        '
        Me.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerfil.FormattingEnabled = True
        Me.cboPerfil.Location = New System.Drawing.Point(99, 158)
        Me.cboPerfil.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPerfil.Name = "cboPerfil"
        Me.cboPerfil.Size = New System.Drawing.Size(348, 28)
        Me.cboPerfil.TabIndex = 3
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(99, 115)
        Me.TxtPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPassword.MaxLength = 8
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(174, 26)
        Me.TxtPassword.TabIndex = 2
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(99, 75)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(594, 26)
        Me.TxtNombre.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(412, 31)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(36, 35)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'TxtUserId
        '
        Me.TxtUserId.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUserId.Location = New System.Drawing.Point(532, 34)
        Me.TxtUserId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtUserId.Name = "TxtUserId"
        Me.TxtUserId.ReadOnly = True
        Me.TxtUserId.Size = New System.Drawing.Size(124, 26)
        Me.TxtUserId.TabIndex = 1
        Me.TxtUserId.Visible = False
        '
        'TxtLogin
        '
        Me.TxtLogin.Location = New System.Drawing.Point(99, 34)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(302, 26)
        Me.TxtLogin.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(202, 338)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 51)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(382, 338)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(150, 51)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(562, 338)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(150, 51)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(22, 338)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(150, 51)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'FrmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 393)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtUserId As System.Windows.Forms.TextBox
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cboPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents chkAdministrador As System.Windows.Forms.CheckBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents chkSupervisor As System.Windows.Forms.CheckBox
    Friend WithEvents cboSucursal As ComboBox
End Class
