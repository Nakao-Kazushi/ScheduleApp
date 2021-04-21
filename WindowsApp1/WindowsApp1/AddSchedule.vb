Imports MySql.Data.MySqlClient
Public Class AddSchedule

    ' MySQLに接続する
    Private Function SqlConnection() As MySqlConnection
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
        Return Con
    End Function

    ' 登録されているスケジュールを全て表示する
    Public Sub ViewAllSchedules()
        Dim Con As MySqlConnection = SqlConnection()
        Con.Open()
        Dim userId As String = Login.userIdProperty

        Dim SqlStr = "select regist_startdate as 開始日,regist_enddate as 終了日,regist_starttime as 開始時間,regist_endtime as 終了時間, event_name As イベント,insert_id As 登録ID from Schedule where user_id = '" + userId + "' order by regist_startdate asc"

        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)

        Dim Dt As New DataTable

        Adapter.Fill(Dt)
        dgvAllSchedules.DataSource = Dt
        For col As Integer = 2 To dgvAllSchedules.Columns.Count - 1
            ' チェックボックスと詳細ボタン以外を読み取り専用にする
            dgvAllSchedules.Columns(col).ReadOnly = True
            ' カラムサイズをセルの記述内容に合わせて自動調整する
            dgvAllSchedules.Columns(col).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        ' 「イベント」カラムのみDataGridView幅に合わせて自動調整する(カラム幅が大きくなるよ)
        dgvAllSchedules.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' カラム名を中央ぞろえにする
        dgvAllSchedules.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 現在時刻取得
        Dim dtn As DateTime = DateTime.Now
        Dim nowDate As String = dtn.ToString("yyyy/MM/dd")
        Dim startDate As String = ""
        For row As Integer = 0 To dgvAllSchedules.Rows.Count - 1
            startDate = dgvAllSchedules.Rows(row).Cells(2).Value
            If nowDate.CompareTo(startDate) = 1 Then
                dgvAllSchedules.Rows(row).DefaultCellStyle.BackColor = Color.Pink
            End If
        Next
        ' 開始時間・終了時間の初期値を設定
        cmbStartHour.Text = "00"
        cmbStartMinute.Text = "00"
        cmbEndHour.Text = "00"
        cmbEndMinute.Text = "00"

        Con.Close()

    End Sub
    '画面ロード時
    Private Sub AddSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtn As DateTime = DateTime.Now
        dtpStartDate.Value = dtn
        dtpEndDate.Value = dtn
        ScheduleCalendar.TodayDate = dtn
        ViewAllSchedules()
    End Sub

    '登録ボタン押下時
    Private Sub btnAddButton_Click(sender As Object, e As EventArgs) Handles btnAddButton.Click
        Dim result As DialogResult = MessageBox.Show("登録しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        ' Noが選択されたら処理を中断
        If result = DialogResult.No Then
            Return
        End If

        '開始日付取得
        Dim selected_startdate = Format(dtpStartDate.Value, "yyyy/MM/dd")
        '終了日付取得
        Dim selected_enddate = Format(dtpEndDate.Value, "yyyy/MM/dd")
        '開始時間取得
        Dim selected_starttime = cmbStartHour.Text + ":" + cmbStartMinute.Text
        '終了時間取得
        Dim selected_endtime = cmbEndHour.Text + ":" + cmbEndMinute.Text
        'Insert_id取得
        Dim ins_id = Double.Parse(Format(Now(), "hhmmssfff")).ToString()
        'イベント名取得
        Dim event_naiyou = txtDetailedSchedule.Text
        Dim errorMsg As String = ""
        ' 日付エラーが発生した場合処理を中断する
        If Not CommonClass.ScheduleDateCheck(selected_startdate, selected_enddate, selected_starttime, selected_endtime) Then
            Return
        End If
        Dim Con As MySqlConnection = SqlConnection()
        Con.Open()

        'Dim SqlStr = "select regist_startdate as 開始日,regist_enddate as 終了日,regist_starttime as 開始時間,regist_endtime as 終了時間, event_name As イベント,insert_id As 登録ID from Schedule where regist_startdate >= CURDATE() order by regist_startdate asc"
        Dim SqlStr2 = "insert into Schedule values('" + ins_id + "','" + Login.userIdProperty + "','" + selected_startdate + "','" + selected_starttime + "','" + selected_endtime + "','" + selected_enddate + "','" + event_naiyou + "')"

        Dim adapter2 = New MySqlDataAdapter(SqlStr2, Con)
        'Dim Adapter = New MySqlDataAdapter(SqlStr, Con)

        Dim Ds As New DataSet
        Dim dt As New DataTable
        adapter2.Fill(dt)
        'Adapter.Fill(Ds)
        MessageBox.Show("登録完了", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtDetailedSchedule.Text = ""
        ViewAllSchedules()
        'dgvAllSchedules.DataSource = Ds.Tables(0)
        Con.Close()

    End Sub

    ' カレンダー選択日付の変更時
    Private Sub ScheduleCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles ScheduleCalendar.DateChanged
        ' 選択日付開始日取得
        Dim selected_startdate = ScheduleCalendar.SelectionRange.Start.ToString()
        ' 選択日付終了日取得
        Dim selected_enddate = ScheduleCalendar.SelectionRange.End.ToString()

        '登録日付の開始日にセット
        dtpStartDate.Value = selected_startdate
        '登録日付の終了日にセット
        dtpEndDate.Value = selected_enddate

        Dim Con As MySqlConnection = SqlConnection()
        Con.Open()
        Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間, event_name As イベント,insert_id As 登録ID from Schedule
        where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'order by regist_startdate asc"
        Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
        Dim Dt As New DataTable
        Adapter.Fill(Dt)
        dgvAllSchedules.DataSource = Dt

        Con.Close()

    End Sub

    'スケジュール表示画面列選択時
    Private Sub dgvAllSchedules_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAllSchedules.CellContentClick
        ' 詳細ボタン押下時処理
        If e.ColumnIndex = 1 Then
            '「UppSchedule」フォームのインスタンス取得
            Dim uppfm As UppSchedule = New UppSchedule
            uppfm.Loading(Me)
            '「UppSchedule」フォームの表示
            uppfm.ShowDialog()

            ViewAllSchedules()
            ''画面遷移時のカレンダー選択範囲の取得
            'Dim selected_startdate = ScheduleCalendar.SelectionRange.Start.ToString()
            'Dim selected_enddate = ScheduleCalendar.SelectionRange.End.ToString()

            'Dim Con As MySqlConnection = SqlConnection()
            'Con.Open()
            'Dim SqlStr = "select regist_startdate as 開始日, regist_enddate As 終了日, regist_starttime As 開始時間, regist_endtime As 終了時間, event_name As イベント,insert_id As 登録ID  from Schedule
            'where regist_startdate between '" + selected_startdate + "' and '" + selected_enddate + "'order by regist_startdate asc"
            'Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
            'Dim Ds As New DataSet
            'Adapter.Fill(Ds)
            'dgvAllSchedules.DataSource = Ds.Tables(0)
            'Con.Close()
        End If
    End Sub



    'スケジュール開始日のプロパティ
    Public Property startdateproperty() As String
        Get
            Return dgvAllSchedules.CurrentRow.Cells(2).Value.ToString()
        End Get
        Set(Value As String)
            dgvAllSchedules.CurrentRow.Cells(2).Value = Value
        End Set
    End Property
    'スケジュール終了日のプロパティ
    Public Property enddateproperty() As String
        Get
            Return dgvAllSchedules.CurrentRow.Cells(3).Value.ToString()
        End Get
        Set(Value As String)
            dgvAllSchedules.CurrentRow.Cells(3).Value = Value
        End Set
    End Property
    'スケジュール開始時間のプロパティ
    Public Property starttimeproperty() As String
        Get
            Return dgvAllSchedules.CurrentRow.Cells(4).Value.ToString()
        End Get
        Set(Value As String)
            dgvAllSchedules.CurrentRow.Cells(4).Value = Value
        End Set
    End Property
    'スケジュール終了時間のプロパティ
    Public Property endtimeproperty() As String
        Get
            Return dgvAllSchedules.CurrentRow.Cells(5).Value.ToString()
        End Get
        Set(Value As String)
            dgvAllSchedules.CurrentRow.Cells(5).Value = Value
        End Set
    End Property
    'イベント名のプロパティ
    Public Property event_nameproperty() As String
        Get
            Return dgvAllSchedules.CurrentRow.Cells(6).Value.ToString()
        End Get
        Set(Value As String)
            dgvAllSchedules.CurrentRow.Cells(6).Value = Value
        End Set
    End Property
    'insert_idのプロパティ
    Public Property insert_idproperty() As String
        Get
            Return dgvAllSchedules.CurrentRow.Cells(7).Value.ToString()
        End Get
        Set(Value As String)
            dgvAllSchedules.CurrentRow.Cells(7).Value = Value
        End Set
    End Property

    Private Sub btnAllPlans_Click(sender As Object, e As EventArgs) Handles btnViewAllSchedules.Click
        ViewAllSchedules()
    End Sub

    Private Sub dgvAllSchedules_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If dgvAllSchedules.CurrentCellAddress.X = 0 AndAlso
                dgvAllSchedules.IsCurrentCellDirty Then
            dgvAllSchedules.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Dim result As DialogResult = MessageBox.Show("タスクを完了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        ' Noが選択されたら処理を中断
        If result = DialogResult.No Then
            Return
        End If
        Dim Con As MySqlConnection = SqlConnection()
        Dim ins_id As String = ""
        Dim SqlStr As String = ""
        Dim check As Boolean = False
        ' 1つ以上チェックが入っているかを調べる変数
        Dim anyChecked As Boolean = False
        Dim Dt As New DataTable
        Con.Open()
        For row As Integer = 0 To dgvAllSchedules.Rows.Count - 1
            check = dgvAllSchedules.Rows(row).Cells(0).Value
            ' チェックが入っている行の削除処理を実施
            If check Then
                anyChecked = True
                ins_id = dgvAllSchedules.Rows(row).Cells(7).Value
                SqlStr = "Delete from Schedule where insert_id = '" + ins_id + "'"
                Dim Adapter = New MySqlDataAdapter(SqlStr, Con)
                Adapter.Fill(Dt)
            End If
        Next
        ' チェックが1つも入っていなかった場合、エラー
        If Not anyChecked Then
            MessageBox.Show("1つ以上選択してください", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        dgvAllSchedules.DataSource = Dt
        Con.Close()
        ViewAllSchedules()
        MessageBox.Show("完了しました", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class