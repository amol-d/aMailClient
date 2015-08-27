<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LogIn
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LblDisplayName As System.Windows.Forms.Label
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents TxtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogIn))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LblDisplayName = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.TxtDisplayName = New System.Windows.Forms.TextBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.BtnSubmitAccount = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TxtLastName = New System.Windows.Forms.TextBox()
        Me.TxtFirstName = New System.Windows.Forms.TextBox()
        Me.LblLastName = New System.Windows.Forms.Label()
        Me.LblFirstName = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.LblPassword = New System.Windows.Forms.Label()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(-2, 77)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(370, 193)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'LblDisplayName
        '
        Me.LblDisplayName.Location = New System.Drawing.Point(161, 132)
        Me.LblDisplayName.Name = "LblDisplayName"
        Me.LblDisplayName.Size = New System.Drawing.Size(220, 23)
        Me.LblDisplayName.TabIndex = 0
        Me.LblDisplayName.Text = "&Display Name"
        Me.LblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblEmail
        '
        Me.LblEmail.Location = New System.Drawing.Point(161, 175)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(220, 23)
        Me.LblEmail.TabIndex = 2
        Me.LblEmail.Text = "&Email Address"
        Me.LblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDisplayName
        '
        Me.TxtDisplayName.Location = New System.Drawing.Point(164, 158)
        Me.TxtDisplayName.Name = "TxtDisplayName"
        Me.TxtDisplayName.Size = New System.Drawing.Size(220, 20)
        Me.TxtDisplayName.TabIndex = 3
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(164, 201)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(220, 20)
        Me.TxtEmail.TabIndex = 4
        '
        'BtnSubmitAccount
        '
        Me.BtnSubmitAccount.Location = New System.Drawing.Point(172, 323)
        Me.BtnSubmitAccount.Name = "BtnSubmitAccount"
        Me.BtnSubmitAccount.Size = New System.Drawing.Size(94, 23)
        Me.BtnSubmitAccount.TabIndex = 6
        Me.BtnSubmitAccount.Text = "&Next"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(293, 323)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 23)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "&Cancel"
        '
        'TxtLastName
        '
        Me.TxtLastName.Location = New System.Drawing.Point(164, 109)
        Me.TxtLastName.Name = "TxtLastName"
        Me.TxtLastName.Size = New System.Drawing.Size(220, 20)
        Me.TxtLastName.TabIndex = 2
        '
        'TxtFirstName
        '
        Me.TxtFirstName.Location = New System.Drawing.Point(164, 60)
        Me.TxtFirstName.Multiline = True
        Me.TxtFirstName.Name = "TxtFirstName"
        Me.TxtFirstName.Size = New System.Drawing.Size(220, 20)
        Me.TxtFirstName.TabIndex = 1
        '
        'LblLastName
        '
        Me.LblLastName.Location = New System.Drawing.Point(161, 83)
        Me.LblLastName.Name = "LblLastName"
        Me.LblLastName.Size = New System.Drawing.Size(220, 23)
        Me.LblLastName.TabIndex = 8
        Me.LblLastName.Text = "&LastName"
        Me.LblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblFirstName
        '
        Me.LblFirstName.Location = New System.Drawing.Point(161, 34)
        Me.LblFirstName.Name = "LblFirstName"
        Me.LblFirstName.Size = New System.Drawing.Size(220, 23)
        Me.LblFirstName.TabIndex = 6
        Me.LblFirstName.Text = "&First Name"
        Me.LblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(164, 250)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(220, 20)
        Me.TxtPassword.TabIndex = 5
        Me.TxtPassword.UseSystemPasswordChar = True
        '
        'LblPassword
        '
        Me.LblPassword.Location = New System.Drawing.Point(161, 224)
        Me.LblPassword.Name = "LblPassword"
        Me.LblPassword.Size = New System.Drawing.Size(220, 23)
        Me.LblPassword.TabIndex = 10
        Me.LblPassword.Text = "&Password"
        Me.LblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogIn
        '
        Me.AcceptButton = Me.BtnSubmitAccount
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(401, 358)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.LblPassword)
        Me.Controls.Add(Me.TxtLastName)
        Me.Controls.Add(Me.TxtFirstName)
        Me.Controls.Add(Me.LblLastName)
        Me.Controls.Add(Me.LblFirstName)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSubmitAccount)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.TxtDisplayName)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.LblDisplayName)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LogIn"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setup your account"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtLastName As System.Windows.Forms.TextBox
    Friend WithEvents TxtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents LblLastName As System.Windows.Forms.Label
    Friend WithEvents LblFirstName As System.Windows.Forms.Label
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents LblPassword As System.Windows.Forms.Label
    Private WithEvents BtnSubmitAccount As System.Windows.Forms.Button

End Class
