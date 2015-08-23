Imports System.Linq

<Serializable()> _
Public Class Email
    Public Sub New()
        Me.Attachments = New List(Of Attachment)()
    End Sub
    Public Property MessageNumber() As Integer
        Get
            Return m_MessageNumber
        End Get
        Set(ByVal value As Integer)
            m_MessageNumber = Value
        End Set
    End Property
    Private m_MessageNumber As Integer
    Public Property From() As String
        Get
            Return m_From
        End Get
        Set(ByVal value As String)
            m_From = Value
        End Set
    End Property
    Private m_From As String
    Public Property Subject() As String
        Get
            Return m_Subject
        End Get
        Set(ByVal value As String)
            m_Subject = Value
        End Set
    End Property
    Private m_Subject As String
    Public Property Body() As String
        Get
            Return m_Body
        End Get
        Set(ByVal value As String)
            m_Body = Value
        End Set
    End Property
    Private m_Body As String
    Public Property DateSent() As DateTime
        Get
            Return m_DateSent
        End Get
        Set(ByVal value As DateTime)
            m_DateSent = Value
        End Set
    End Property
    Private m_DateSent As DateTime
    Public Property Attachments() As List(Of Attachment)
        Get
            Return m_Attachments
        End Get
        Set(ByVal value As List(Of Attachment))
            m_Attachments = Value
        End Set
    End Property
    Private m_Attachments As List(Of Attachment)
End Class

<Serializable()> _
Public Class Attachment
    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set(ByVal value As String)
            m_FileName = Value
        End Set
    End Property
    Private m_FileName As String
    Public Property ContentType() As String
        Get
            Return m_ContentType
        End Get
        Set(ByVal value As String)
            m_ContentType = Value
        End Set
    End Property
    Private m_ContentType As String
    Public Property Content() As Byte()
        Get
            Return m_Content
        End Get
        Set(ByVal value As Byte())
            m_Content = Value
        End Set
    End Property
    Private m_Content As Byte()
End Class