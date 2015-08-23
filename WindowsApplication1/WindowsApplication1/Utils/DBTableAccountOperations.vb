Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Globalization
Public Class DBTableAccountOperations
    Dim con As SqlCeConnection = New SqlCeConnection(My.Settings.MailDBConnectionString) '"Data Source=C:\Users\AMOL\Documents\Visual Studio 2010\Projects\WindowsApplication1\WindowsApplication1\MailDB.sdf"
    Dim cmd As SqlCeCommand
    Dim myDA As SqlCeDataAdapter
    Dim myDataSet As DataSet
    Dim rowAffected As Integer
    Dim reader As SqlCeDataReader
    Public Sub New()
        'Do nothing
    End Sub
    Public Function isUserExists(ByVal email As String) As Boolean
        Dim result As Boolean
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim selectCommand As String = "SELECT * FROM " & DbTableAccount.TABLE_ACCOUNT & " WHERE (" & DbTableAccount.COLUMN_EMAIL & " LIKE '" & email & "')"
            cmd = New SqlCeCommand(selectCommand, con)
            reader = cmd.ExecuteReader()
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
            Dim insertCommand As String = "INSERT INTO " & DbTableAccount.TABLE_ACCOUNT & " (" & DbTableAccount.COLUMN_F_NAME & ", " & DbTableAccount.COLUMN_L_NAME & ", " & DbTableAccount.COLUMN_EMAIL & ", " & DbTableAccount.COLUMN_PASSWORD & ", " & DbTableAccount.COLUMN_DISPLAY_NAME & ", " & DbTableAccount.COLUMN_SENDER_NAME & ") VALUES ('" & user.f_name & "', '" & user.l_name & "', '" & user.email & "', '" & user._pwd & "', '" & user.display_name & "', '" & user.display_name & "')"
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
