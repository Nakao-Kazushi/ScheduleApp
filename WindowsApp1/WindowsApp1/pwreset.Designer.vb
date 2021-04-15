<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PwResetButton = New System.Windows.Forms.Button()
        Me.PwUpdateButton = New System.Windows.Forms.Button()
        Me.TextPw = New WindowsApp1.TextBoxEx()
        Me.TextUserId = New WindowsApp1.TextBoxEx()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ユーザーID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'PwResetButton
        '
        Me.PwResetButton.Location = New System.Drawing.Point(563, 160)
        Me.PwResetButton.Name = "PwResetButton"
        Me.PwResetButton.Size = New System.Drawing.Size(94, 42)
        Me.PwResetButton.TabIndex = 4
        Me.PwResetButton.Text = "メール送信"
        Me.PwResetButton.UseVisualStyleBackColor = True
        '
        'PwUpdateButton
        '
        Me.PwUpdateButton.Location = New System.Drawing.Point(563, 242)
        Me.PwUpdateButton.Name = "PwUpdateButton"
        Me.PwUpdateButton.Size = New System.Drawing.Size(94, 42)
        Me.PwUpdateButton.TabIndex = 6
        Me.PwUpdateButton.Text = "Pw再登録"
        Me.PwUpdateButton.UseVisualStyleBackColor = True
        '
        'TextPw
        '
        Me.TextPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPw.CustomBorderColor = System.Drawing.Color.Gray
        Me.TextPw.Location = New System.Drawing.Point(216, 217)
        Me.TextPw.Name = "TextPw"
        Me.TextPw.Size = New System.Drawing.Size(271, 22)
        Me.TextPw.TabIndex = 8
        '
        'TextUserId
        '
        Me.TextUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUserId.CustomBorderColor = System.Drawing.Color.Gray
        Me.TextUserId.Location = New System.Drawing.Point(216, 111)
        Me.TextUserId.Name = "TextUserId"
        Me.TextUserId.Size = New System.Drawing.Size(271, 22)
        Me.TextUserId.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextPw)
        Me.Controls.Add(Me.TextUserId)
        Me.Controls.Add(Me.PwUpdateButton)
        Me.Controls.Add(Me.PwResetButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "パスワード再設定画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PwResetButton As Button
    Friend WithEvents PwUpdateButton As Button
    Friend WithEvents TextUserId As TextBoxEx
    Friend WithEvents TextPw As TextBoxEx
End Class
