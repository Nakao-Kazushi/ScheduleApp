Imports MySql.Data.MySqlClient

Public Class Login
    ' DB接続情報のコンストラクタ
    Const LOGIN As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim Conn As New MySqlConnection(LOGIN)
        ' 実行するSQL文を生成
        Dim sql As String = "SELECT * FROM user WHERE USER_ID = '" + txtUserId.Text + "' AND PASSWORD = '" + txtPassword.Text + "';"
        Dim adapter = New MySqlDataAdapter(sql, Conn)
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
                ' ログイン成功
                If dt.Rows.Count = 1 Then
                    MessageBox.Show("ログイン成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' ログイン情報を保存する
                    SaveLogin()
                    Dim addSchedule As AddSchedule = New AddSchedule()
                    ' スケジュール登録画面に遷移する
                    addSchedule.Show()
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
        addUser.Show()
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
End Class