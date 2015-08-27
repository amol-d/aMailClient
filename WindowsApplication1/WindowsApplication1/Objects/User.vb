Public Class User
    Public f_name, l_name, email, _pwd, display_name, sender_name, signature As String
    Public acID As Integer
    Public new_message_count As Integer
    Public sync_interval As Integer
    Public Sub New()

    End Sub
    Public Sub New(ByVal acID As Integer, ByVal f_name As String, ByVal l_name As String, ByVal email As String, ByVal _pwd As String, ByVal display_name As String, ByVal sender_name As String, ByVal signature As String, ByVal sync_interval As Integer, ByVal new_message_count As Integer)
        Me.acID = acID
        Me.f_name = f_name
        Me.l_name = l_name
        Me.email = email
        Me._pwd = _pwd
        Me.display_name = display_name
        Me.sender_name = sender_name
        Me.signature = signature
        Me.new_message_count = new_message_count
        Me.sync_interval = sync_interval
    End Sub

End Class
