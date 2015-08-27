Public Class MailViewer
    Dim dbOperation As DBTableAccountOperations
    Dim mailHelper As EmailHelper
    Dim user As User
    Dim mails As List(Of Mail)
    Dim dbMailHelper As DBTableMailOperations

    Private Sub MailViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'UI setup
        lstInbox.Height = Me.Height * 0.9
        lstInbox.Width = Me.Width / 4
        cmbMailFolders.Width = Me.Width / 4
        mailPanel.SetBounds(lstInbox.Width + 10, 10, (Me.Width - lstInbox.Width - 20), lstInbox.Height - 20)
        mailPanel.BackColor = Color.AliceBlue
        'mailPanel.Width = (Me.Width * 0.5)
        'mailPanel.Height = Me.Height
        lstInbox.Items.Add("Mail1")
        lstInbox.Items.Add("mail2")

        'Timer setup
        user = AppDelegate.GetSingletonInstance.getCurrentUser()
        If Not IsNothing(user) Then
            dbOperation = New DBTableAccountOperations()
            mailHelper = New EmailHelper()
            FetchMailTimer.Interval = user.sync_interval
            FetchMailTimer.Start()
            mailFetcher.RunWorkerAsync()

        End If
    End Sub
    Private Sub FetchMailTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FetchMailTimer.Tick
       
    End Sub

    Private Sub mailFetcher_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles mailFetcher.DoWork
        If Not IsNothing(mailHelper) And Not IsNothing(user) Then
            mails = mailHelper.getInboxForCurrentUser(user)
            dbMailHelper = New DBTableMailOperations()
            dbMailHelper.BulkInsertAllMail(mails)
        End If
    End Sub
End Class