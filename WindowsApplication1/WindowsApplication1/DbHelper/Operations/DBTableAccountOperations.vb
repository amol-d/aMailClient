Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Globalization
Public Class DBTableAccountOperations
    Dim con As SqlCeConnection = New SqlCeConnection("Data Source=C:\Users\AMOL\Documents\Visual Studio 2010\Projects\aMailClient\WindowsApplication1\WindowsApplication1\MailDB.sdf")
    Dim cmd As SqlCeCommand
    Dim myDA As SqlCeDataAdapter
    Dim myDataSet As DataSet
    Dim rowAffected As Integer

    'Dim reader As SqlCeDataReader
    Dim user As User
    'User properties
    Dim acID As Integer
    Dim f_name, l_name, email, password, display_name, sender_name, signature As String
    Dim new_message_count, sync_interval As Integer


    Public Sub New()
        'Do nothing
    End Sub
    Public Function getCurrentUser(ByVal user_email As String) As User
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim selectCommand As String = "SELECT * FROM " & DbTableAccount.TABLE_ACCOUNT & " WHERE (" & DbTableAccount.COLUMN_EMAIL & " LIKE '" & user_email & "')"
            cmd = New SqlCeCommand(selectCommand, con)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                acID = reader.GetInt32(reader.GetOrdinal(DbTableAccount.COLUMN_ACID))
                f_name = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_F_NAME))
                l_name = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_L_NAME))
                email = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_EMAIL))
                password = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_PASSWORD))
                display_name = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_DISPLAY_NAME))
                sender_name = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_SENDER_NAME))
                signature = reader.GetString(reader.GetOrdinal(DbTableAccount.COLUMN_SIGNATURE))
                new_message_count = reader.GetInt32(reader.GetOrdinal(DbTableAccount.COLUMN_NEW_MESSAGE_COUNT))
                sync_interval = reader.GetInt64(reader.GetOrdinal(DbTableAccount.COLUMN_SYNC_INTERVAL))
                user = New User(acID, f_name, l_name, email, password, display_name, sender_name, signature, sync_interval, new_message_count)
            End While

        Catch ex As Exception
            user = Nothing
        Finally
            con.Close()
        End Try
        Return user
    End Function
    Public Function isUserExists(ByVal email As String) As Boolean
        Dim result As Boolean
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim selectCommand As String = "SELECT * FROM " & DbTableAccount.TABLE_ACCOUNT & " WHERE (" & DbTableAccount.COLUMN_EMAIL & " LIKE '" & email & "')"
            cmd = New SqlCeCommand(selectCommand, con)
            Dim reader = cmd.ExecuteReader()
            result = reader.Read()
            'If reader.HasRows Then
            'result = True
            'Else
            'result = False
            'End If
        Catch ex As Exception
            result = False
        Finally
            con.Close()
        End Try
        Return result
    End Function

    Public Function insertUser(ByVal user As User) As Boolean
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim insertCommand As String = "INSERT INTO " & DbTableAccount.TABLE_ACCOUNT & " (" & DbTableAccount.COLUMN_F_NAME & ", " & DbTableAccount.COLUMN_L_NAME & ", " & DbTableAccount.COLUMN_EMAIL & ", " & DbTableAccount.COLUMN_PASSWORD & ", " & DbTableAccount.COLUMN_DISPLAY_NAME & ", " & DbTableAccount.COLUMN_SENDER_NAME & ", " & DbTableAccount.COLUMN_SIGNATURE & ") VALUES ('" & user.f_name & "', '" & user.l_name & "', '" & user.email & "', '" & user._pwd & "', '" & user.display_name & "', '" & user.display_name & "', '')"
            cmd = New SqlCeCommand(insertCommand, con)
            rowAffected = cmd.ExecuteNonQuery()
            con.Close()
            If rowAffected = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function truncateUserTable() As Boolean
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim truncateCommand As String = "TRUNCATE TABLE " & DbTableAccount.TABLE_ACCOUNT
            cmd = New SqlCeCommand(truncateCommand, con)
            rowAffected = cmd.ExecuteNonQuery()
            con.Close()
            If rowAffected = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
