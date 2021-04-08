Imports MySql.Data.MySqlClient

Public Class AddUser

    Private Sub AddUserButton_Click(sender As Object, e As EventArgs) Handles AddUserButton.Click

        'メールアドレスっぽいか調べる
        If System.Text.RegularExpressions.Regex.IsMatch(user_Id.Text, "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
                                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then

            '//user_Idを変数に代入
            Dim userId As String = user_Id.Text

            '//pwを変数に代入
            Dim password As String = pw.Text

            '//DB接続
            Dim sLogin As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

            Dim Conn As New MySqlConnection(sLogin)

            'userIdとpasswordがNullか空白ではない時
            If Not String.IsNullOrEmpty(userId) And Not String.IsNullOrEmpty(password) Then

                'メッセージボックスを表示する 
                Dim result As DialogResult = MessageBox.Show("登録しますか？", "質問",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button2)

                'メッセージボックスで「はい」を選択
                If result = DialogResult.Yes Then

                    '//SQL文発行
                    Dim sql As String = "insert into user values ('" + userId + "','" + password + "')"

                    Dim adapter = New MySqlDataAdapter(sql, Conn)
                    Dim dt As New DataTable

                    Try
                        Conn.Open()
                        adapter.Fill(dt)

                    Catch mse As MySqlException
                        MessageBox.Show("Error:" + mse.Message)
                    Finally
                        Conn.Close()
                    End Try

                    MessageBox.Show("登録完了", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.None)
                End If

            ElseIf userId = "" And password = "" Then
                MessageBox.Show("入力エラーです。", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf userId = "" Then
                MessageBox.Show("ユーザーIDが未入力です。", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf password = "" Then
                MessageBox.Show("パスワードが未入力です。", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("ユーザーIDにはメールアドレスを入力してください。", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    '戻るボタン押下時
    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click

        '自画面を非表示
        Me.Visible = False

        'Login画面に戻る
        Dim login As New Login
        login.Show()

    End Sub
End Class