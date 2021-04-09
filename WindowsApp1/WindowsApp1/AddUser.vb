Imports MySql.Data.MySqlClient

Public Class AddUser

    Private Sub AddUserButton_Click(sender As Object, e As EventArgs) Handles AddUserButton.Click

        '//user_Idを変数に代入
        Dim userId As String = user_Id.Text

        '//pwを変数に代入
        Dim password As String = pw.Text

        '//DB接続
        Dim sLogin As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

        Dim Conn As New MySqlConnection(sLogin)

        'userIdとpasswordがNullか空白ではない時
        If Not String.IsNullOrEmpty(userId) And Not String.IsNullOrEmpty(password) Then

            'メールアドレス形式か調べる
            If System.Text.RegularExpressions.Regex.IsMatch(user_Id.Text, "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
                                                    System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then

                'メッセージボックスを表示する 
                Dim result As DialogResult = MessageBox.Show("登録しますか？", "質問",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button2)

                'メッセージボックスで「はい」を選択
                If result = DialogResult.Yes Then

                    '//SQL文発行
                    Dim sql As String = "insert into user values ('@id','@pw')"

                    Dim cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = user_Id.Text
                    cmd.Parameters.Add("@pw", MySqlDbType.VarChar).Value = pw.Text
                    Dim adapter = New MySqlDataAdapter(cmd)

                    Try
                        Conn.Open()

                    Catch mse As MySqlException
                        MessageBox.Show("Error:" + mse.Message)
                    Finally
                        Conn.Close()
                    End Try

                    MessageBox.Show("登録完了", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.None)
                End If

            Else
                ' テキストボックスの枠線を変える
                pw.CustomBorderColor = Color.Gray
                user_Id.CustomBorderColor = Color.Red

                MessageBox.Show("ユーザーIDにはメールアドレスを入力してください。", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf userId = "" And password = "" Then

            ' テキストボックスの枠線を赤くする
            user_Id.CustomBorderColor = Color.Red
            pw.CustomBorderColor = Color.Red

            MessageBox.Show("入力エラーです。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf userId = "" Then

            ' テキストボックスの枠線を変える
            pw.CustomBorderColor = Color.Gray
            user_Id.CustomBorderColor = Color.Red

            MessageBox.Show("ユーザーIDが未入力です。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf password = "" Then

            ' テキストボックスの枠線を変える
            user_Id.CustomBorderColor = Color.Gray
            pw.CustomBorderColor = Color.Red

            MessageBox.Show("パスワードが未入力です。", "エラー",
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

    Private Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class