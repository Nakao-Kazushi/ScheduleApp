Public Class CommonClass
    ' DB接続情報のコンストラクタ
    Private Const LOGIN As String = "server=localhost; database=BKSScheduledb; userid=BKSSCHEDULE; password=bksscd;"

    ''' <summary>
    ''' 接続文字列を返すメソッド
    ''' </summary>
    ''' <returns>String</returns>
    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return LOGIN
        End Get
    End Property

    ''' <summary>
    ''' テキストがメールアドレスかを確認する 
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns>メールアドレスならtrue,そうでないならfalse</returns>
    Public Shared Function CheckMailAddress(text As String) As Boolean
        'メールアドレスか調べる
        Return System.Text.RegularExpressions.Regex.IsMatch(
            text,
            "\A[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\z",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function

    ''' <summary>
    ''' 1.未入力の項目を返す
    ''' <para>2.未入力テキストボックスの枠線の色を赤くする</para>
    ''' </summary>
    ''' <param name="errorText">errorMsgに格納したい文字列</param>
    ''' <param name="errorMsg">errorTextを文字列結合する</param>
    ''' <param name="textBoxEx">枠線色変更するTextBox</param>
    ''' <returns>String</returns>
    Public Shared Function NotInputError(errorText As String, errorMsg As String, textBoxEx As TextBoxEx) As String
        If String.IsNullOrEmpty(textBoxEx.Text) Then
            errorMsg += errorText + Environment.NewLine
            ' テキストボックスの枠線を赤くする
            textBoxEx.CustomBorderColor = Color.Red
        Else
            textBoxEx.CustomBorderColor = Color.Gray
        End If
        Return errorMsg
    End Function

    ''' <summary>
    ''' 1.開始日が今日より前の日付か
    ''' <para>2.終了日が開始日より前の日付か</para>
    ''' <para>3.終了時間が開始時間より前の時間か</para>
    ''' <para>をチェックする</para>
    ''' </summary>
    ''' <param name="selected_startdate">開始日</param>
    ''' <param name="selected_enddate">終了日</param>
    ''' <param name="selected_starttime">開始時間</param>
    ''' <param name="selected_endtime">終了時間</param>
    ''' <returns>いずれかに該当する場合はfalse</returns>
    Public Shared Function ScheduleDateCheck(selected_startdate As String, selected_enddate As String,
                                             selected_starttime As String, selected_endtime As String) As Boolean
        ' 現在時刻取得
        Dim dtn As DateTime = DateTime.Now
        Dim nowDate As String = dtn.ToString("yyyy/MM/dd")
        ' 戻り値を宣言
        Dim result As Boolean = True
        If nowDate.CompareTo(selected_startdate) = 1 Then
            MessageBox.Show("開始日は今日以降の日付を入力して下さい", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            result = False
        ElseIf selected_startdate > selected_enddate Then
            MessageBox.Show("終了日は開始日以降の日付を入力して下さい", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            result = False
        ElseIf selected_startdate = selected_enddate And
               selected_starttime > selected_endtime Then
            MessageBox.Show("終了時間は開始時間以降の時間を入力して下さい", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            result = False
        End If
        Return result
    End Function
End Class
