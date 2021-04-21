Imports System.Net.Mail

Public Class Mail

    'Private Sub MailSend("Toアドレス")
    Public Sub MailSend(ByVal ToAddress As String, ByVal Send_Message As String)

        Const FROMADDRESS As String = "bks.schedule.app@gmail.com"          'Fromアドレス
        Const FROMADDRESSPASS As String = "bksscheduleapp"                  'パスワード
        Const SENDSUBJECT As String = "パスワード再設定"                    '件名
        Dim SendMessage As String = "
        パスワード再設定には、以下の仮パスワードを入力してください。           
                                    
        認証コード：" + Send_Message                                        '本文

        Dim msg As System.Net.Mail.MailMessage
        Try
            msg = New System.Net.Mail.MailMessage(FROMADDRESS, ToAddress, SENDSUBJECT, SendMessage)
        Catch ex As Exception
            Dim results As DialogResult = MessageBox.Show(ex.Message)
            Exit Sub

        End Try

        Dim sc As New System.Net.Mail.SmtpClient()
        Dim res As String
        'gmailのSMTPサーバの設定
        sc.Host = "smtp.gmail.com"
        sc.Port = 587
        sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
        'ユーザー名,パスワード
        sc.Credentials = New System.Net.NetworkCredential(FROMADDRESS, FROMADDRESSPASS)
        'SSL
        sc.EnableSsl = True
        sc.Timeout = 10000
        Try
            sc.Send(msg)
            res = "メールを送信しました。"
        Catch ex As SmtpException
            res = ex.Message
        End Try
        msg.Dispose()
        Dim result As DialogResult = MessageBox.Show(res, "送信連絡", MessageBoxButtons.OK)

    End Sub
End Class
