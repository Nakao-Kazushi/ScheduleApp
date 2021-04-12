Imports MySql.Data.MySqlClient
Public Class AddSchedule


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim selected_startdate = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        Dim selected_enddate = Format(DateTimePicker2.Value, "yyyy/MM/dd")

        Dim selected_starttime = NumericUpDown1.Value.ToString() + ":" + NumericUpDown2.Value.ToString()

        Dim selected_endtime = NumericUpDown3.Value.ToString() + ":" + NumericUpDown4.Value.ToString()

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

        Dim SqlStr = "select regist_startdate as 開始日,regist_enddate as 終了日,regist_starttime as 開始時間,regist_endtime as 終了時間 from Schedule"
        Dim SqlStr2 = "insert into Schedule values('" + ins_id + "','" + selected_endtime + "','" + selected_startdate + "','" + selected_starttime + "','" + selected_endtime + "','" + selected_enddate + "')"

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
        Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間 from Schedule
        where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Ds As New DataSet
        Adapter.Fill(Ds)
        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim OrderNo As String, OrderDate As String, DueDate As String, ProductNo As String, selectedrowno As Integer

        Dim uppfm As Form1 = New Form1


        uppfm.ShowDialog()


        OrderNo = DataGridView1.CurrentRow.Cells(2).Value.ToString()

        OrderDate = DataGridView1.CurrentRow.Cells(3).Value.ToString()

        DueDate = DataGridView1.CurrentRow.Cells(4).Value.ToString()

        ProductNo = DataGridView1.CurrentRow.Cells(5).Value.ToString()

        selectedrowno = DataGridView1.CurrentRow.Index

        Dim dgv As DataGridView = CType(sender, DataGridView)

        If dgv.Columns(e.ColumnIndex).Name = "Column1" Then

            MessageBox.Show(selectedrowno)

        End If


    End Sub
End Class