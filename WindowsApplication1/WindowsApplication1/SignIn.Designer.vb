<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class splash
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
        Me.components = New System.ComponentModel.Container()
        Me.pbStartUp = New System.Windows.Forms.ProgressBar()
        Me.progressTimertask = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'pbStartUp
        '
        Me.pbStartUp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStartUp.Location = New System.Drawing.Point(0, 238)
        Me.pbStartUp.MarqueeAnimationSpeed = 10
        Me.pbStartUp.Maximum = 10000
        Me.pbStartUp.Name = "pbStartUp"
        Me.pbStartUp.Size = New System.Drawing.Size(284, 23)
        Me.pbStartUp.Step = 1
        Me.pbStartUp.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbStartUp.TabIndex = 0
        '
        'progressTimertask
        '
        Me.progressTimertask.Enabled = True
        Me.progressTimertask.Interval = 10000
        '
        'splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.pbStartUp)
        Me.Name = "splash"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbStartUp As System.Windows.Forms.ProgressBar
    Friend WithEvents progressTimertask As System.Windows.Forms.Timer

End Class
