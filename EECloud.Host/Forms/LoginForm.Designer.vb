<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial NotInheritable Class LoginForm
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
        Me.TextBoxEmail = New System.Windows.Forms.ComboBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxWorldID = New System.Windows.Forms.ComboBox()
        Me.ButtonJoinWorld = New System.Windows.Forms.Button()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.LabelWorldID = New System.Windows.Forms.Label()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.RadioButtonRegular = New System.Windows.Forms.RadioButton()
        Me.RadioButtonFacebook = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(74, 35)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(150, 21)
        Me.TextBoxEmail.TabIndex = 2
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(74, 61)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxPassword.TabIndex = 3
        '
        'TextBoxWorldID
        '
        Me.TextBoxWorldID.Location = New System.Drawing.Point(74, 87)
        Me.TextBoxWorldID.Name = "TextBoxWorldID"
        Me.TextBoxWorldID.Size = New System.Drawing.Size(150, 21)
        Me.TextBoxWorldID.TabIndex = 4
        '
        'ButtonJoinWorld
        '
        Me.ButtonJoinWorld.Location = New System.Drawing.Point(12, 113)
        Me.ButtonJoinWorld.Name = "ButtonJoinWorld"
        Me.ButtonJoinWorld.Size = New System.Drawing.Size(212, 23)
        Me.ButtonJoinWorld.TabIndex = 5
        Me.ButtonJoinWorld.Text = "Join world"
        Me.ButtonJoinWorld.UseVisualStyleBackColor = True
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Location = New System.Drawing.Point(12, 38)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Size = New System.Drawing.Size(38, 13)
        Me.LabelEmail.TabIndex = 0
        Me.LabelEmail.Text = "E-mail:"
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(12, 64)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(56, 13)
        Me.LabelPassword.TabIndex = 0
        Me.LabelPassword.Text = "Password:"
        '
        'LabelWorldID
        '
        Me.LabelWorldID.AutoSize = True
        Me.LabelWorldID.Location = New System.Drawing.Point(12, 90)
        Me.LabelWorldID.Name = "LabelWorldID"
        Me.LabelWorldID.Size = New System.Drawing.Size(52, 13)
        Me.LabelWorldID.TabIndex = 0
        Me.LabelWorldID.Text = "World ID:"
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(12, 14)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(34, 13)
        Me.LabelType.TabIndex = 0
        Me.LabelType.Text = "Type:"
        '
        'RadioButtonRegular
        '
        Me.RadioButtonRegular.AutoSize = True
        Me.RadioButtonRegular.Location = New System.Drawing.Point(74, 12)
        Me.RadioButtonRegular.Name = "RadioButtonRegular"
        Me.RadioButtonRegular.Size = New System.Drawing.Size(62, 17)
        Me.RadioButtonRegular.TabIndex = 0
        Me.RadioButtonRegular.TabStop = True
        Me.RadioButtonRegular.Text = "Regular"
        Me.RadioButtonRegular.UseVisualStyleBackColor = True
        '
        'RadioButtonFacebook
        '
        Me.RadioButtonFacebook.AutoSize = True
        Me.RadioButtonFacebook.Location = New System.Drawing.Point(151, 12)
        Me.RadioButtonFacebook.Name = "RadioButtonFacebook"
        Me.RadioButtonFacebook.Size = New System.Drawing.Size(73, 17)
        Me.RadioButtonFacebook.TabIndex = 1
        Me.RadioButtonFacebook.TabStop = True
        Me.RadioButtonFacebook.Text = "Facebook"
        Me.RadioButtonFacebook.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        Me.AcceptButton = Me.ButtonJoinWorld
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 148)
        Me.Controls.Add(Me.RadioButtonFacebook)
        Me.Controls.Add(Me.RadioButtonRegular)
        Me.Controls.Add(Me.LabelWorldID)
        Me.Controls.Add(Me.LabelPassword)
        Me.Controls.Add(Me.LabelType)
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
    Friend WithEvents TextBoxEmail As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxWorldID As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonJoinWorld As System.Windows.Forms.Button
    Friend WithEvents LabelEmail As System.Windows.Forms.Label
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents LabelWorldID As System.Windows.Forms.Label
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents RadioButtonRegular As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFacebook As System.Windows.Forms.RadioButton
End Class
