<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.TextBoxWorldID = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.ButtonJoinWorld = New System.Windows.Forms.Button()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.LabelWorldID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(74, 12)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxEmail.TabIndex = 0
        '
        'TextBoxWorldID
        '
        Me.TextBoxWorldID.Location = New System.Drawing.Point(74, 64)
        Me.TextBoxWorldID.Name = "TextBoxWorldID"
        Me.TextBoxWorldID.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxWorldID.TabIndex = 2
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(74, 38)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxPassword.TabIndex = 1
        '
        'ButtonJoinWorld
        '
        Me.ButtonJoinWorld.Location = New System.Drawing.Point(12, 90)
        Me.ButtonJoinWorld.Name = "ButtonJoinWorld"
        Me.ButtonJoinWorld.Size = New System.Drawing.Size(212, 23)
        Me.ButtonJoinWorld.TabIndex = 3
        Me.ButtonJoinWorld.Text = "Join world"
        Me.ButtonJoinWorld.UseVisualStyleBackColor = True
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Location = New System.Drawing.Point(12, 15)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Size = New System.Drawing.Size(38, 13)
        Me.LabelEmail.TabIndex = 0
        Me.LabelEmail.Text = "E-mail:"
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(12, 41)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(56, 13)
        Me.LabelPassword.TabIndex = 0
        Me.LabelPassword.Text = "Password:"
        '
        'LabelWorldID
        '
        Me.LabelWorldID.AutoSize = True
        Me.LabelWorldID.Location = New System.Drawing.Point(12, 67)
        Me.LabelWorldID.Name = "LabelWorldID"
        Me.LabelWorldID.Size = New System.Drawing.Size(52, 13)
        Me.LabelWorldID.TabIndex = 0
        Me.LabelWorldID.Text = "World ID:"
        '
        'LoginForm
        '
        Me.AcceptButton = Me.ButtonJoinWorld
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 125)
        Me.Controls.Add(Me.LabelWorldID)
        Me.Controls.Add(Me.LabelPassword)
        Me.Controls.Add(Me.LabelEmail)
        Me.Controls.Add(Me.ButtonJoinWorld)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxWorldID)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Join world"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxWorldID As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents ButtonJoinWorld As System.Windows.Forms.Button
    Friend WithEvents LabelEmail As System.Windows.Forms.Label
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents LabelWorldID As System.Windows.Forms.Label
End Class
