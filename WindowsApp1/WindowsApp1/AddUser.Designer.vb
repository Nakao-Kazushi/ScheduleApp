﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddUser
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
        Me.user_Id = New System.Windows.Forms.TextBox()
        Me.pw = New System.Windows.Forms.TextBox()
        Me.userId = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.Label()
        Me.AddUserButton = New System.Windows.Forms.Button()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'user_Id
        '
        Me.user_Id.Location = New System.Drawing.Point(298, 116)
        Me.user_Id.Name = "user_Id"
        Me.user_Id.Size = New System.Drawing.Size(153, 22)
        Me.user_Id.TabIndex = 0
        '
        'pw
        '
        Me.pw.Location = New System.Drawing.Point(298, 177)
        Me.pw.Name = "pw"
        Me.pw.Size = New System.Drawing.Size(153, 22)
        Me.pw.TabIndex = 1
        '
        'userId
        '
        Me.userId.AutoSize = True
        Me.userId.Location = New System.Drawing.Point(178, 119)
        Me.userId.Name = "userId"
        Me.userId.Size = New System.Drawing.Size(69, 15)
        Me.userId.TabIndex = 2
        Me.userId.Text = "ユーザーID"
        '
        'password
        '
        Me.password.AutoSize = True
        Me.password.Location = New System.Drawing.Point(178, 180)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(64, 15)
        Me.password.TabIndex = 3
        Me.password.Text = "パスワード"
        '
        'AddUserButton
        '
        Me.AddUserButton.Location = New System.Drawing.Point(521, 341)
        Me.AddUserButton.Name = "AddUserButton"
        Me.AddUserButton.Size = New System.Drawing.Size(83, 41)
        Me.AddUserButton.TabIndex = 4
        Me.AddUserButton.Text = "登録"
        Me.AddUserButton.UseVisualStyleBackColor = True
        '
        'ReturnButton
        '
        Me.ReturnButton.Location = New System.Drawing.Point(655, 341)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(79, 41)
        Me.ReturnButton.TabIndex = 5
        Me.ReturnButton.Text = "戻る"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 453)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.AddUserButton)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.userId)
        Me.Controls.Add(Me.pw)
        Me.Controls.Add(Me.user_Id)
        Me.Name = "AddUser"
        Me.Text = "ユーザー登録画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents user_Id As TextBox
    Friend WithEvents pw As TextBox
    Friend WithEvents userId As Label
    Friend WithEvents password As Label
    Friend WithEvents AddUserButton As Button
    Friend WithEvents ReturnButton As Button
End Class
