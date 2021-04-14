Imports MySql.Data.MySqlClient
Public Class AddSchedule


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim selected_startdate = Format(DateTimePicker1.Value, "yyyy/MM/dd")

        Dim selected_enddate = Format(DateTimePicker2.Value, "yyyy/MM/dd")

        Dim selected_starttime = ComboBox1.Text + ":" + ComboBox2.Text

        Dim selected_endtime = ComboBox3.Text + ":" + ComboBox4.Text

        Dim ins_id = Double.Parse(Format(Now(), "hhmmssfff")).ToString()

        Dim event_naiyou = TextBox1.Text

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

        Dim SqlStr = "select regist_startdate as 開始日,regist_enddate as 終了日,regist_starttime as 開始時間,regist_endtime as 終了時間, event_name As イベント,insert_id from Schedule"
        Dim SqlStr2 = "insert into Schedule values('" + ins_id + "','" + selected_endtime + "','" + selected_startdate + "','" + selected_starttime + "','" + selected_endtime + "','" + selected_enddate + "','" + event_naiyou + "')"

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
        Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間, event_name As イベント,insert_id from Schedule
        where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Ds As New DataSet
        Adapter.Fill(Ds)
        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim uppfm As UppSchedule = New UppSchedule

        uppfm.ShowDialog(Me)

        Dim ins_id = DataGridView1.CurrentRow.Cells(6).Value.ToString()

        Dim selectedrowno = DataGridView1.CurrentRow.Index

        Dim dgv As DataGridView = CType(sender, DataGridView)

        If dgv.Columns(e.ColumnIndex).Name = "Column1" Then

            MessageBox.Show(selectedrowno)

        End If

        Dim selected_startdate = MonthCalendar1.SelectionRange.Start.ToString()
        Dim selected_enddate = MonthCalendar1.SelectionRange.End.ToString()

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
        Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間, event_name As イベント,insert_id from Schedule
        where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Ds As New DataSet
        Adapter.Fill(Ds)
        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()


    End Sub

    Public Property startdateproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(1).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(1).Value = Value
        End Set
    End Property
    Public Property enddateproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(2).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(2).Value = Value
        End Set
    End Property
    Public Property starttimeproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(3).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(3).Value = Value
        End Set
    End Property
    Public Property endtimeproperty() As String

        Get
            Return DataGridView1.CurrentRow.Cells(4).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(4).Value = Value
        End Set
    End Property
    Public Property event_nameproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(5).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(5).Value = Value
        End Set
    End Property
    Public Property insert_idproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(6).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(6).Value = Value
        End Set
    End Property



End Class