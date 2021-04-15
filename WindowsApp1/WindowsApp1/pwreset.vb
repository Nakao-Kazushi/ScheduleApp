Imports MySql.Data.MySqlClient

Public Class Form1

    Private Sub PwResetButton_Click(sender As Object, e As EventArgs) Handles PwResetButton.Click

        '//user_Idを変数に代入
        Dim userId As String = TextUserId.Text

        '//エラーチェック
        Dim errorMsg As String = ""

        'userIdがNullか空白の時
        If String.IsNullOrEmpty(userId) Then

            errorMsg += "ユーザID" + Environment.NewLine

            ' テキストボックスの枠線を変える
            TextUserId.CustomBorderColor = Color.Red
        Else
            TextUserId.CustomBorderColor = Color.Gray
        End If

        If String.IsNullOrEmpty(errorMsg) Then

            'メールアドレス形式か調べる
            If Not System.Text.RegularExpressions.Regex.IsMatch(TextUserId.Text, "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
                                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then

                ' テキストボックスの枠線を変える
                TextUserId.CustomBorderColor = Color.Red

                MessageBox.Show("ユーザーIDにはメールアドレスを入力してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                ' テキストボックスの枠線を変える
                TextUserId.CustomBorderColor = Color.Gray

                'メッセージボックスを表示する 
                Dim result As DialogResult = MessageBox.Show("パスワード再設定メールを送信しますか？", "質問",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2)

                'メッセージボックスで「はい」を選択
                If result = DialogResult.Yes Then

                    Dim r As New Random
                    Dim arrNum(3) As String
                    Dim SendMessage As String = ""

                    For i = 0 To 3

                        Dim number1 As Integer = r.Next(1, 9)

                        arrNum(i) = number1.ToString

                        SendMessage += arrNum(i)

                    Next i

                    'Mail送信クラスを呼び出す
                    Dim mail As New Mail
                    mail.MailSend(userId, SendMessage)

                End If
            End If

        Else
            ' 未入力エラーメッセージを表示
            MessageBox.Show(errorMsg + "が未入力です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub PwUpdateButton_Click(sender As Object, e As EventArgs) Handles PwUpdateButton.Click

        '//user_Idを変数に代入
        Dim userId As String = TextUserId.Text

        '//pwを変数に代入
        Dim password As String = TextPw.Text

        '//エラーチェック
        Dim errorMsg As String = ""

        '//DB接続
        Const sLogin As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

        Dim Conn As New MySqlConnection(sLogin)

        'userIdがNullか空白ではない時
        If String.IsNullOrEmpty(userId) Then

            errorMsg += "ユーザID" + Environment.NewLine

            ' テキストボックスの枠線を変える
            TextUserId.CustomBorderColor = Color.Red
        Else
            TextUserId.CustomBorderColor = Color.Gray
        End If

        'passwordがNullか空白ではない時
        If String.IsNullOrEmpty(password) Then

            errorMsg += "Password" + Environment.NewLine

            ' テキストボックスの枠線を変える
            TextPw.CustomBorderColor = Color.Red
        Else
            TextPw.CustomBorderColor = Color.Gray
        End If

        If String.IsNullOrEmpty(errorMsg) Then

            'メールアドレス形式か調べる
            If Not System.Text.RegularExpressions.Regex.IsMatch(TextUserId.Text, "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
                                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then

                ' テキストボックスの枠線を変える
                TextUserId.CustomBorderColor = Color.Red

                MessageBox.Show("ユーザーIDにはメールアドレスを入力してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                ' テキストボックスの枠線を変える
                TextUserId.CustomBorderColor = Color.Gray

                'メッセージボックスを表示する 
                Dim result As DialogResult = MessageBox.Show("Passwordを再登録しますか？", "質問",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2)

                'メッセージボックスで「はい」を選択
                If result = DialogResult.Yes Then

                    '//SQL文発行
                    Dim sql As String = "UPDATE user
                                         SET password = @pw
                                         WHERE user_id = @id"

                    Dim cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = TextUserId.Text
                    cmd.Parameters.Add("@pw", MySqlDbType.VarChar).Value = TextPw.Text
                    Dim adapter = New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable

                    Try
                        Conn.Open()
                        adapter.Fill(dt)

                        MessageBox.Show("Password更新完了", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.None)

                    Catch mse As MySqlException
                        MessageBox.Show("Error:" + mse.Message)

                    Finally
                        Conn.Close()
                    End Try
                End If
            End If

        Else
            ' 未入力エラーメッセージを表示
            MessageBox.Show(errorMsg + "が未入力です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub
End Class