Imports MySql.Data.MySqlClient

Public Class AddUser

    Private Sub AddUserButton_Click(sender As Object, e As EventArgs) Handles AddUserButton.Click

        '//user_Idを変数に代入
        Dim userId As String = user_Id.Text

        '//pwを変数に代入
        Dim password As String = pw.Text

        Dim sLogin As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

        Dim Conn As New MySqlConnection(sLogin)

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

    End Sub
End Class