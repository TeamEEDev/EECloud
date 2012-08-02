<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicenseForm
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
        Me.TextBoxUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxKey = New System.Windows.Forms.TextBox()
        Me.ButtonJoinWorld = New System.Windows.Forms.Button()
        Me.LabelUsername = New System.Windows.Forms.Label()
        Me.LabelKey = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Location = New System.Drawing.Point(76, 12)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxUsername.TabIndex = 0
        '
        'TextBoxKey
        '
        Me.TextBoxKey.Location = New System.Drawing.Point(76, 38)
        Me.TextBoxKey.Name = "TextBoxKey"
        Me.TextBoxKey.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxKey.TabIndex = 1
        '
        'ButtonJoinWorld
        '
        Me.ButtonJoinWorld.Location = New System.Drawing.Point(12, 64)
        Me.ButtonJoinWorld.Name = "ButtonJoinWorld"
        Me.ButtonJoinWorld.Size = New System.Drawing.Size(214, 23)
        Me.ButtonJoinWorld.TabIndex = 2
        Me.ButtonJoinWorld.Text = "Connect"
        Me.ButtonJoinWorld.UseVisualStyleBackColor = True
        '
        'LabelUsername
        '
        Me.LabelUsername.AutoSize = True
        Me.LabelUsername.Location = New System.Drawing.Point(12, 15)
        Me.LabelUsername.Name = "LabelUsername"
        Me.LabelUsername.Size = New System.Drawing.Size(58, 13)
        Me.LabelUsername.TabIndex = 0
        Me.LabelUsername.Text = "Username:"
        '
        'LabelKey
        '
        Me.LabelKey.AutoSize = True
        Me.LabelKey.Location = New System.Drawing.Point(12, 41)
        Me.LabelKey.Name = "LabelKey"
        Me.LabelKey.Size = New System.Drawing.Size(28, 13)
        Me.LabelKey.TabIndex = 0
        Me.LabelKey.Text = "Key:"
        '
        'LicenseForm
        '
        Me.AcceptButton = Me.ButtonJoinWorld
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 99)
        Me.Controls.Add(Me.LabelKey)
        Me.Controls.Add(Me.LabelUsername)
        Me.Controls.Add(Me.ButtonJoinWorld)
        Me.Controls.Add(Me.TextBoxKey)
        Me.Controls.Add(Me.TextBoxUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "LicenseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "License information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKey As System.Windows.Forms.TextBox
    Friend WithEvents ButtonJoinWorld As System.Windows.Forms.Button
    Friend WithEvents LabelUsername As System.Windows.Forms.Label
    Friend WithEvents LabelKey As System.Windows.Forms.Label
End Class
