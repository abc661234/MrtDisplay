Imports System.IO
Public Class FormStart
    Public BusStop As Integer = 0
    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadFile()
        Me.AutoScroll = False
        Me.AutoScroll = True
    End Sub

    Sub AddStop()
        Me.AutoScroll = False
        BusStop += 1
        If BusStop <> 2 Then
            Try
                Me.Controls("Label" + ((BusStop - 2) * 6 + 5).ToString()).Text = "音檔："
            Catch
            End Try
        End If
        For i = (BusStop - 1) * 6 To (BusStop - 1) * 6 + 5
            Dim lb As Label = New Label
            lb.Name = "Label" + (i + 1).ToString()
            If i Mod 6 = 0 Then
                lb.Text = "中文站名："
            ElseIf i Mod 6 = 1 Then
                lb.Text = "英文站名："
            ElseIf i Mod 6 = 2 Then
                lb.Text = "中文轉乘訊息："
            ElseIf i Mod 6 = 3 Then
                lb.Text = "英文轉乘訊息："
            ElseIf i Mod 6 = 4 Then
                If BusStop = 1 Then
                    lb.Text = "音檔：                   (起始站不播報)"
                Else
                    lb.Text = "音檔：                   (最終站不播報)"
                End If
            End If
            If i Mod 6 <> 5 Then
                lb.Location = New Point(35, (i + 1) * 50 - (BusStop - 1) * 50)
            Else
                lb.Location = New Point(320, i * 50 - (BusStop - 1) * 50 - 4 + 5)
                lb.Size = New Size(500, 100)
                lb.Font = New Font(Font.FontFamily, 12, FontStyle.Regular)
            End If
            Me.Controls.Add(lb)
            lb.BringToFront()
            lb.AutoSize = True
        Next
        For i = (BusStop - 1) * 4 To (BusStop - 1) * 4 + 3
            Dim tb As TextBox = New TextBox
            tb.Name = "TextBox" + (i + 1).ToString()
            'tb.Text = tb.Name
            tb.Location = New Point(200, 46 + i * 50 + (BusStop - 1) * 50)
            If i - (BusStop - 1) * 4 < 2 Then
                tb.Size = New Size(380, 35)
            Else
                tb.Size = New Size(490, 35)
            End If
            If i Mod 2 = 1 Then
                tb.ImeMode = ImeMode.Off
            End If
            Me.Controls.Add(tb)
            tb.BringToFront()
        Next
        Dim bt As Button = New Button
        bt.Name = "Button" + BusStop.ToString()
        bt.Location = New Point(200, 46 + (BusStop + 3) * 50 + (BusStop - 1) * 200)
        bt.Text = "選擇檔案"
        bt.Size = New Size(107, 35)
        Me.Controls.Add(bt)
        bt.BringToFront()
        bt.Visible = False
        AddHandler bt.Click, AddressOf ChooseFile
        Dim door As Button = New Button
        door.Name = "Door" + BusStop.ToString
        door.Location = New Point(589, 46 + (BusStop - 1) * 250)
        door.Text = "左側開門"
        door.Size = New Size(104, 35)
        Me.Controls.Add(door)
        door.BringToFront()
        AddHandler door.Click, AddressOf DoorOpen
        If BusStop > 2 Then
            Me.Controls("Button" + (BusStop - 1).ToString()).Visible = True
        End If
        Me.AutoScroll = True
        Me.AutoScrollPosition = New Point(0, 10000)
    End Sub

    Public Sub ChooseFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim type As String = OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.Length - 3, 3)
            If type = "WAV" Or type = "wav" Then
                Dim LabelName As String
                Try
                    LabelName = "label" + (sender.name.ToString().Substring(6, 2) * 6).ToString()
                Catch
                    LabelName = "label" + (sender.name.ToString().Substring(6, 1) * 6).ToString()
                End Try
                Me.Controls(LabelName).Text = OpenFileDialog1.FileName
            Else
                MessageBox.Show("僅支援 WAV 檔", "不支援的檔案格式", 0, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Label500_Click(sender As Object, e As EventArgs) Handles Label500.Click
        Label500.Top += 250
        Label600.Top += 250
        AddStop()
        If BusStop > 1 Then
            Label600.Visible = True
        Else
            Label600.Visible = False
        End If
    End Sub

    Private Sub Label600_Click(sender As Object, e As EventArgs) Handles Label600.Click
        Label500.Top -= 250
        Label600.Top -= 250
        Me.AutoScroll = False
        Dim rm As Control
        Me.AutoScroll = False
        For i = (BusStop - 1) * 6 To (BusStop - 1) * 6 + 5
            rm = Me.Controls("Label" + (i + 1).ToString())
            Me.Controls.Remove(rm)
        Next
        rm = Me.Controls("Label" + (BusStop * 6).ToString())
        Me.Controls.Remove(rm)
        Try
            rm = Me.Controls("Label" + ((BusStop - 1) * 6).ToString())
            rm.Text = ""
        Catch
        End Try
        For i = (BusStop - 1) * 4 To (BusStop - 1) * 4 + 3
            rm = Me.Controls("TextBox" + (i + 1).ToString())
            Me.Controls.Remove(rm)
        Next
        rm = Me.Controls("Button" + BusStop.ToString())
        Me.Controls.Remove(rm)
        rm = Me.Controls("Door" + BusStop.ToString())
        Me.Controls.Remove(rm)
        Try
            Me.Controls("Button" + (BusStop - 1).ToString).Visible = False
            Me.Controls("Label" + ((BusStop - 2) * 6 + 5).ToString).Text = "音檔：                   (最終站不播報)"
        Catch
        End Try
        BusStop -= 1
        Me.AutoScroll = True
        Me.AutoScrollPosition = New Point(0, 10000)
        If BusStop > 3 Then
            Label600.Visible = True
        Else
            Label600.Visible = False
        End If
    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        Dim sw As StreamWriter = New StreamWriter("Resource\info.txt")
        sw.WriteLine(BusStop)
        Dim ColorConv As New ColorConverter
        sw.WriteLine(ColorConv.ConvertToString(TextBox1000.ForeColor))
        sw.WriteLine(TextBox1000.Text)
        sw.WriteLine(TextBox2000.Text)
        Dim str As String
        For i = 1 To (BusStop - 1) * 4 + 4
            str = "TextBox" + i.ToString()
            sw.WriteLine(Me.Controls(str).Text)
        Next
        For i = 1 To BusStop
            str = "Door" + i.ToString()
            sw.WriteLine(Me.Controls(str).Text)
        Next
        For i = 1 To BusStop - 2
            Try
                str = "label" + (6 + i * 6).ToString
                sw.WriteLine(Me.Controls(str).Text)
            Catch
            End Try
        Next
        sw.Close()
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub FormStart_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1000_Click(sender As Object, e As EventArgs) Handles Button1000.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1000.ForeColor = ColorDialog1.Color
            TextBox2000.ForeColor = ColorDialog1.Color
            Panel1.BackColor = ColorDialog1.Color
            Panel2.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub DoorOpen(sender As Object, e As EventArgs)
        If sender.text = "左側開門" Then
            sender.text = "右側開門"
        Else
            sender.text = "左側開門"
        End If
    End Sub

    Private Sub ReadFile()
        Dim count As Integer
        Dim sr As StreamReader
        If File.Exists("Resource\info.txt") Then
            Try
                sr = New StreamReader("Resource\info.txt")
                count = sr.ReadLine()
            Catch
            End Try
        End If
        If count < 3 Then
            count = 3
        End If
        For i = 0 To count - 1
            If i >= 3 Then
                Label500.Top += 250
                Label600.Top += 250
                Label600.Visible = True
            End If
            AddStop()
        Next
        Try
            Dim ColorConv As New ColorConverter
            Dim color1 As Color = ColorConv.ConvertFromString(sr.ReadLine())
            TextBox1000.ForeColor = color1
            TextBox2000.ForeColor = color1
            Panel1.BackColor = color1
            Panel2.BackColor = color1
        Catch
        End Try
        Try
            TextBox1000.Text = sr.ReadLine
            TextBox2000.Text = sr.ReadLine
        Catch
        End Try
        For i = 0 To count - 1
            Try
                Me.Controls("TextBox" + (i * 4 + 1).ToString()).Text = sr.ReadLine
                Me.Controls("TextBox" + (i * 4 + 2).ToString()).Text = sr.ReadLine
                Me.Controls("TextBox" + (i * 4 + 3).ToString()).Text = sr.ReadLine
                Me.Controls("TextBox" + (i * 4 + 4).ToString()).Text = sr.ReadLine
            Catch
            End Try
        Next
        For i = 1 To count
            Try
                Me.Controls("Door" + i.ToString()).Text = sr.ReadLine
            Catch
                Me.Controls("Door" + i.ToString()).Text = "左側開門"
            End Try
        Next
        For i = 1 To count
            Try
                Me.Controls("label" + (6 + i * 6).ToString).Text = sr.ReadLine
            Catch
            End Try
        Next
        Try
            sr.Close()
        Catch
        End Try
    End Sub

    Private Sub Button200_Click(sender As Object, e As EventArgs) Handles Button200.Click
        Dim DirInfo As IO.DirectoryInfo
        DirInfo = New IO.DirectoryInfo("Test")
        For Each file In DirInfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
            file.CopyTo("Resource\" + file.Name, True)
        Next file
        While BusStop > 0
            Label600_Click(Nothing, Nothing)
        End While
        ReadFile()
        Me.Hide()
        Form1.Show()
    End Sub
End Class