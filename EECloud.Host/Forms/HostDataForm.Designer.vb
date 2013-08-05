<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial NotInheritable Class HostDataForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.LabelUsername = New System.Windows.Forms.Label()
        Me.TextBoxMySqlConnStr = New System.Windows.Forms.TextBox()
        Me.LabelMySqlConnStr = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Location = New System.Drawing.Point(116, 12)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(156, 20)
        Me.TextBoxUsername.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.Location = New System.Drawing.Point(12, 84)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(260, 23)
        Me.ButtonOk.TabIndex = 2
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'LabelUsername
        '
        Me.LabelUsername.AutoSize = True
        Me.LabelUsername.Location = New System.Drawing.Point(12, 15)
        Me.LabelUsername.Name = "LabelUsername"
        Me.LabelUsername.Size = New System.Drawing.Size(97, 13)
        Me.LabelUsername.TabIndex = 0
        Me.LabelUsername.Text = "In-game username:"
        '
        'TextBoxMySqlConnStr
        '
        Me.TextBoxMySqlConnStr.Location = New System.Drawing.Point(116, 38)
        Me.TextBoxMySqlConnStr.Multiline = True
        Me.TextBoxMySqlConnStr.Name = "TextBoxMySqlConnStr"
        Me.TextBoxMySqlConnStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMySqlConnStr.Size = New System.Drawing.Size(156, 40)
        Me.TextBoxMySqlConnStr.TabIndex = 1
        '
        'LabelMySqlConnStr
        '
        Me.LabelMySqlConnStr.AutoSize = True
        Me.LabelMySqlConnStr.Location = New System.Drawing.Point(12, 41)
        Me.LabelMySqlConnStr.Name = "LabelMySqlConnStr"
        Me.LabelMySqlConnStr.Size = New System.Drawing.Size(98, 26)
        Me.LabelMySqlConnStr.TabIndex = 0
        Me.LabelMySqlConnStr.Text = "MySQL connection" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "string (optional):"
        '
        'HostDataForm
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 119)
        Me.Controls.Add(Me.LabelMySqlConnStr)
        Me.Controls.Add(Me.LabelUsername)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.TextBoxMySqlConnStr)
        Me.Controls.Add(Me.TextBoxUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "HostDataForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Host information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxUsername As System.Windows.Forms.TextBox
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents LabelUsername As System.Windows.Forms.Label
    Friend WithEvents TextBoxMySqlConnStr As System.Windows.Forms.TextBox
    Friend WithEvents LabelMySqlConnStr As System.Windows.Forms.Label
End Class
