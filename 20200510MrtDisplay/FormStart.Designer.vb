<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button200 = New System.Windows.Forms.Button()
        Me.Button100 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label600 = New System.Windows.Forms.Label()
        Me.Label500 = New System.Windows.Forms.Label()
        Me.Label1000 = New System.Windows.Forms.Label()
        Me.Label2000 = New System.Windows.Forms.Label()
        Me.TextBox1000 = New System.Windows.Forms.TextBox()
        Me.Label3000 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Button1000 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox2000 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Button200
        '
        Me.Button200.Location = New System.Drawing.Point(746, 65)
        Me.Button200.Name = "Button200"
        Me.Button200.Size = New System.Drawing.Size(121, 38)
        Me.Button200.TabIndex = 18
        Me.Button200.Text = "測試模式"
        Me.Button200.UseVisualStyleBackColor = True
        '
        'Button100
        '
        Me.Button100.Location = New System.Drawing.Point(746, 116)
        Me.Button100.Name = "Button100"
        Me.Button100.Size = New System.Drawing.Size(121, 38)
        Me.Button100.TabIndex = 19
        Me.Button100.Text = "出發！"
        Me.Button100.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label600
        '
        Me.Label600.AutoSize = True
        Me.Label600.ForeColor = System.Drawing.Color.Red
        Me.Label600.Location = New System.Drawing.Point(95, 800)
        Me.Label600.Name = "Label600"
        Me.Label600.Size = New System.Drawing.Size(54, 27)
        Me.Label600.TabIndex = 21
        Me.Label600.Text = "移除"
        Me.Label600.Visible = False
        '
        'Label500
        '
        Me.Label500.AutoSize = True
        Me.Label500.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label500.Location = New System.Drawing.Point(35, 800)
        Me.Label500.Name = "Label500"
        Me.Label500.Size = New System.Drawing.Size(54, 27)
        Me.Label500.TabIndex = 20
        Me.Label500.Text = "新增"
        '
        'Label1000
        '
        Me.Label1000.AutoSize = True
        Me.Label1000.Location = New System.Drawing.Point(741, 187)
        Me.Label1000.Name = "Label1000"
        Me.Label1000.Size = New System.Drawing.Size(138, 27)
        Me.Label1000.TabIndex = 22
        Me.Label1000.Text = "終點站中文："
        '
        'Label2000
        '
        Me.Label2000.AutoSize = True
        Me.Label2000.Location = New System.Drawing.Point(741, 271)
        Me.Label2000.Name = "Label2000"
        Me.Label2000.Size = New System.Drawing.Size(138, 27)
        Me.Label2000.TabIndex = 23
        Me.Label2000.Text = "終點站英文："
        '
        'TextBox1000
        '
        Me.TextBox1000.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1000.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1000.ForeColor = System.Drawing.Color.Red
        Me.TextBox1000.Location = New System.Drawing.Point(745, 221)
        Me.TextBox1000.Name = "TextBox1000"
        Me.TextBox1000.Size = New System.Drawing.Size(146, 28)
        Me.TextBox1000.TabIndex = 24
        Me.TextBox1000.Text = " 🅁   淡   水"
        '
        'Label3000
        '
        Me.Label3000.AutoSize = True
        Me.Label3000.Location = New System.Drawing.Point(741, 362)
        Me.Label3000.Name = "Label3000"
        Me.Label3000.Size = New System.Drawing.Size(117, 27)
        Me.Label3000.TabIndex = 26
        Me.Label3000.Text = "路線顏色："
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        '
        'Button1000
        '
        Me.Button1000.Location = New System.Drawing.Point(746, 392)
        Me.Button1000.Name = "Button1000"
        Me.Button1000.Size = New System.Drawing.Size(100, 37)
        Me.Button1000.TabIndex = 27
        Me.Button1000.Text = "選擇"
        Me.Button1000.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Location = New System.Drawing.Point(740, 216)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 38)
        Me.Panel1.TabIndex = 28
        '
        'TextBox2000
        '
        Me.TextBox2000.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2000.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2000.ForeColor = System.Drawing.Color.Red
        Me.TextBox2000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox2000.Location = New System.Drawing.Point(745, 303)
        Me.TextBox2000.Name = "TextBox2000"
        Me.TextBox2000.Size = New System.Drawing.Size(146, 28)
        Me.TextBox2000.TabIndex = 29
        Me.TextBox2000.Text = " 🅁   Tamsui"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Red
        Me.Panel2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Panel2.Location = New System.Drawing.Point(740, 298)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(157, 38)
        Me.Panel2.TabIndex = 30
        '
        'FormStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 686)
        Me.Controls.Add(Me.TextBox2000)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TextBox1000)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1000)
        Me.Controls.Add(Me.Label3000)
        Me.Controls.Add(Me.Label2000)
        Me.Controls.Add(Me.Label1000)
        Me.Controls.Add(Me.Label600)
        Me.Controls.Add(Me.Label500)
        Me.Controls.Add(Me.Button100)
        Me.Controls.Add(Me.Button200)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "FormStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "台北捷運廣播模擬"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button200 As Button
    Friend WithEvents Button100 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label600 As Label
    Friend WithEvents Label500 As Label
    Friend WithEvents Label1000 As Label
    Friend WithEvents Label2000 As Label
    Friend WithEvents TextBox1000 As TextBox
    Friend WithEvents Label3000 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Button1000 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox2000 As TextBox
    Friend WithEvents Panel2 As Panel
End Class
