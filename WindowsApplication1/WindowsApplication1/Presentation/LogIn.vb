Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Globalization
Imports System.Text.RegularExpressions
Public Class LogIn
    Dim dbOperation As DBTableAccountOperations = New DBTableAccountOperations()
    Dim invalid As Boolean = False

    Private Sub TxtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFirstName.TextChanged
        TxtDisplayName.Text = TxtFirstName.Text
    End Sub

    Private Sub TxtEmail_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmail.MouseLeave
        If IsValidEmail(TxtEmail.Text) Then
            If (TxtEmail.Text.Contains("gmail")) Then
                TxtEmail.ForeColor = Color.Green
            Else
                MsgBox(Utils.VERSION_SUPPORT, MsgBoxStyle.Information, Utils.VERSION_INFO)
            End If
        Else
            TxtEmail.ForeColor = Color.Red
        End If

    End Sub

    Public Function IsValidEmail(ByVal strIn As String) As Boolean
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        ' Use IdnMapping class to convert Unicode domain names. 
        Try
            strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf Me.DomainMapper, RegexOptions.None)
        Catch e As Exception
            Return False
        End Try

        If invalid Then Return False

        ' Return true if strIn is in valid e-mail format. 
        Try
            Return Regex.IsMatch(strIn,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" &
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase)
        Catch e As Exception
            Return False
        End Try
    End Function

    Private Function DomainMapper(ByVal match As Match) As String
        ' IdnMapping class with default property values. 
        Dim idn As New IdnMapping()

        Dim domainName As String = match.Groups(2).Value
        Try
            domainName = idn.GetAscii(domainName)
        Catch e As ArgumentException
            invalid = True
        End Try
        Return match.Groups(1).Value + domainName
    End Function

    Private Sub BtnSubmitAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmitAccount.Click
        'First Name should not be empty
        If TxtFirstName.Text.Length = 0 Then
            MsgBox(Utils.FIRST_NAME_EMPTY_ERROR, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
            'Last Name should not be empty
        ElseIf TxtLastName.Text.Length = 0 Then
            MsgBox(Utils.LAST_NAME_EMPTY_ERROR, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
            'Email should not be empty and invalid as well
        ElseIf TxtEmail.Text.Length = 0 And Not IsValidEmail(TxtEmail.Text) Then
            MsgBox(Utils.EMAIL_NOT_VALID_ERROR, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
            'password should not be empty
        ElseIf TxtPassword.Text.Length = 0 Then
            MsgBox(Utils.PASSWORD_EMPTY_ERROR, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
            'Display name should not be empty and invalid as well
        ElseIf TxtDisplayName.Text.Length = 0 Then
            MsgBox(Utils.DISPLAY_NAME_EMPTY_ERROR, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
        Else
            Try
                'Check if user already exists
                If (Not dbOperation.isUserExists(TxtEmail.Text)) Then
                    Dim user As User
                    user = New User(0, TxtFirstName.Text, TxtLastName.Text, TxtEmail.Text, TxtPassword.Text, TxtDisplayName.Text, TxtDisplayName.Text, "", 0, 0)
                    If (dbOperation.insertUser(user)) Then
                        My.Settings.currentUserEmail = user.email
                        My.Settings.currentUserPassword = user._pwd
                        My.Settings.Save()
                        MsgBox(Utils.ACCOUNT_ADDED, MsgBoxStyle.Information, Utils.SUCCESS_DIALOG_TITLE)
                        Me.Close()
                    Else
                        'MsgBox(Utils.EMAIL_EXISTS, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
                        'TxtEmail.Text = ""
                        'TxtPassword.Text = ""
                    End If
                Else
                    MsgBox(Utils.EMAIL_EXISTS, MsgBoxStyle.Critical, Utils.ERROR_DIALOG_TITLE)
                    TxtEmail.Text = ""
                    TxtPassword.Text = ""
                End If
            Catch ex As Exception
                'MsgBox("Aategory Failed to add!!" + ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        'If (dbOperation.truncateUserTable()) Then
        'MsgBox("Truncated", MsgBoxStyle.MsgBoxHelp, "Success")
        'End If

        Me.Close()
    End Sub
End Class
