Imports System.Net.Mail

Public Class Mail

    'Private Sub Mail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    'MailSend("送信先アドレス","bks.schedule.app@gmail.com","bksscheduleapp","件名","本文")
    'End Sub

    'Private Sub MailSend("Toアドレス","件名","本文")
    Private Sub MailSend(ByVal ToAddress As String,
                             ByVal SendSubject As String,
                             ByVal SendMessage As String)

        'FromメールアドレスとPW(定数)
        Const FromAddress As String = "bks.schedule.app@gmail.com"
        Const FromAddressPass As String = "bksscheduleapp"

        Dim msg As System.Net.Mail.MailMessage
        Try
            msg = New System.Net.Mail.MailMessage(FromAddress, ToAddress, SendSubject, SendMessage)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub

        End Try

        Dim sc As New System.Net.Mail.SmtpClient()
        Dim res As String
        'gmailのSMTPサーバの設定
        sc.Host = "smtp.gmail.com"
        sc.Port = 587
        sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
        'ユーザー名,パスワード
        sc.Credentials = New System.Net.NetworkCredential(FromAddress, FromAddressPass)
        'SSL
        sc.EnableSsl = True
        sc.Timeout = 10000
        Try
            sc.Send(msg)
            res = "送信に成功しました。"
        Catch ex As SmtpException
            res = ex.Message
        End Try
        msg.Dispose()
        MsgBox(res)
    End Sub


End Class
