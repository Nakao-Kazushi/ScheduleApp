Imports MySql.Data.MySqlClient
Public Class UppSchedule

    Private ins_id As String
    Public Sub Loading(AddSchedule As AddSchedule)
        '「AddSchedule」画面のテーブル選択列から要素を取得し反映
        dtpStartDate.Value = AddSchedule.startdateproperty
        dtpEndDate.Value = AddSchedule.enddateproperty
        cmbStartHour.Text = AddSchedule.starttimeproperty.Substring(0, 2)
        cmbStartMinute.Text = AddSchedule.starttimeproperty.Substring(3, 2)
        cmbEndHour.Text = AddSchedule.endtimeproperty.Substring(0, 2)
        cmbEndMinute.Text = AddSchedule.endtimeproperty.Substring(3, 2)
        txtDetailedSchedule.Text = AddSchedule.event_nameproperty
        Dim selected_starttime = cmbStartHour.Text + ":" + cmbStartMinute.Text
        Dim selected_endtime = cmbEndHour.Text + ":" + cmbEndMinute.Text
        'Insert_id取得
        ins_id = AddSchedule.insert_idproperty
    End Sub

    '画面ロード時
    Private Sub UppSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '更新ボタン押下時
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim result As DialogResult = MessageBox.Show("更新しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        ' キャンセルボタンが押下されたら処理を中断
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
        'イベント内容取得
        Dim event_naiyou = txtDetailedSchedule.Text
        ' 日付エラーが発生した場合処理を中断する
        If Not CommonClass.ScheduleDateCheck(selected_startdate, selected_enddate, selected_starttime, selected_endtime) Then
            Return
        End If
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
        MessageBox.Show("更新完了", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'フォームを閉じる
        Me.Close()

    End Sub

    '削除ボタン押下時
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim result As DialogResult = MessageBox.Show("削除しますか？", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        'メッセージボックスで「はい」を選択
        If result = DialogResult.Yes Then

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
            MessageBox.Show("削除完了", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'フォームを閉じる
            Me.Close()

        End If
    End Sub
    'キャンセルボタン押下時
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'フォームを閉じる
        Me.Close()

    End Sub
End Class