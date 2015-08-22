Public Class splash


    Private Sub progressTimertask_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progressTimertask.Tick
        If pbStartUp.Value < pbStartUp.Maximum Then
            pbStartUp.Value += 1
            Console.WriteLine(pbStartUp.Value)
        End If
    End Sub

    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbStartUp.Show()
        progressTimertask.Start()
    End Sub
End Class
