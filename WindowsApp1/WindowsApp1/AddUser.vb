Imports MySql.Data.MySqlClient

Public Class AddUser

    Private Sub AddUserButton_Click(sender As Object, e As EventArgs) Handles AddUserButton.Click

        '//user_Idを変数に代入
        Dim userId As String = user_Id.Text

        '//pwを変数に代入
        Dim password As String = pw.Text

        '//エラーチェック
        Dim errorMsg As String = ""

        '//DB接続
        Const sLogin As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

        'userIdがNullか空白ではない時
        If String.IsNullOrEmpty(userId) Then

            errorMsg += "ユーザID" + Environment.NewLine

            ' テキストボックスの枠線を変える
            user_Id.CustomBorderColor = Color.Red
        Else
            user_Id.CustomBorderColor = Color.Gray
        End If

        'passwordがNullか空白ではない時
        If String.IsNullOrEmpty(password) Then

            errorMsg += "Password" + Environment.NewLine

            ' テキストボックスの枠線を変える
            pw.CustomBorderColor = Color.Red
        Else
            pw.CustomBorderColor = Color.Gray
        End If


        If String.IsNullOrEmpty(errorMsg) Then

            'メールアドレス形式か調べる
            If Not System.Text.RegularExpressions.Regex.IsMatch(user_Id.Text, "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
                                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then

                ' テキストボックスの枠線を変える
                user_Id.CustomBorderColor = Color.Red

                MessageBox.Show("ユーザーIDにはメールアドレスを入力してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                ' テキストボックスの枠線を変える
                user_Id.CustomBorderColor = Color.Gray

                'メッセージボックスを表示する 
                Dim result As DialogResult = MessageBox.Show("登録しますか？", "質問",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2)

                'メッセージボックスで「はい」を選択
                If result = DialogResult.Yes Then

                    Dim Conn As New MySqlConnection(sLogin)

                    '//SQL文発行
                    Dim sql As String = "insert into user values (@id,@pw)"

                    Dim cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = user_Id.Text
                    cmd.Parameters.Add("@pw", MySqlDbType.VarChar).Value = pw.Text

                    Dim adapter = New MySqlDataAdapter(cmd)

                    Dim dt As New DataTable

                    Try
                        Conn.Open()
                        adapter.Fill(dt)

                        MessageBox.Show("登録完了", "",
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

    '戻るボタン押下時
    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click

        '自画面を非表示
        Me.Close()

    End Sub
End Class