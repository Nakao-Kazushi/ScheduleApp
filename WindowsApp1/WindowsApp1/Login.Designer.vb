<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chkSaveLogin = New System.Windows.Forms.CheckBox()
        Me.lnkAddUser = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkPWSetting = New System.Windows.Forms.LinkLabel()
        Me.txtPassword = New WindowsApp1.TextBoxEx()
        Me.txtUserId = New WindowsApp1.TextBoxEx()
        Me.SuspendLayout()
        '
        'chkSaveLogin
        '
        Me.chkSaveLogin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chkSaveLogin.AutoSize = True
        Me.chkSaveLogin.Location = New System.Drawing.Point(309, 239)
        Me.chkSaveLogin.Name = "chkSaveLogin"
        Me.chkSaveLogin.Size = New System.Drawing.Size(169, 19)
        Me.chkSaveLogin.TabIndex = 4
        Me.chkSaveLogin.Text = "ログイン情報を保存する"
        Me.chkSaveLogin.UseVisualStyleBackColor = True
        '
        'lnkAddUser
        '
        Me.lnkAddUser.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lnkAddUser.AutoSize = True
        Me.lnkAddUser.Location = New System.Drawing.Point(326, 322)
        Me.lnkAddUser.Name = "lnkAddUser"
        Me.lnkAddUser.Size = New System.Drawing.Size(38, 15)
        Me.lnkAddUser.TabIndex = 7
        Me.lnkAddUser.TabStop = True
        Me.lnkAddUser.Text = "こちら"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(189, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "初回ログインのかたは"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Location = New System.Drawing.Point(131, 264)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(268, 37)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "ログイン"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "メールアドレス"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 356)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "パスワードをお忘れの方は"
        '
        'lnkPWSetting
        '
        Me.lnkPWSetting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lnkPWSetting.AutoSize = True
        Me.lnkPWSetting.Location = New System.Drawing.Point(326, 356)
        Me.lnkPWSetting.Name = "lnkPWSetting"
        Me.lnkPWSetting.Size = New System.Drawing.Size(38, 15)
        Me.lnkPWSetting.TabIndex = 9
        Me.lnkPWSetting.TabStop = True
        Me.lnkPWSetting.Text = "こちら"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.CustomBorderColor = System.Drawing.Color.Gray
        Me.txtPassword.Location = New System.Drawing.Point(131, 202)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(268, 22)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserId
        '
        Me.txtUserId.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserId.CustomBorderColor = System.Drawing.Color.Gray
        Me.txtUserId.Location = New System.Drawing.Point(131, 131)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(268, 22)
        Me.txtUserId.TabIndex = 1
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 453)
        Me.Controls.Add(Me.lnkPWSetting)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.chkSaveLogin)
        Me.Controls.Add(Me.lnkAddUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Login"
        Me.Text = "ログイン画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkSaveLogin As CheckBox
    Friend WithEvents lnkAddUser As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUserId As TextBoxEx
    Friend WithEvents txtPassword As TextBoxEx
    Friend WithEvents Label4 As Label
    Friend WithEvents lnkPWSetting As LinkLabel
End Class
