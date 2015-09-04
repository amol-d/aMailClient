Imports Limilabs.Mail
Imports Limilabs.Client.POP3
Imports System.Linq
Imports Limilabs.Mail.Headers
Imports Limilabs.Client.IMAP

Public Class EmailHelper
    Dim mails As List(Of Mail) = New List(Of Mail)
    Public Sub New()

    End Sub
    Public Function getInboxForCurrentUser(ByVal user As User) As List(Of Mail)
        'refer
        'http://www.limilabs.com/blog/detect-gmail-2-step-authentication

        Using imap As New Limilabs.Client.IMAP.Imap()
            Try
                imap.ConnectSSL("imap.gmail.com")
                imap.UseBestLogin(user.email, user._pwd)
                imap.SelectInbox()
                Dim uids As List(Of Long) = imap.Search(Limilabs.Client.IMAP.Flag.All)
                For Each uid As Long In uids
                    Dim eml = imap.GetMessageByUID(uid)
                    Dim mail As IMail = New MailBuilder().CreateFromEml(eml)
                    Dim receivedEntries As List(Of String) = New List(Of String)
                    Dim ccList As List(Of String) = New List(Of String)
                    Dim bccList As List(Of String) = New List(Of String)
                    Dim replyToList As List(Of String) = New List(Of String)

                    For Each entry As ReceivedEntry In mail.Received
                        receivedEntries.Add(entry.From.ToString)
                    Next
                    For Each cc As MailAddress In mail.Cc
                        ccList.Add(cc.ToString)
                    Next
                    For Each bcc As MailAddress In mail.Bcc
                        bccList.Add(bcc.ToString)
                    Next
                    For Each replyTo As MailAddress In mail.ReplyTo
                        replyToList.Add(replyTo.ToString)
                    Next
                    mails.Add(
                        New Mail(mail.MessageID, mail.MessageID.GetHashCode,
                                 user.acID,
                                 mail.Sender.Address,
                                 mail.Date,
                                 mail.Subject,
                                 True,
                                 True,
                                 If(mail.Attachments.Count = 0, False, True),
                                 mail.IsReply,
                                 mail.Sender.Address,
                                  receivedEntries, ccList, bccList, replyToList, DBTableMailOperations.MAIL_BOX_TYPE_INBOX, 3, mail.Text))
                    Console.WriteLine("Unseen : " & mail.Subject)
                    Console.WriteLine("Unseen : " & mail.Text)
                Next
                imap.Close()
            Catch ex As Exception
                Dim needs2StepVerification As Boolean = ex.Message.Contains("Application-specific password required")
                imap.Close()
                If needs2StepVerification Then
                    Console.WriteLine("Application-specific password required")
                    MsgBox(Utils.TwO_STEP_VERIFICATION, MsgBoxStyle.Critical, Utils.TWO_STEP_VERIFICATION_NEEDED)
                End If
                Console.WriteLine(ex)
            End Try
        End Using
        Return mails
    End Function

    Public Function getSentForCurrentUser(ByVal user As User) As List(Of Mail)
        'refer
        'http://www.limilabs.com/blog/detect-gmail-2-step-authentication
        mails.Clear()

        Using imap As New Limilabs.Client.IMAP.Imap()
            Try
                imap.ConnectSSL("imap.gmail.com")
                imap.UseBestLogin(user.email, user._pwd)
                imap.Select("[Gmail]/Sent Mail")
                Dim uids As List(Of Long) = imap.Search(Limilabs.Client.IMAP.Flag.All)
                For Each uid As Long In uids
                    Dim eml = imap.GetMessageByUID(uid)
                    Dim mail As IMail = New MailBuilder().CreateFromEml(eml)
                    Dim receivedEntries As List(Of String) = New List(Of String)
                    Dim ccList As List(Of String) = New List(Of String)
                    Dim bccList As List(Of String) = New List(Of String)
                    Dim replyToList As List(Of String) = New List(Of String)

                    For Each entry As ReceivedEntry In mail.Received
                        receivedEntries.Add(entry.From.ToString)
                    Next
                    For Each cc As MailAddress In mail.Cc
                        ccList.Add(cc.ToString)
                    Next
                    For Each bcc As MailAddress In mail.Bcc
                        bccList.Add(bcc.ToString)
                    Next
                    For Each replyTo As MailAddress In mail.ReplyTo
                        replyToList.Add(replyTo.ToString)
                    Next
                    mails.Add(
                        New Mail(mail.MessageID, mail.MessageID.GetHashCode,
                                 user.acID,
                                 mail.Sender.Address,
                                 mail.Date,
                                 mail.Subject,
                                 True,
                                 True,
                                 If(mail.Attachments.Count = 0, False, True),
                                 mail.IsReply,
                                 mail.Sender.Address,
                                  receivedEntries, ccList, bccList, replyToList, DBTableMailOperations.MAIL_BOX_TYPE_SENT_MAILS, 3, mail.Text))
                    Console.WriteLine("Unseen : " & mail.Subject)
                    Console.WriteLine("Unseen : " & mail.Text)
                Next
                imap.Close()
            Catch ex As Exception
                Dim needs2StepVerification As Boolean = ex.Message.Contains("Application-specific password required")
                imap.Close()
                If needs2StepVerification Then
                    Console.WriteLine("Application-specific password required")
                    MsgBox(Utils.TwO_STEP_VERIFICATION, MsgBoxStyle.Critical, Utils.TWO_STEP_VERIFICATION_NEEDED)
                End If
                Console.WriteLine(ex)
            End Try
        End Using
        Return mails
    End Function


    Function authenticateUser(ByVal user As User) As Boolean
        Using imap As New Limilabs.Client.IMAP.Imap()
            Try
                imap.ConnectSSL("imap.gmail.com")
                imap.UseBestLogin(user.email, user._pwd)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Public Function getOutboxForCurrentUser(ByVal user As User) As List(Of Mail)
        'refer
        'http://www.limilabs.com/blog/detect-gmail-2-step-authentication
        mails.Clear()

        Using imap As New Limilabs.Client.IMAP.Imap()
            Try
                imap.ConnectSSL("imap.gmail.com")
                imap.UseBestLogin(user.email, user._pwd)
                imap.Select("[Gmail]/Sent Mail")
                Dim uids As List(Of Long) = imap.Search(Limilabs.Client.IMAP.Flag.All)
                For Each uid As Long In uids
                    Dim eml = imap.GetMessageByUID(uid)
                    Dim mail As IMail = New MailBuilder().CreateFromEml(eml)
                    Dim receivedEntries As List(Of String) = New List(Of String)
                    Dim ccList As List(Of String) = New List(Of String)
                    Dim bccList As List(Of String) = New List(Of String)
                    Dim replyToList As List(Of String) = New List(Of String)

                    For Each entry As ReceivedEntry In mail.Received
                        receivedEntries.Add(entry.From.ToString)
                    Next
                    For Each cc As MailAddress In mail.Cc
                        ccList.Add(cc.ToString)
                    Next
                    For Each bcc As MailAddress In mail.Bcc
                        bccList.Add(bcc.ToString)
                    Next
                    For Each replyTo As MailAddress In mail.ReplyTo
                        replyToList.Add(replyTo.ToString)
                    Next
                    mails.Add(
                        New Mail(mail.MessageID, mail.MessageID.GetHashCode,
                                 user.acID,
                                 mail.Sender.Address,
                                 mail.Date,
                                 mail.Subject,
                                 True,
                                 True,
                                 If(mail.Attachments.Count = 0, False, True),
                                 mail.IsReply,
                                 mail.Sender.Address,
                                  receivedEntries, ccList, bccList, replyToList, "SENT ITEMS", 3, mail.Text))
                    Console.WriteLine("Unseen : " & mail.Subject)
                    Console.WriteLine("Unseen : " & mail.Text)
                Next
                imap.Close()
            Catch ex As Exception
                Dim needs2StepVerification As Boolean = ex.Message.Contains("Application-specific password required")
                imap.Close()
                If needs2StepVerification Then
                    Console.WriteLine("Application-specific password required")
                    MsgBox(Utils.TwO_STEP_VERIFICATION, MsgBoxStyle.Critical, Utils.TWO_STEP_VERIFICATION_NEEDED)
                End If
                Console.WriteLine(ex)
            End Try
        End Using
        Return mails
    End Function
End Class
