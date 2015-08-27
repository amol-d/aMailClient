Imports Limilabs.Mail
Imports Limilabs.Client.POP3
Imports System.Linq

Public Class EmailHelper
    Dim mails As List(Of Mail)
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
                    mails.Add(
                        New Mail(mail.MessageID.GetHashCode, user.acID, mail.Sender.Address, mail.Date, mail.Subject, True, True, If(mail.Attachments.Count = 0, False, True), mail.IsReply, mail.Sender.Address, mail.Received, mail.Cc, mail.Bcc, mail.ReplyTo, "INBOX", 3, mail.GetBodyAsHtml))
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

            End Try
        End Using
        Return mails
    End Function
End Class
