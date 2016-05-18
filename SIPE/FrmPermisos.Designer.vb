<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermisos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPerfil = New System.Windows.Forms.ComboBox()
        Me.btnRemoveAllDoc = New System.Windows.Forms.Button()
        Me.btnAddAllDocto = New System.Windows.Forms.Button()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.btnRemoveDoc = New System.Windows.Forms.Button()
        Me.btnAddDocto = New System.Windows.Forms.Button()
        Me.lbPantallasAgre = New System.Windows.Forms.ListBox()
        Me.lbPantallasDisp = New System.Windows.Forms.ListBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Perfil"
        '
        'cboPerfil
        '
        Me.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerfil.FormattingEnabled = True
        Me.cboPerfil.Location = New System.Drawing.Point(200, 55)
        Me.cboPerfil.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPerfil.Name = "cboPerfil"
        Me.cboPerfil.Size = New System.Drawing.Size(289, 28)
        Me.cboPerfil.TabIndex = 1
        '
        'btnRemoveAllDoc
        '
        Me.btnRemoveAllDoc.Location = New System.Drawing.Point(327, 323)
        Me.btnRemoveAllDoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRemoveAllDoc.Name = "btnRemoveAllDoc"
        Me.btnRemoveAllDoc.Size = New System.Drawing.Size(86, 35)
        Me.btnRemoveAllDoc.TabIndex = 129
        Me.btnRemoveAllDoc.Text = "<<"
        Me.btnRemoveAllDoc.UseVisualStyleBackColor = True
        '
        'btnAddAllDocto
        '
        Me.btnAddAllDocto.Location = New System.Drawing.Point(327, 240)
        Me.btnAddAllDocto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddAllDocto.Name = "btnAddAllDocto"
        Me.btnAddAllDocto.Size = New System.Drawing.Size(86, 35)
        Me.btnAddAllDocto.TabIndex = 127
        Me.btnAddAllDocto.Text = ">>"
        Me.btnAddAllDocto.UseVisualStyleBackColor = True
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(422, 132)
        Me.Label83.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(156, 20)
        Me.Label83.TabIndex = 124
        Me.Label83.Text = "Pantallas Agregadas"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(22, 132)
        Me.Label81.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(160, 20)
        Me.Label81.TabIndex = 123
        Me.Label81.Text = "Pantallas Disponibles"
        '
        'btnRemoveDoc
        '
        Me.btnRemoveDoc.Location = New System.Drawing.Point(327, 283)
        Me.btnRemoveDoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRemoveDoc.Name = "btnRemoveDoc"
        Me.btnRemoveDoc.Size = New System.Drawing.Size(86, 35)
        Me.btnRemoveDoc.TabIndex = 128
        Me.btnRemoveDoc.Text = "<"
        Me.btnRemoveDoc.UseVisualStyleBackColor = True
        '
        'btnAddDocto
        '
        Me.btnAddDocto.Location = New System.Drawing.Point(327, 200)
        Me.btnAddDocto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddDocto.Name = "btnAddDocto"
        Me.btnAddDocto.Size = New System.Drawing.Size(86, 35)
        Me.btnAddDocto.TabIndex = 126
        Me.btnAddDocto.Text = ">"
        Me.btnAddDocto.UseVisualStyleBackColor = True
        '
        'lbPantallasAgre
        '
        Me.lbPantallasAgre.FormattingEnabled = True
        Me.lbPantallasAgre.ItemHeight = 20
        Me.lbPantallasAgre.Location = New System.Drawing.Point(422, 162)
        Me.lbPantallasAgre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbPantallasAgre.Name = "lbPantallasAgre"
        Me.lbPantallasAgre.Size = New System.Drawing.Size(294, 244)
        Me.lbPantallasAgre.TabIndex = 130
        '
        'lbPantallasDisp
        '
        Me.lbPantallasDisp.FormattingEnabled = True
        Me.lbPantallasDisp.ItemHeight = 20
        Me.lbPantallasDisp.Location = New System.Drawing.Point(22, 162)
        Me.lbPantallasDisp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lbPantallasDisp.Name = "lbPantallasDisp"
        Me.lbPantallasDisp.Size = New System.Drawing.Size(294, 244)
        Me.lbPantallasDisp.TabIndex = 125
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(544, 43)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(172, 63)
        Me.BtnGuardar.TabIndex = 131
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'FrmPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 435)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnRemoveAllDoc)
        Me.Controls.Add(Me.btnAddAllDocto)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.btnRemoveDoc)
        Me.Controls.Add(Me.btnAddDocto)
        Me.Controls.Add(Me.lbPantallasAgre)
        Me.Controls.Add(Me.lbPantallasDisp)
        Me.Controls.Add(Me.cboPerfil)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permisos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents btnRemoveAllDoc As System.Windows.Forms.Button
    Friend WithEvents btnAddAllDocto As System.Windows.Forms.Button
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveDoc As System.Windows.Forms.Button
    Friend WithEvents btnAddDocto As System.Windows.Forms.Button
    Friend WithEvents lbPantallasAgre As System.Windows.Forms.ListBox
    Friend WithEvents lbPantallasDisp As System.Windows.Forms.ListBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
End Class
