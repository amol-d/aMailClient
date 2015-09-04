Public Class MailViewer
    Dim dbOperation As DBTableAccountOperations
    Dim mailHelper As EmailHelper
    Dim user As User
    Dim mails As List(Of Mail)
    Dim dbMailHelper As DBTableMailOperations
    Private Const INDEX_INBOX As Integer = 0
    Private Const INDEX_OUTBOX As Integer = 1
    Private Const INDEX_SENT As Integer = 2
    Private Const INDEX_TRASH As Integer = 3


    Private Sub MailViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        user = AppDelegate.GetSingletonInstance.getCurrentUser()
        'UI setup
        lstInbox.Height = Me.Height * 0.9
        lstInbox.Width = Me.Width / 4
        cmbMailFolders.Width = Me.Width / 4
        mailPanel.SetBounds(lstInbox.Width + 10, 10, (Me.Width - lstInbox.Width - 20), lstInbox.Height - 20)
        mailPanel.BackColor = Color.AliceBlue
        lstInbox.ItemHeight = 50

        cmbMailFolders.Items.Add("Inbox")
        cmbMailFolders.Items.Add("Outnbox")
        cmbMailFolders.Items.Add("Sent")
        cmbMailFolders.Items.Add("Trash")

        cmbMailFolders.SelectedIndex = 0


        'Timer setup
        updateInboxList()

        If Not IsNothing(user) Then
            dbOperation = New DBTableAccountOperations()
            mailHelper = New EmailHelper()
            FetchMailTimer.Interval = user.sync_interval
            FetchMailTimer.Start()
            mailFetcher.RunWorkerAsync()
            fetchOutbox.RunWorkerAsync()
            fetchSent.RunWorkerAsync()
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

    Private Sub mailFetcher_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles mailFetcher.RunWorkerCompleted
        updateInboxList()
    End Sub

    Private Sub updateInboxList()
        dbMailHelper = New DBTableMailOperations()
        mails = dbMailHelper.getInboxForCurrentUser(user.acID)
        lstInbox.Items.Clear()
        For Each mail As Mail In mails
            lstInbox.Items.Add("" + mail.subject)
        Next
        lstInbox.Update()
    End Sub

    Private Sub cmbMailFolders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMailFolders.SelectedIndexChanged
        Select Case cmbMailFolders.SelectedIndex
            Case INDEX_INBOX
                updateInboxList()
            Case INDEX_OUTBOX
            Case INDEX_SENT
            Case INDEX_TRASH
        End Select
    End Sub


    Private Sub fetchOutbox_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles fetchOutbox.DoWork
        If Not IsNothing(mailHelper) And Not IsNothing(user) Then
            mails = mailHelper.getOutboxForCurrentUser(user)
            dbMailHelper = New DBTableMailOperations()
            dbMailHelper.BulkInsertAllMail(mails)
        End If
    End Sub

    Private Sub fetchSent_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles fetchSent.DoWork
        If Not IsNothing(mailHelper) And Not IsNothing(user) Then
            mails = mailHelper.getSentForCurrentUser(user)
            dbMailHelper = New DBTableMailOperations()
            dbMailHelper.BulkInsertAllMail(mails)
        End If
    End Sub

    Private Sub fetchTrash_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles fetchTrash.DoWork
        If Not IsNothing(mailHelper) And Not IsNothing(user) Then
            mails = mailHelper.getInboxForCurrentUser(user)
            dbMailHelper = New DBTableMailOperations()
            dbMailHelper.BulkInsertAllMail(mails)
        End If
    End Sub
End Class