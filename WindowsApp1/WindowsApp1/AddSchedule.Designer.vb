<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddSchedule
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
        Me.ScheduleCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnAddButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDetailedSchedule = New System.Windows.Forms.TextBox()
        Me.cmbStartHour = New System.Windows.Forms.ComboBox()
        Me.cmbStartMinute = New System.Windows.Forms.ComboBox()
        Me.cmbEndHour = New System.Windows.Forms.ComboBox()
        Me.cmbEndMinute = New System.Windows.Forms.ComboBox()
        Me.btnViewAllSchedules = New System.Windows.Forms.Button()
        Me.dgvAllSchedules = New System.Windows.Forms.DataGridView()
        Me.btnComplete = New System.Windows.Forms.Button()
        Me.chkComplete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dgvAllSchedules, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScheduleCalendar
        '
        Me.ScheduleCalendar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ScheduleCalendar.ForeColor = System.Drawing.Color.Black
        Me.ScheduleCalendar.Location = New System.Drawing.Point(118, 32)
        Me.ScheduleCalendar.MaxSelectionCount = 31
        Me.ScheduleCalendar.Name = "ScheduleCalendar"
        Me.ScheduleCalendar.ShowToday = False
        Me.ScheduleCalendar.TabIndex = 0
        Me.ScheduleCalendar.TodayDate = New Date(2021, 4, 7, 0, 0, 0, 0)
        Me.ScheduleCalendar.TrailingForeColor = System.Drawing.SystemColors.InactiveCaption
        '
        'btnAddButton
        '
        Me.btnAddButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAddButton.Location = New System.Drawing.Point(709, 242)
        Me.btnAddButton.Name = "btnAddButton"
        Me.btnAddButton.Size = New System.Drawing.Size(75, 37)
        Me.btnAddButton.TabIndex = 1
        Me.btnAddButton.Text = "登録"
        Me.btnAddButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(617, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "～"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtpStartDate.Location = New System.Drawing.Point(477, 55)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(133, 22)
        Me.dtpStartDate.TabIndex = 8
        Me.dtpStartDate.Value = New Date(2021, 4, 19, 0, 0, 0, 0)
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtpEndDate.Location = New System.Drawing.Point(641, 55)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(143, 22)
        Me.dtpEndDate.TabIndex = 10
        Me.dtpEndDate.Value = New Date(2021, 4, 19, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(616, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "～"
        '
        'txtDetailedSchedule
        '
        Me.txtDetailedSchedule.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDetailedSchedule.Location = New System.Drawing.Point(477, 147)
        Me.txtDetailedSchedule.Multiline = True
        Me.txtDetailedSchedule.Name = "txtDetailedSchedule"
        Me.txtDetailedSchedule.Size = New System.Drawing.Size(307, 89)
        Me.txtDetailedSchedule.TabIndex = 12
        '
        'cmbStartHour
        '
        Me.cmbStartHour.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartHour.FormattingEnabled = True
        Me.cmbStartHour.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbStartHour.Location = New System.Drawing.Point(498, 101)
        Me.cmbStartHour.Name = "cmbStartHour"
        Me.cmbStartHour.Size = New System.Drawing.Size(47, 23)
        Me.cmbStartHour.TabIndex = 13
        '
        'cmbStartMinute
        '
        Me.cmbStartMinute.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbStartMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartMinute.FormattingEnabled = True
        Me.cmbStartMinute.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbStartMinute.Location = New System.Drawing.Point(551, 101)
        Me.cmbStartMinute.Name = "cmbStartMinute"
        Me.cmbStartMinute.Size = New System.Drawing.Size(47, 23)
        Me.cmbStartMinute.TabIndex = 14
        '
        'cmbEndHour
        '
        Me.cmbEndHour.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndHour.FormattingEnabled = True
        Me.cmbEndHour.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbEndHour.Location = New System.Drawing.Point(661, 101)
        Me.cmbEndHour.Name = "cmbEndHour"
        Me.cmbEndHour.Size = New System.Drawing.Size(47, 23)
        Me.cmbEndHour.TabIndex = 15
        '
        'cmbEndMinute
        '
        Me.cmbEndMinute.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndMinute.FormattingEnabled = True
        Me.cmbEndMinute.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbEndMinute.Location = New System.Drawing.Point(715, 101)
        Me.cmbEndMinute.Name = "cmbEndMinute"
        Me.cmbEndMinute.Size = New System.Drawing.Size(47, 23)
        Me.cmbEndMinute.TabIndex = 16
        '
        'btnViewAllSchedules
        '
        Me.btnViewAllSchedules.Location = New System.Drawing.Point(122, 314)
        Me.btnViewAllSchedules.Name = "btnViewAllSchedules"
        Me.btnViewAllSchedules.Size = New System.Drawing.Size(94, 40)
        Me.btnViewAllSchedules.TabIndex = 17
        Me.btnViewAllSchedules.Text = "一括表示"
        Me.btnViewAllSchedules.UseVisualStyleBackColor = True
        '
        'dgvAllSchedules
        '
        Me.dgvAllSchedules.AllowUserToAddRows = False
        Me.dgvAllSchedules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAllSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllSchedules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkComplete, Me.btn})
        Me.dgvAllSchedules.Location = New System.Drawing.Point(16, 372)
        Me.dgvAllSchedules.Name = "dgvAllSchedules"
        Me.dgvAllSchedules.RowHeadersVisible = False
        Me.dgvAllSchedules.RowHeadersWidth = 51
        Me.dgvAllSchedules.RowTemplate.Height = 24
        Me.dgvAllSchedules.Size = New System.Drawing.Size(935, 365)
        Me.dgvAllSchedules.TabIndex = 18
        '
        'btnComplete
        '
        Me.btnComplete.Location = New System.Drawing.Point(17, 314)
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(75, 40)
        Me.btnComplete.TabIndex = 19
        Me.btnComplete.Text = "完了"
        Me.btnComplete.UseVisualStyleBackColor = True
        '
        'chkComplete
        '
        Me.chkComplete.FalseValue = "false"
        Me.chkComplete.HeaderText = ""
        Me.chkComplete.MinimumWidth = 6
        Me.chkComplete.Name = "chkComplete"
        Me.chkComplete.TrueValue = "true"
        Me.chkComplete.Width = 50
        '
        'btn
        '
        Me.btn.HeaderText = "詳細"
        Me.btn.MinimumWidth = 6
        Me.btn.Name = "btn"
        Me.btn.Text = "詳細"
        Me.btn.UseColumnTextForButtonValue = True
        Me.btn.Width = 50
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(424, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "日付"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(424, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "時間"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(424, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "詳細"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(76, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(830, 281)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'AddSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 749)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnComplete)
        Me.Controls.Add(Me.dgvAllSchedules)
        Me.Controls.Add(Me.btnViewAllSchedules)
        Me.Controls.Add(Me.cmbEndMinute)
        Me.Controls.Add(Me.cmbEndHour)
        Me.Controls.Add(Me.cmbStartMinute)
        Me.Controls.Add(Me.cmbStartHour)
        Me.Controls.Add(Me.txtDetailedSchedule)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAddButton)
        Me.Controls.Add(Me.ScheduleCalendar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "AddSchedule"
        Me.Text = "myスケジュール"
        CType(Me.dgvAllSchedules, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ScheduleCalendar As MonthCalendar
    Friend WithEvents btnAddButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDetailedSchedule As TextBox
    Friend WithEvents cmbStartHour As ComboBox
    Friend WithEvents cmbStartMinute As ComboBox
    Friend WithEvents cmbEndHour As ComboBox
    Friend WithEvents cmbEndMinute As ComboBox
    Friend WithEvents btnViewAllSchedules As Button
    Friend WithEvents dgvAllSchedules As DataGridView
    Friend WithEvents btnComplete As Button
    Friend WithEvents chkComplete As DataGridViewCheckBoxColumn
    Friend WithEvents btn As DataGridViewButtonColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
