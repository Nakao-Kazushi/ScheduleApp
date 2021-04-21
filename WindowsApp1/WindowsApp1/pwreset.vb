Imports MySql.Data.MySqlClient

Public Class PwReset

    Private Sub PwUpdateButton_Click(sender As Object, e As EventArgs) Handles PwUpdateButton.Click

        '//user_Idを変数に代入
        Dim userId As String = TextUserId.Text

        '//pwを変数に代入
        Dim password As String = TextPw.Text

        '//pwを変数に代入
        Dim password2 As String = TextPw2.Text

        '//エラーチェック
        Dim errorMsg As String = ""

        '//DB接続
        Const sLogin As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

        Dim Conn As New MySqlConnection(sLogin)

        'passwordがNullか空白ではない時
        If String.IsNullOrEmpty(password) Then

            errorMsg += "Password" + Environment.NewLine

            ' テキストボックスの枠線を変える
            TextPw.CustomBorderColor = Color.Red
        Else
            TextPw.CustomBorderColor = Color.Gray
        End If

        'passwordがNullか空白ではない時
        If String.IsNullOrEmpty(password2) Then

            errorMsg += "Password" + Environment.NewLine

            ' テキストボックスの枠線を変える
            TextPw2.CustomBorderColor = Color.Red
        Else
            TextPw2.CustomBorderColor = Color.Gray
        End If

        If String.IsNullOrEmpty(errorMsg) Then

            'Passwordが二つ同じものが入力されているか確認
            If Not password.Equals(password2) Then

                ' テキストボックスの枠線を変える
                TextPw.CustomBorderColor = Color.Red
                TextPw2.CustomBorderColor = Color.Red

                MessageBox.Show("Passwordは2箇所同じものを入力してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                ' テキストボックスの枠線を変える
                TextPw.CustomBorderColor = Color.Gray
                TextPw2.CustomBorderColor = Color.Gray

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

                    '自画面を非表示
                    Me.Close()

                    'Login画面に戻る
                    Dim login As New Login
                    login.Show()

                End If
            End If

        Else
            ' 未入力エラーメッセージを表示
            MessageBox.Show(errorMsg + "が未入力です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub pw_TextChanged(sender As Object, e As EventArgs) Handles TextPw.TextChanged
        ' パスワードをアスタリスク表示にする
        TextPw.PasswordChar = "*"
    End Sub
End Class