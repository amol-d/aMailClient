Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Globalization
Public Class DBTableMailOperations
    Dim con As SqlCeConnection = New SqlCeConnection("Data Source=C:\Users\AMOL\Documents\Visual Studio 2010\Projects\aMailClient\WindowsApplication1\WindowsApplication1\MailDB.sdf")
    Dim cmd As SqlCeCommand
    Dim myDA As SqlCeDataAdapter
    Dim myDataSet As DataSet
    Dim rowAffected As Integer
    Dim reader As SqlCeDataReader
    Public flag_read, flag_favorite, flag_attachment, flag_reply As Integer
    Public from_list, to_list, cc_list, bcc_list, reply_to_list As String
    Public Const MAIL_BOX_TYPE_INBOX As String = "INBOX"
    Public Const MAIL_BOX_TYPE_SENT_MAILS As String = "SENT"

    Public Function BulkInsertAllMail(ByVal mails As List(Of Mail)) As Boolean
        Dim user As User = AppDelegate.GetSingletonInstance().getCurrentUser()
        If user IsNot Nothing Then
            Dim idList = getInboxIDs(user.acID)
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                For Each mail As Mail In mails
                    If Not idList.Contains(mail.msg_id) Then
                        flag_read = If(mail.flag_read, 1, 0)
                        flag_attachment = If(mail.flag_attachment, 1, 0)
                        flag_favorite = If(mail.flag_favorite, 1, 0)
                        flag_reply = If(mail.flag_reply, 1, 0)
                        from_list = String.Join(",", mail.from_list.ToArray())
                        to_list = String.Join(",", mail.from_list.ToArray)
                        cc_list = String.Join(",", mail.cc_list.ToArray)
                        bcc_list = String.Join(",", mail.bcc_list.ToArray)
                        reply_to_list = String.Join(",", mail.reply_to_list.ToArray)

                        Dim insertCommand As String = "INSERT INTO [" & DBTableMail.TABLE_MAIL & "] (" & DBTableMail.COLUMN_MESSAGE_ID & ", " & DBTableMail.COLUMN_AC_ID & ", " & DBTableMail.COLUMN_DISPLAY_NAME & ", " & DBTableMail.COLUMN_TIME_OF_ARRIVAL & ", " & DBTableMail.COLUMN_SUBJECT & ", " & DBTableMail.COLUMN_FLAG_READ & ", " & DBTableMail.COLUMN_FLAG_FAVORITE & ", " & DBTableMail.COLUMN_FLAG_ATTACHMENT & ", " & DBTableMail.COLUMN_FLAG_REPLY & ", " & DBTableMail.COLUMN_FROM_LIST & ", " & DBTableMail.COLUMN_TO_LIST & ", " & DBTableMail.COLUMN_CC_LIST & ", " & DBTableMail.COLUMN_BCC_LIST & ", " & DBTableMail.COLUMN_REPLY_TO_LIST & ", " & DBTableMail.COLUMN_MAILBOX_TYPE & ", " & DBTableMail.COLUMN_SEND_RETRY & ", " & DBTableMail.COLUMN_MESSAGE_TEXT & ") VALUES ('" & mail.msg_id & "', " & mail.acID & ", '" & mail.display_name & "', '" & mail.time_of_arrival & "', '" & mail.subject.Replace("'", "''") & "', " & flag_read & ", " & flag_favorite & ", " & flag_attachment & ", " & flag_reply & ", '" & from_list & "', '" & to_list & "', '" & cc_list & "','" & bcc_list & "','" & reply_to_list & "','" & mail.mailbox_type & "'," & mail.retry_send_time & ",'" & mail.message_text.Replace("'", "''") & "')"
                        cmd = New SqlCeCommand(insertCommand, con)
                        rowAffected += cmd.ExecuteNonQuery()
                    End If
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
                Console.WriteLine(ex)
                Return False
            End Try
        End If
        Return False
        
    End Function

    Public Function getInboxIDs(ByVal user_id As Integer) As List(Of String)
        Dim idList As List(Of String) = New List(Of String)
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim selectCommand As String = "SELECT * FROM " & DBTableMail.TABLE_MAIL & " WHERE (" & DBTableMail.COLUMN_AC_ID & " = " & user_id & ")"
            cmd = New SqlCeCommand(selectCommand, con)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                idList.Add(reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MESSAGE_ID)))
            End While
            con.close()
        Catch ex As Exception

        End Try
        Return idList
    End Function

    Public Function getInboxForCurrentUser(ByVal user_id As Integer) As List(Of Mail)
        Dim mails As List(Of Mail) = New List(Of Mail)
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim selectCommand As String = "SELECT * FROM " & DBTableMail.TABLE_MAIL & " WHERE (" & DBTableMail.COLUMN_AC_ID & " = " & user_id & " AND " & DBTableMail.COLUMN_MAILBOX_TYPE & "= '" & MAIL_BOX_TYPE_INBOX & "')"
            cmd = New SqlCeCommand(selectCommand, con)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                mails.Add(New Mail(
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MESSAGE_ID)),
                          reader.GetInt32(reader.GetOrdinal(DBTableMail.COLUMN_ID)),
                          reader.GetInt32(reader.GetOrdinal(DBTableMail.COLUMN_AC_ID)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_DISPLAY_NAME)),
                          reader.GetDateTime(reader.GetOrdinal(DBTableMail.COLUMN_TIME_OF_ARRIVAL)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_SUBJECT)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_READ)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_FAVORITE)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_ATTACHMENT)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_REPLY)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_FROM_LIST)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_TO_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_CC_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_BCC_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_REPLY_TO_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MAILBOX_TYPE)),
                          reader.GetInt32(reader.GetOrdinal(DBTableMail.COLUMN_SEND_RETRY)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MESSAGE_TEXT))))
            End While
            con.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return mails
    End Function

    Public Function getSentMailsForCurrentUser(ByVal user_id As Integer) As List(Of Mail)
        Dim mails As List(Of Mail) = New List(Of Mail)
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim selectCommand As String = "SELECT * FROM " & DBTableMail.TABLE_MAIL & " WHERE (" & DBTableMail.COLUMN_AC_ID & " = " & user_id & " AND " & DBTableMail.COLUMN_MAILBOX_TYPE & "= '" & MAIL_BOX_TYPE_SENT_MAILS & "')"
            cmd = New SqlCeCommand(selectCommand, con)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                mails.Add(New Mail(
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MESSAGE_ID)),
                          reader.GetInt32(reader.GetOrdinal(DBTableMail.COLUMN_ID)),
                          reader.GetInt32(reader.GetOrdinal(DBTableMail.COLUMN_AC_ID)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_DISPLAY_NAME)),
                          reader.GetDateTime(reader.GetOrdinal(DBTableMail.COLUMN_TIME_OF_ARRIVAL)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_SUBJECT)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_READ)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_FAVORITE)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_ATTACHMENT)),
                          reader.GetBoolean(reader.GetOrdinal(DBTableMail.COLUMN_FLAG_REPLY)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_FROM_LIST)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_TO_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_CC_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_BCC_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_REPLY_TO_LIST)).Split(",").ToList(),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MAILBOX_TYPE)),
                          reader.GetInt32(reader.GetOrdinal(DBTableMail.COLUMN_SEND_RETRY)),
                          reader.GetString(reader.GetOrdinal(DBTableMail.COLUMN_MESSAGE_TEXT))))
            End While
            con.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return mails
    End Function
End Class
