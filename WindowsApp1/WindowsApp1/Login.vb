Imports MySql.Data.MySqlClient


Public Class Login
    ' DB接続情報を取得する
    Dim Login As String = CommonClass.ConnectionString()

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim Conn As New MySqlConnection(Login)

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

            ' ユーザIDの未入力チェックを実施
            errorMsg = CommonClass.NotInputError("ユーザID", errorMsg, txtUserId)

            ' Passwordの未入力チェックを実施
            errorMsg = CommonClass.NotInputError("Password", errorMsg, txtPassword)

            ' エラーが発生していない場合
            If String.IsNullOrEmpty(errorMsg) Then
                ' ユーザIDがメールアドレスかをチェックする
                If Not CommonClass.CheckMailAddress(txtUserId.Text) Then
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

    ' userIdのプロパティ
    Public Property userIdProperty() As String
        Get
            Return txtUserId.Text
        End Get
        Set(Value As String)
            txtUserId.Text = Value
        End Set
    End Property

End Class