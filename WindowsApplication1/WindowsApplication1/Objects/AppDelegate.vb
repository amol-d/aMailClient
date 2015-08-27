Public NotInheritable Class AppDelegate
    Private Shared _singleton As AppDelegate
    Private currentUser As User

    Private Sub New()
        'Nothing to do
    End Sub

    Public Shared Function GetSingletonInstance() As AppDelegate
        If _singleton Is Nothing Then
            _singleton = New AppDelegate()
        End If
        Return _singleton
    End Function

    Public Function setCurrentUser(ByVal user As User)
        currentUser = user
        Return Nothing
    End Function
    Public Function getCurrentUser() As User
        Return currentUser
    End Function
End Class
