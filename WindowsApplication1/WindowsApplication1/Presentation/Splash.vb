Public NotInheritable Class Splash

    Dim dbOperation As DBTableAccountOperations = New DBTableAccountOperations()
    Dim user As User

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        'My.Settings.Reset()
        'Copyright info
        Copyright.Text = "Get your mails on the go"   'My.Application.Info.Copyright
        timerProgress.Start()
    End Sub

    Private Sub timerProgress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerProgress.Tick
        If pbStartUp.Value < pbStartUp.Maximum Then
            pbStartUp.Value += 20
        End If
        If pbStartUp.Value = pbStartUp.Maximum Then
            Dim email As String = My.Settings.currentUserEmail
            Dim password As String = My.Settings.currentUserPassword
            If email = "" And password = "" Then
                LogIn.Show()
            Else
                user = dbOperation.getCurrentUser(email)
                AppDelegate.GetSingletonInstance().setCurrentUser(user)
                MailViewer.Show()
            End If
            Me.Close()
        End If
    End Sub
End Class
