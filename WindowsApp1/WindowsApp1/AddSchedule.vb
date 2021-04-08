Imports MySql.Data.MySqlClient
Public Class AddSchedule


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim selected_date = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        Dim selected_time1 = NumericUpDown1.Value.ToString() + ":" + NumericUpDown2.Value.ToString()

        Dim selected_time2 = NumericUpDown3.Value.ToString() + ":" + NumericUpDown4.Value.ToString()

        Dim ins_id = Double.Parse(Format(Now(), "hhmmssfff")).ToString()

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

        Dim SqlStr = "SELECT * FROM Schedule"
        Dim SqlStr2 = "insert into Schedule values('" + ins_id + "','" + selected_time2 + "','" + selected_date + "','" + selected_time1 + "','" + selected_time2 + "')"

        Dim adapter2 = New MySqlDataAdapter(SqlStr2, Con)
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)

        Dim Ds As New DataSet
        Dim dt As New DataTable
        adapter2.Fill(dt)
        Adapter.Fill(Ds)

        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim selected_startdate = MonthCalendar1.SelectionRange.Start.ToString()
        Dim selected_enddate = MonthCalendar1.SelectionRange.End.ToString()
        DateTimePicker1.Value = selected_startdate
        DateTimePicker2.Value = selected_enddate



    End Sub
End Class