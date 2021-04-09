Imports MySql.Data.MySqlClient

Public Class Login
    ' DB接続情報のコンストラクタ
    Const LOGIN As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim Conn As New MySqlConnection(LOGIN)

        ' 実行するSQL文を生成
        Dim sql As String = "SELECT * FROM user WHERE USER_ID = @id AND PASSWORD = @pw;"
        Dim cmd As New MySqlCommand(sql, Conn)
        cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = txtUserId.Text
        cmd.Parameters.Add("@pw", MySqlDbType.VarChar).Value = txtPassword.Text
        Dim adapter = New MySqlDataAdapter(cmd)
        ' データテーブルを作成
        Dim dt As New DataTable
        Dim errorMsg As String = ""
        Try
            ' DBと接続する
            Conn.Open()
            ' SQL文の実行結果をデータテーブルに格納する
            adapter.Fill(dt)
            ' ユーザID未入力チェック
            If String.IsNullOrEmpty(txtUserId.Text) Then
                errorMsg += "ユーザID" + Environment.NewLine
                ' テキストボックスの枠線を赤くする
                txtUserId.CustomBorderColor = Color.Red
            Else
                txtUserId.CustomBorderColor = Color.Gray
            End If

            ' パスワード未入力チェック
            If String.IsNullOrEmpty(txtPassword.Text) Then
                errorMsg += "Password" + Environment.NewLine
                ' テキストボックスの枠線を赤くする
                txtPassword.CustomBorderColor = Color.Red
            Else
                txtPassword.CustomBorderColor = Color.Gray
            End If
            ' エラーが発生していない場合
            If String.IsNullOrEmpty(errorMsg) Then
                ' ユーザIDがメールアドレスかをチェックする
                If Not CheckMailAddress(txtUserId.Text) Then
                    MessageBox.Show("ユーザIDにはメールアドレスを入力してください", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ' テキストボックスの枠線を赤くする
                    txtUserId.CustomBorderColor = Color.Red
                    Return
                Else
                    txtUserId.CustomBorderColor = Color.Gray
                End If
                ' ログイン成功
                If dt.Rows.Count = 1 Then
                    MessageBox.Show("ログイン成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' ログイン情報を保存する
                    SaveLogin()
                    Dim addSchedule As AddSchedule = New AddSchedule()
                    ' スケジュール登録画面に遷移する
                    Me.Visible() = False
                    addSchedule.ShowDialog()
                    addSchedule.Dispose()
                    Me.Visible() = True
                    'addSchedule.Show()
                Else
                    MessageBox.Show("そのユーザは登録されていません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' 未入力エラーメッセージを表示
                MessageBox.Show(errorMsg + "が未入力です", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch mse As MySqlException
            MessageBox.Show("Error:" + mse.Message)
        Finally
            ' DBとの接続をcloseする
            Conn.Close()
        End Try
    End Sub

    Private Sub lnkAddUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddUser.LinkClicked
        ' 初回ログイン者用のユーザ登録ページに遷移させる
        Dim addUser As AddUser = New AddUser()
        Me.Visible() = False
        'addUser.Show()
        addUser.ShowDialog()
        addUser.Dispose()
        Me.Visible() = True
    End Sub

    '''<summary>
    '''ログイン情報を保存する
    '''</summary>
    Private Sub SaveLogin()
        If chkSaveLogin.Checked Then
            ' チェックが入っていれば入力されたログイン情報を保存する
            My.Settings.userId = txtUserId.Text
            My.Settings.password = txtPassword.Text
        Else
            ' チェックが入っていなければ""を保存する
            My.Settings.userId = ""
            My.Settings.password = ""
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' フォーム読み込み時、保存されたユーザID・パスワードを設定する
        txtUserId.Text = My.Settings.userId
        txtPassword.Text = My.Settings.password
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        ' パスワードをアスタリスク表示にする
        txtPassword.PasswordChar = "*"
    End Sub

    ''' <summary>
    ''' テキストがメールアドレスかを確認する 
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns>メールアドレスならtrue,そうでないならfalse</returns>
    Private Function CheckMailAddress(text As String) As Boolean
        '検証する文字列
        Dim address As String = text
        Dim result As Boolean = False
        'メールアドレスか調べる
        Return System.Text.RegularExpressions.Regex.IsMatch(
            address,
            "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
End Class