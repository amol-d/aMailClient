﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MailViewer
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
        Me.cmbMailFolders = New System.Windows.Forms.ComboBox()
        Me.mailPanel = New System.Windows.Forms.Panel()
        Me.mailFetcher = New System.ComponentModel.BackgroundWorker()
        Me.FetchMailTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lstInbox = New System.Windows.Forms.ListBox()
        Me.fetchOutbox = New System.ComponentModel.BackgroundWorker()
        Me.fetchSent = New System.ComponentModel.BackgroundWorker()
        Me.fetchTrash = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'cmbMailFolders
        '
        Me.cmbMailFolders.FormattingEnabled = True
        Me.cmbMailFolders.Location = New System.Drawing.Point(1, 7)
        Me.cmbMailFolders.Name = "cmbMailFolders"
        Me.cmbMailFolders.Size = New System.Drawing.Size(164, 21)
        Me.cmbMailFolders.TabIndex = 1
        '
        'mailPanel
        '
        Me.mailPanel.Location = New System.Drawing.Point(172, 7)
        Me.mailPanel.Name = "mailPanel"
        Me.mailPanel.Size = New System.Drawing.Size(265, 335)
        Me.mailPanel.TabIndex = 2
        '
        'mailFetcher
        '
        Me.mailFetcher.WorkerReportsProgress = True
        Me.mailFetcher.WorkerSupportsCancellation = True
        '
        'FetchMailTimer
        '
        '
        'lstInbox
        '
        Me.lstInbox.FormattingEnabled = True
        Me.lstInbox.Location = New System.Drawing.Point(1, 36)
        Me.lstInbox.Name = "lstInbox"
        Me.lstInbox.Size = New System.Drawing.Size(164, 303)
        Me.lstInbox.TabIndex = 3
        '
        'fetchOutbox
        '
        '
        'fetchSent
        '
        '
        'fetchTrash
        '
        '
        'MailViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 343)
        Me.Controls.Add(Me.lstInbox)
        Me.Controls.Add(Me.mailPanel)
        Me.Controls.Add(Me.cmbMailFolders)
        Me.Name = "MailViewer"
        Me.Text = "MailViewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbMailFolders As System.Windows.Forms.ComboBox
    Friend WithEvents mailPanel As System.Windows.Forms.Panel
    Friend WithEvents mailFetcher As System.ComponentModel.BackgroundWorker
    Friend WithEvents FetchMailTimer As System.Windows.Forms.Timer
    Friend WithEvents lstInbox As System.Windows.Forms.ListBox
    Friend WithEvents fetchOutbox As System.ComponentModel.BackgroundWorker
    Friend WithEvents fetchSent As System.ComponentModel.BackgroundWorker
    Friend WithEvents fetchTrash As System.ComponentModel.BackgroundWorker
End Class
