<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportarPrecios
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
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListaDatos = New System.Windows.Forms.ListView()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(392, 56)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(71, 34)
        Me.btnImportar.TabIndex = 2
        Me.btnImportar.Text = "&Abrir"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(500, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 34)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Importar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRutaArchivo.Location = New System.Drawing.Point(130, 64)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.ReadOnly = True
        Me.txtRutaArchivo.Size = New System.Drawing.Size(256, 20)
        Me.txtRutaArchivo.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListaDatos)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(581, 215)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Listado"
        '
        'ListaDatos
        '
        Me.ListaDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListaDatos.Location = New System.Drawing.Point(9, 17)
        Me.ListaDatos.Name = "ListaDatos"
        Me.ListaDatos.Size = New System.Drawing.Size(566, 182)
        Me.ListaDatos.TabIndex = 1
        Me.ListaDatos.UseCompatibleStateImageBehavior = False
        '
        'FrmImportarPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 383)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnImportar)
        Me.Name = "FrmImportarPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Precios"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRutaArchivo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListaDatos As System.Windows.Forms.ListView
End Class
