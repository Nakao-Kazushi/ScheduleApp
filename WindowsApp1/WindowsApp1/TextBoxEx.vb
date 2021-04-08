Imports System.ComponentModel
Public Class TextBoxEx
    Inherits TextBox

    Private Const WM_PAINT = &HF

    Private _CustomBorderColor As Color = Color.Gray

    ''' <summary>
    ''' TextBoxの枠線の色を指定します。
    ''' </summary>
    <Description("TextBoxの枠線の色を指定します。")>
    Public Property CustomBorderColor() As Color
        Get
            Return _CustomBorderColor
        End Get
        Set(ByVal value As Color)
            If _CustomBorderColor <> value Then
                _CustomBorderColor = value
                Me.Refresh()
            End If
        End Set
    End Property

    ''' <summary>
    ''' WndProcメソッドオーバーライド
    ''' </summary>
    ''' <param name="m"></param>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)

        If (m.Msg = WM_PAINT) Then

            Using g As Graphics = CreateGraphics()

                If _CustomBorderColor <> Color.Gray Then
                    '標準カラーでない場合は指定色で描画する
                    Dim p As New System.Drawing.Pen(_CustomBorderColor)
                    g.DrawRectangle(p, 0, 0, Me.Width - 1, Me.Height - 1)
                Else
                    ControlPaint.DrawVisualStyleBorder(g, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                End If

            End Using
        End If
    End Sub

End Class