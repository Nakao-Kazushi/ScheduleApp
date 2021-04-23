<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MailSubmit
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
        Me.MailSubButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextMailaddress = New WindowsApp1.TextBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MailSubButton
        '
        Me.MailSubButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MailSubButton.Location = New System.Drawing.Point(393, 214)
        Me.MailSubButton.Name = "MailSubButton"
        Me.MailSubButton.Size = New System.Drawing.Size(98, 55)
        Me.MailSubButton.TabIndex = 1
        Me.MailSubButton.Text = "認証コードをメール送信"
        Me.MailSubButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "メールアドレス"
        '
        'TextMailaddress
        '
        Me.TextMailaddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextMailaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMailaddress.CustomBorderColor = System.Drawing.Color.Gray
        Me.TextMailaddress.Location = New System.Drawing.Point(138, 119)
        Me.TextMailaddress.Name = "TextMailaddress"
        Me.TextMailaddress.Size = New System.Drawing.Size(255, 22)
        Me.TextMailaddress.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 15)
        Me.Label2.TabIndex = 9
        '
        'ReturnButton
        '
        Me.ReturnButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReturnButton.Location = New System.Drawing.Point(510, 214)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(98, 55)
        Me.ReturnButton.TabIndex = 10
        Me.ReturnButton.Text = "戻る"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'MailSubmit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 323)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextMailaddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MailSubButton)
        Me.Name = "MailSubmit"
        Me.Text = "メール送信画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MailSubButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextMailaddress As TextBoxEx
    Friend WithEvents Label2 As Label
    Friend WithEvents ReturnButton As Button
End Class
