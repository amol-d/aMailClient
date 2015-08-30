Public Class DBTableMail
    Public Const TABLE_MAIL As String = "message"
    Public Const COLUMN_ID As String = "_id"
    Public Const COLUMN_MESSAGE_ID As String = "msg_id"
    Public Const COLUMN_AC_ID As String = "acID"
    Public Const COLUMN_DISPLAY_NAME As String = "display_name"
    Public Const COLUMN_TIME_OF_ARRIVAL As String = "time_of_arrival"
    Public Const COLUMN_SUBJECT As String = "subject"
    Public Const COLUMN_FLAG_READ As String = "flag_read"
    Public Const COLUMN_FLAG_FAVORITE As String = "flag_favorite"

    Public Const COLUMN_FLAG_ATTACHMENT As String = "flag_attachment"
    Public Const COLUMN_FLAG_REPLY As String = "flag_reply"

    Public Const COLUMN_FROM_LIST As String = "from_list"
    Public Const COLUMN_TO_LIST As String = "to_list"
    Public Const COLUMN_CC_LIST As String = "cc_list"
    Public Const COLUMN_BCC_LIST As String = "bcc_list"
    Public Const COLUMN_REPLY_TO_LIST As String = "reply_to_list"
    Public Const COLUMN_MAILBOX_TYPE As String = "mailbox_type"
    Public Const COLUMN_SEND_RETRY As String = "retry_send_time"
    Public Const COLUMN_MESSAGE_TEXT As String = "message_text"
End Class
