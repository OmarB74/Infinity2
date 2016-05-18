<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFoto
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.VideoSourcePlayer1 = New AForge.Controls.VideoSourcePlayer()
        Me.cboDispositivos = New System.Windows.Forms.ComboBox()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.btnFoto = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.VideoSourcePlayer1)
        Me.GroupBox1.Location = New System.Drawing.Point(400, 18)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(456, 480)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "WebCam"
        '
        'VideoSourcePlayer1
        '
        Me.VideoSourcePlayer1.Location = New System.Drawing.Point(24, 29)
        Me.VideoSourcePlayer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VideoSourcePlayer1.Name = "VideoSourcePlayer1"
        Me.VideoSourcePlayer1.Size = New System.Drawing.Size(423, 442)
        Me.VideoSourcePlayer1.TabIndex = 0
        Me.VideoSourcePlayer1.Text = "VideoSourcePlayer1"
        Me.VideoSourcePlayer1.VideoSource = Nothing
        '
        'cboDispositivos
        '
        Me.cboDispositivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispositivos.FormattingEnabled = True
        Me.cboDispositivos.Location = New System.Drawing.Point(52, 48)
        Me.cboDispositivos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboDispositivos.Name = "cboDispositivos"
        Me.cboDispositivos.Size = New System.Drawing.Size(277, 28)
        Me.cboDispositivos.TabIndex = 1
        '
        'btnIniciar
        '
        Me.btnIniciar.Location = New System.Drawing.Point(108, 115)
        Me.btnIniciar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(164, 63)
        Me.btnIniciar.TabIndex = 2
        Me.btnIniciar.Text = "&Iniciar"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'btnDetener
        '
        Me.btnDetener.Location = New System.Drawing.Point(108, 188)
        Me.btnDetener.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(164, 63)
        Me.btnDetener.TabIndex = 3
        Me.btnDetener.Text = "&Detener"
        Me.btnDetener.UseVisualStyleBackColor = True
        '
        'btnFoto
        '
        Me.btnFoto.Location = New System.Drawing.Point(108, 260)
        Me.btnFoto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnFoto.Name = "btnFoto"
        Me.btnFoto.Size = New System.Drawing.Size(164, 63)
        Me.btnFoto.TabIndex = 4
        Me.btnFoto.Text = "&Foto"
        Me.btnFoto.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(880, 23)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(456, 480)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imagen Capturada"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(9, 31)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(438, 435)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(108, 332)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(164, 63)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'FrmFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 522)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnFoto)
        Me.Controls.Add(Me.btnDetener)
        Me.Controls.Add(Me.btnIniciar)
        Me.Controls.Add(Me.cboDispositivos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Foto Proveedor Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents VideoSourcePlayer1 As AForge.Controls.VideoSourcePlayer
    Friend WithEvents cboDispositivos As System.Windows.Forms.ComboBox
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents btnDetener As System.Windows.Forms.Button
    Friend WithEvents btnFoto As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
