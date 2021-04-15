Imports MySql.Data.MySqlClient
Public Class AddSchedule
    '画面ロード時
    Private Sub AddSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DB接続
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

        Dim SqlStr = "select regist_startdate as 開始日,regist_enddate as 終了日,regist_starttime as 開始時間,regist_endtime as 終了時間, event_name As イベント,insert_id As 登録ID from Schedule where regist_startdate >= CURDATE() order by regist_startdate asc"


        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)

        Dim Ds As New DataSet

        Adapter.Fill(Ds)

        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()

    End Sub

    '登録ボタン押下時
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '開始日付取得
        Dim selected_startdate = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        '終了日付取得
        Dim selected_enddate = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        '開始時間取得
        Dim selected_starttime = ComboBox1.Text + ":" + ComboBox2.Text
        '終了時間取得
        Dim selected_endtime = ComboBox3.Text + ":" + ComboBox4.Text
        'Insert_id取得
        Dim ins_id = Double.Parse(Format(Now(), "hhmmssfff")).ToString()
        'イベント名取得
        Dim event_naiyou = TextBox1.Text

        'DB接続
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

        Dim SqlStr = "select regist_startdate as 開始日,regist_enddate as 終了日,regist_starttime as 開始時間,regist_endtime as 終了時間, event_name As イベント,insert_id As 登録ID from Schedule where regist_startdate >= CURDATE() order by regist_startdate asc"
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

    ' カレンダー選択日付の変更時
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        ' 選択日付開始日取得
        Dim selected_startdate = MonthCalendar1.SelectionRange.Start.ToString()
        ' 選択日付終了日取得
        Dim selected_enddate = MonthCalendar1.SelectionRange.End.ToString()

        '登録日付の開始日にセット
        DateTimePicker1.Value = selected_startdate
        '登録日付の終了日にセット
        DateTimePicker2.Value = selected_enddate

        'DB接続
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
        Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間, event_name As イベント,insert_id As 登録ID from Schedule
        where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'order by regist_startdate asc"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Ds As New DataSet
        Adapter.Fill(Ds)
        DataGridView1.DataSource = Ds.Tables(0)

        Con.Close()

    End Sub

    'スケジュール表示画面列選択時
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        '「UppSchedule」フォームのインスタンス取得
        Dim uppfm As UppSchedule = New UppSchedule
        '「UppSchedule」フォームの表示
        uppfm.ShowDialog(Me)

        '画面遷移時のカレンダー選択範囲の取得
        Dim selected_startdate = MonthCalendar1.SelectionRange.Start.ToString()
        Dim selected_enddate = MonthCalendar1.SelectionRange.End.ToString()

        'DB接続
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
        Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間, event_name As イベント,insert_id As 登録ID  from Schedule
        where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'order by regist_startdate asc"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Ds As New DataSet
        Adapter.Fill(Ds)
        DataGridView1.DataSource = Ds.Tables(0)
        Con.Close()

    End Sub

    'スケジュール開始日のプロパティ
    Public Property startdateproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(1).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(1).Value = Value
        End Set
    End Property
    'スケジュール終了日のプロパティ
    Public Property enddateproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(2).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(2).Value = Value
        End Set
    End Property
    'スケジュール開始時間のプロパティ
    Public Property starttimeproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(3).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(3).Value = Value
        End Set
    End Property
    'スケジュール終了時間のプロパティ
    Public Property endtimeproperty() As String

        Get
            Return DataGridView1.CurrentRow.Cells(4).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(4).Value = Value
        End Set
    End Property
    'イベント名のプロパティ
    Public Property event_nameproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(5).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(5).Value = Value
        End Set
    End Property
    'insert_idのプロパティ
    Public Property insert_idproperty() As String
        Get
            Return DataGridView1.CurrentRow.Cells(6).Value.ToString()
        End Get
        Set(Value As String)
            DataGridView1.CurrentRow.Cells(6).Value = Value
        End Set
    End Property

End Class