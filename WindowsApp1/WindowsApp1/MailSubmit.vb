Imports MySql.Data.MySqlClient
Public Class MailSubmit

    Private Sub MailSubButton_Click(sender As Object, e As EventArgs) Handles MailSubButton.Click

        Dim mailadress As String = TextMailaddress.Text

        '//エラーチェック
        Dim errorMsg As String = ""

        'userIdがNullか空白の時
        If String.IsNullOrEmpty(mailadress) Then

            errorMsg += "ユーザID" + Environment.NewLine

            ' テキストボックスの枠線を変える
            TextMailaddress.CustomBorderColor = Color.Red
        Else
            TextMailaddress.CustomBorderColor = Color.Gray
        End If

        If String.IsNullOrEmpty(errorMsg) Then

            'メールアドレス形式か調べる
            If Not System.Text.RegularExpressions.Regex.IsMatch(TextMailaddress.Text, "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
                                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then

                ' テキストボックスの枠線を変える
                TextMailaddress.CustomBorderColor = Color.Red

                MessageBox.Show("空白にはメールアドレスを入力してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ' テキストボックスの枠線を変える
                TextMailaddress.CustomBorderColor = Color.Gray

                '入力されたメールアドレスが登録されているか確認
                Dim dt As New DataTable
                Adresscheck(dt)

                ' メールアドレスがDBに登録されているか
                If dt.Rows.Count = 1 Then

                    'メッセージボックスを表示する
                    Dim result As DialogResult = MessageBox.Show("認証コードをメールで送信しますか？", "質問",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2)

                    'メッセージボックスで「はい」を選択
                    If result = DialogResult.Yes Then

                        '4桁の認証コードをランダム生成する
                        Dim r As New Random
                        Dim arrNum(3) As String
                        Dim SendMessage As String = ""

                        For i = 0 To 3

                            Dim number1 As Integer = r.Next(1, 9)

                            arrNum(i) = number1.ToString

                            SendMessage += arrNum(i)

                        Next i

                        'Mailクラスを呼び出す
                        'mail.MailSend(送信先メールアドレス、認証コード)
                        Dim mail As New Mail
                        mail.MailSend(mailadress, SendMessage)

                        Dim code As String
                        code = InputBox("メールを確認し、認証コードを入力してください。", "認証コード確認")

                        '認証コードが空白、Nullの時
                        If String.IsNullOrEmpty(code) Then

                            ' 未入力エラーメッセージを表示
                            MessageBox.Show("認証コードが未入力です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf SendMessage.Equals(code) Then
                            MessageBox.Show("認証コード一致")

                            'パスワード再設定画面を表示
                            Dim pwreset As PwReset = New PwReset()
                            pwreset.TextUserId.Text = mailadress

                            Me.Visible() = False
                            pwreset.ShowDialog()
                            pwreset.Dispose()

                        Else
                            ' 未入力エラーメッセージを表示
                            MessageBox.Show("認証コードが間違っています。認証コードを再発行してください。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                    End If
                Else
                    MessageBox.Show("そのユーザは登録されていません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            ' 未入力エラーメッセージを表示
            MessageBox.Show(errorMsg + "が未入力です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    'アドレスが登録されているか確認するメソッド
    Private Sub Adresscheck(dt)

        ' DB接続情報を取得する
        Dim Login As String = CommonClass.ConnectionString()
        Dim Conn As New MySqlConnection(Login)

        ' 実行するSQL文を生成
        Dim sql As String = "SELECT * FROM user WHERE USER_ID = @id;"
        Dim cmd As New MySqlCommand(sql, Conn)
        cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = TextMailaddress.Text

        Dim adapter = New MySqlDataAdapter(cmd)

        Try
            ' DBと接続する
            Conn.Open()
            ' SQL文の実行結果をデータテーブルに格納する
            adapter.Fill(dt)

        Catch mse As MySqlException
            MessageBox.Show("Error:" + mse.Message)
        Finally
            ' DBとの接続をcloseする
            Conn.Close()
        End Try
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Dim Login As Login = New Login()
        Me.Visible() = False
        Login.Show()
    End Sub
End Class