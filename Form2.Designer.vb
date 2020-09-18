<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MyTextEdit1 = New SpellCheck.MyTextEdit()
        Me.CustomTextEdit1 = New SpellCheck.CustomTextEdit()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.MyTextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomTextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyTextEdit1
        '
        Me.MyTextEdit1.CapitalizationRule = True
        Me.MyTextEdit1.EnableTabKeyEvent = False
        Me.MyTextEdit1.Location = New System.Drawing.Point(194, 49)
        Me.MyTextEdit1.Name = "MyTextEdit1"
        Me.MyTextEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.LightGray
        Me.MyTextEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MyTextEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.MyTextEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MyTextEdit1.RequiredZeroAsDefaultValue = False
        Me.MyTextEdit1.Size = New System.Drawing.Size(100, 20)
        Me.MyTextEdit1.TabIndex = 1
        '
        'CustomTextEdit1
        '
        Me.CustomTextEdit1.CapitalizationRule = True
        Me.CustomTextEdit1.EnableTabKeyEvent = False
        Me.CustomTextEdit1.Location = New System.Drawing.Point(49, 49)
        Me.CustomTextEdit1.Name = "CustomTextEdit1"
        Me.CustomTextEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.LightGray
        Me.CustomTextEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.CustomTextEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CustomTextEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.CustomTextEdit1.RequiredZeroAsDefaultValue = False
        Me.CustomTextEdit1.Size = New System.Drawing.Size(100, 20)
        Me.CustomTextEdit1.TabIndex = 0
        '
        'RichEditControl1
        '
        Me.RichEditControl1.Location = New System.Drawing.Point(49, 75)
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Options.MailMerge.KeepLastParagraph = False
        Me.RichEditControl1.Size = New System.Drawing.Size(400, 363)
        Me.RichEditControl1.TabIndex = 2
        Me.RichEditControl1.Text = "RichEditControl1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(355, 444)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 533)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichEditControl1)
        Me.Controls.Add(Me.MyTextEdit1)
        Me.Controls.Add(Me.CustomTextEdit1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.MyTextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomTextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomTextEdit1 As SpellCheck.CustomTextEdit
    Friend WithEvents MyTextEdit1 As SpellCheck.MyTextEdit
    Friend WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
