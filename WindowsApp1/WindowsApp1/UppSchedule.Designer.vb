<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UppSchedule
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
        Me.txtDetailedSchedule = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cmbEndMinute = New System.Windows.Forms.ComboBox()
        Me.cmbEndHour = New System.Windows.Forms.ComboBox()
        Me.cmbStartMinute = New System.Windows.Forms.ComboBox()
        Me.cmbStartHour = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtDetailedSchedule
        '
        Me.txtDetailedSchedule.Location = New System.Drawing.Point(206, 166)
        Me.txtDetailedSchedule.MaxLength = 500
        Me.txtDetailedSchedule.Multiline = True
        Me.txtDetailedSchedule.Name = "txtDetailedSchedule"
        Me.txtDetailedSchedule.Size = New System.Drawing.Size(365, 159)
        Me.txtDetailedSchedule.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(374, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "～"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(399, 85)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(143, 22)
        Me.dtpEndDate.TabIndex = 19
        Me.dtpEndDate.Value = New Date(2021, 4, 19, 0, 0, 0, 0)
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(235, 85)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(133, 22)
        Me.dtpStartDate.TabIndex = 18
        Me.dtpStartDate.Value = New Date(2021, 4, 19, 0, 0, 0, 0)
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(236, 339)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(90, 38)
        Me.btnUpdate.TabIndex = 22
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(453, 339)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 38)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cmbEndMinute
        '
        Me.cmbEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndMinute.FormattingEnabled = True
        Me.cmbEndMinute.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbEndMinute.Location = New System.Drawing.Point(472, 127)
        Me.cmbEndMinute.Name = "cmbEndMinute"
        Me.cmbEndMinute.Size = New System.Drawing.Size(47, 23)
        Me.cmbEndMinute.TabIndex = 28
        '
        'cmbEndHour
        '
        Me.cmbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndHour.FormattingEnabled = True
        Me.cmbEndHour.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbEndHour.Location = New System.Drawing.Point(418, 127)
        Me.cmbEndHour.Name = "cmbEndHour"
        Me.cmbEndHour.Size = New System.Drawing.Size(47, 23)
        Me.cmbEndHour.TabIndex = 27
        '
        'cmbStartMinute
        '
        Me.cmbStartMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartMinute.FormattingEnabled = True
        Me.cmbStartMinute.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbStartMinute.Location = New System.Drawing.Point(308, 127)
        Me.cmbStartMinute.Name = "cmbStartMinute"
        Me.cmbStartMinute.Size = New System.Drawing.Size(47, 23)
        Me.cmbStartMinute.TabIndex = 26
        '
        'cmbStartHour
        '
        Me.cmbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartHour.FormattingEnabled = True
        Me.cmbStartHour.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbStartHour.Location = New System.Drawing.Point(255, 127)
        Me.cmbStartHour.Name = "cmbStartHour"
        Me.cmbStartHour.Size = New System.Drawing.Size(47, 23)
        Me.cmbStartHour.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(374, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 15)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "～"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(346, 339)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 38)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'UppSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.cmbEndMinute)
        Me.Controls.Add(Me.cmbEndHour)
        Me.Controls.Add(Me.cmbStartMinute)
        Me.Controls.Add(Me.cmbStartHour)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtDetailedSchedule)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(818, 497)
        Me.MinimumSize = New System.Drawing.Size(818, 497)
        Me.Name = "UppSchedule"
        Me.Text = "詳細"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDetailedSchedule As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cmbEndMinute As ComboBox
    Friend WithEvents cmbEndHour As ComboBox
    Friend WithEvents cmbStartMinute As ComboBox
    Friend WithEvents cmbStartHour As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelete As Button
End Class
