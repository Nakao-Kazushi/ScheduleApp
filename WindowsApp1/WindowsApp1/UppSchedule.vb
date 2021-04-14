Imports MySql.Data.MySqlClient
Public Class UppSchedule
    Private Sub UppSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.Value = AddSchedule.startdateproperty
        DateTimePicker2.Value = AddSchedule.enddateproperty
        ComboBox1.Text = AddSchedule.starttimeproperty.Substring(0, 2)
        ComboBox2.Text = AddSchedule.starttimeproperty.Substring(3, 2)
        ComboBox3.Text = AddSchedule.endtimeproperty.Substring(0, 2)
        ComboBox4.Text = AddSchedule.endtimeproperty.Substring(3, 2)
        TextBox1.Text = AddSchedule.event_nameproperty
        Dim selected_starttime = ComboBox1.Text + ":" + ComboBox2.Text
        Dim selected_endtime = ComboBox3.Text + ":" + ComboBox4.Text

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



        Con.Close()

    End Sub
End Class