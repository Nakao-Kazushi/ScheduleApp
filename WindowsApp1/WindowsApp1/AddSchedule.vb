Imports MySql.Data.MySqlClient
Public Class AddSchedule


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Builder = New MySqlConnectionStringBuilder()
        ' データベースに接続するために必要な情報をBuilderに与える
        Builder.Server = "localhost"
        Builder.Port = 3306
        Builder.UserID = "BKSSCHEDULE"
        Builder.Password = "bksscd"
        Builder.Database = "BKSSCHEDULEdb"
        Dim ConStr = Builder.ToString()
        Dim Con As New MySqlConnection
        Con.ConnectionString = ConStr
        Con.Open()
        Dim SqlStr = "SELECT * FROM users"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Ds As New DataSet
        Adapter.Fill(Ds)
        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()

    End Sub
End Class