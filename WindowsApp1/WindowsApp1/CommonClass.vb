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
    ''' <param name="errorText">errorMsgに格納したい値</param>
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

End Class
