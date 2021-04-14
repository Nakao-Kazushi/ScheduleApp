Imports MySql.Data.MySqlClient
Public Class UppSchedule
    '画面ロード時
    Private Sub UppSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '「AddSchedule」画面のテーブル選択列から要素を取得し反映
        DateTimePicker1.Value = AddSchedule.startdateproperty
        DateTimePicker2.Value = AddSchedule.enddateproperty
        ComboBox1.Text = AddSchedule.starttimeproperty.Substring(0, 2)
        ComboBox2.Text = AddSchedule.starttimeproperty.Substring(3, 2)
        ComboBox3.Text = AddSchedule.endtimeproperty.Substring(0, 2)
        ComboBox4.Text = AddSchedule.endtimeproperty.Substring(3, 2)
        TextBox1.Text = AddSchedule.event_nameproperty
        Dim selected_starttime = ComboBox1.Text + ":" + ComboBox2.Text
        Dim selected_endtime = ComboBox3.Text + ":" + ComboBox4.Text
    End Sub
    '更新ボタン押下時
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '開始日付取得
        Dim selected_startdate = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        '終了日付取得
        Dim selected_enddate = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        '開始時間取得
        Dim selected_starttime = ComboBox1.Text + ":" + ComboBox2.Text
        '終了時間取得
        Dim selected_endtime = ComboBox3.Text + ":" + ComboBox4.Text
        'イベント内容取得
        Dim event_naiyou = TextBox1.Text
        'Insert_id取得
        Dim ins_id = AddSchedule.insert_idproperty

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

        Dim sqlStr = "update Schedule set regist_startdate = '" + selected_startdate + "',regist_enddate = '" + selected_enddate + "',regist_starttime = '" + selected_starttime + "',regist_endtime = '" + selected_endtime + "',event_name = '" + event_naiyou + "' where insert_id = '" + ins_id + "'"

        Dim Adapter = New MySqlDataAdapter(sqlStr, Con)

        Dim Ds As New DataSet

        Adapter.Fill(Ds)

        Con.Close()

        'フォームを閉じる
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ''「AddSchedule」画面のテーブル選択列のInsert_idプロパティ取得
        Dim ins_id = AddSchedule.insert_idproperty

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

        Dim sqlStr = "Delete from Schedule where insert_id = '" + ins_id + "'"

        Dim Adapter = New MySqlDataAdapter(sqlStr, Con)

        Dim Ds As New DataSet

        Adapter.Fill(Ds)

        Con.Close()

        'フォームを閉じる
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'フォームを閉じる
        Me.Close()

    End Sub
End Class