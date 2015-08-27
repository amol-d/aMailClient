Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Globalization
Public Class DBTableMailOperations
    Dim con As SqlCeConnection = New SqlCeConnection(My.Settings.MailDBConnectionString) '"Data Source=C:\Users\AMOL\Documents\Visual Studio 2010\Projects\WindowsApplication1\WindowsApplication1\MailDB.sdf"
    Dim cmd As SqlCeCommand
    Dim myDA As SqlCeDataAdapter
    Dim myDataSet As DataSet
    Dim rowAffected As Integer
    Dim reader As SqlCeDataReader
    Public flag_read, flag_favorite, flag_attachment, flag_reply As Integer
    Public from_list, to_list, cc_list, bcc_list, reply_to_list As String

    Public Function BulkInsertAllMail(ByVal mails As List(Of Mail)) As Boolean
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            For Each mail As Mail In mails
                flag_read = If(mail.flag_read, 1, 0)
                flag_attachment = If(mail.flag_attachment, 1, 0)
                flag_favorite = If(mail.flag_favorite, 1, 0)
                flag_reply = If(mail.flag_reply, 1, 0)
                from_list = String.Join(",", mail.from_list.ToArray())
                to_list = String.Join(",", mail.from_list.ToArray)
                cc_list = String.Join(",", mail.cc_list.ToArray)
                bcc_list = String.Join(",", mail.bcc_list.ToArray)
                reply_to_list = String.Join(",", mail.reply_to_list.ToArray)

                Dim insertCommand As String = "INSERT INTO " +
                    DBTableMail.TABLE_MAIL & " (" & DBTableMail.COLUMN_AC_ID & ", " & DBTableMail.COLUMN_DISPLAY_NAME & ", " & DBTableMail.COLUMN_TIME_OF_ARRIVAL & ", " & DBTableMail.COLUMN_SUBJECT & ", " & DBTableMail.COLUMN_FLAG_READ & ", " & DBTableMail.COLUMN_FLAG_FAVORITE & ", " & DBTableMail.COLUMN_FLAG_ATTACHMENT & ", " & DBTableMail.COLUMN_FLAG_REPLY & ", " & DBTableMail.COLUMN_FROM_LIST & ", " & DBTableMail.COLUMN_TO_LIST & ", " & DBTableMail.COLUMN_CC_LIST & ", " & DBTableMail.COLUMN_BCC_LIST & ", " & DBTableMail.COLUMN_REPLY_TO_LIST & ", " & DBTableMail.COLUMN_MAILBOX_TYPE & ", " & DBTableMail.COLUMN_SEND_RETRY & ", " & DBTableMail.COLUMN_MESSAGE_TEXT +
                        ") VALUES (" & mail.acID & ", '" & mail.display_name & "', '" & mail.time_of_arrival & "', '" & mail.subject & "', " & flag_read & ", " & flag_favorite +
                        ", " & flag_attachment & ", " & flag_reply & ", '" & from_list & "', '" & to_list & "', '" & cc_list & "','" & bcc_list & "','" & reply_to_list & "','" & mail.mailbox_type & "'," & mail.retry_send_time & ",'" & mail.message_text & "')"
                cmd = New SqlCeCommand(insertCommand, con)
                rowAffected += cmd.ExecuteNonQuery()
            Next
            con.Close()

            If rowAffected >= 1 Then
                Console.WriteLine("Rows added : " & rowAffected)
                Return True
            Else
                Console.WriteLine("Error occured : " & rowAffected)
                Return False
            End If
        Catch ex As Exception
            Console.WriteLine("Exception " & ex.Message)
            Return False
        End Try
    End Function
End Class
