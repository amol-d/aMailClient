Public Class Mail
    Public _id, acID, retry_send_time As Integer
    Public display_name, subject, mailbox_type, message_text As String
    Public time_of_arrival As Date
    Public flag_read, flag_favorite, flag_attachment, flag_reply As Boolean
    Public from_list As String
    Public to_list, cc_list, bcc_list, reply_to_list As List(Of String)

    Public Sub New(ByVal _id As Integer, ByVal acID As Integer, ByVal display_name As String, ByVal time_of_arrival As Date, ByVal subject As String,
                   ByVal flag_read As Boolean, ByVal flag_favorite As Boolean, ByVal flag_attachment As Boolean,
                   ByVal flag_reply As Boolean, ByVal from_list As String,
                   ByVal to_list As List(Of String), ByVal cc_list As List(Of String),
                   ByVal bcc_list As List(Of String), ByVal reply_to_list As List(Of String),
                   ByVal mailbox_type As String, ByVal retry_send_time As Integer, ByVal message_text As String)
        Me._id = _id
        Me.acID = acID
        Me.display_name = display_name
        Me.time_of_arrival = time_of_arrival
        Me.subject = subject
        Me.flag_read = flag_read
        Me.flag_favorite = flag_favorite
        Me.flag_attachment = flag_attachment
        Me.flag_reply = flag_reply
        Me.from_list = from_list
        Me.to_list = to_list
        Me.cc_list = cc_list
        Me.bcc_list = bcc_list
        Me.reply_to_list = reply_to_list
        Me.mailbox_type = mailbox_type
        Me.retry_send_time = retry_send_time
        Me.message_text = message_text
    End Sub
End Class
