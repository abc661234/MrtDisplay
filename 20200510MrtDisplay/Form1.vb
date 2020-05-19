Imports System.IO
Public Class Form1
    Dim ChineseStation(FormStart.BusStop) As String
    Dim EnglishStation(FormStart.BusStop) As String
    Dim DoorOpenSide(FormStart.BusStop) As String
    Dim TransferChinese(FormStart.BusStop) As String
    Dim TransferEnglish(FormStart.BusStop) As String
    Dim DestChinese As String
    Dim DestEnglish As String
    Dim blink As Integer = 0
    Dim time As Integer = 0
    Dim StationID As Integer = 0
    Dim driving As Boolean = False
    Dim up As Boolean = False
    Dim DriveTime As Integer = 0
    Dim transfer As Boolean = False
    Dim clock As Integer = 0
    Dim TransferLabelStartX As Integer = 1049
    Dim GotoRedLine As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To FormStart.BusStop - 1
            DoorOpenSide(i) = FormStart.Controls("Door" + (i + 1).ToString()).Text
            ChineseStation(i) = FormStart.Controls("TextBox" + (i * 4 + 1).ToString()).Text
            EnglishStation(i) = FormStart.Controls("TextBox" + (i * 4 + 2).ToString()).Text
            TransferChinese(i) = FormStart.Controls("TextBox" + (i * 4 + 3).ToString()).Text
            TransferEnglish(i) = FormStart.Controls("TextBox" + (i * 4 + 4).ToString()).Text
        Next
        DestChinese = FormStart.TextBox1000.Text
        DestEnglish = FormStart.TextBox2000.Text
        Label8.Text = DestChinese
        Label8.ForeColor = FormStart.TextBox1000.ForeColor
        RectangleShape1.BorderColor = FormStart.TextBox1000.ForeColor
        ShapeContainer1.BringToFront()
        Label3.Text = ChineseStation(0)
        Label4.Text = ChineseStation(1)
        Label5.Text = ChineseStation(2)
        If Label5.Text = "(終點站)" Then
            Label7.Visible = False
        End If
        Try
            My.Computer.Audio.Play(FormStart.Controls("label" + (12 + StationID * 6).ToString).Text)
        Catch
        End Try
        Me.TopMost = False
        If File.Exists("Resource\GotoRedLine.txt") Then
            GotoRedLine = True
            File.Delete("Resource\GotoRedLine.txt")
        End If
        If DoorOpenSide(StationID + 1) <> "左側開門" Then
            Label2.Font = New Font("Noto Sans CJK TC Regular", 33.75)
            Label2.BackColor = Color.Black
            Label2.ForeColor = Color.Green
            Label2.Text = DateTime.Now.ToString("HH：mm")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        blink += 1
        If blink = 1 Then
            clock = 0
        End If
        If blink Mod 2 = 1 Then
            Label4.Visible = False
        Else
            Label4.Visible = True
        End If
        If blink = 10 Then
            Timer1.Stop()
            blink = 0
            If DoorOpenSide(StationID + 1) = "左側開門" Then
                Label2.Text = "Exit this side"
                Label2.Font = New Font("Noto Sans CJK TC Regular", 24)
            End If
            Label8.Text = DestEnglish
            Me.Refresh()
            TimerUp.Start()
        End If
        If DoorOpenSide(StationID + 1) <> "左側開門" Then
            If blink Mod 2 = 1 Then
                Label2.Text = DateTime.Now.ToString("HH　mm")
            Else
                Label2.Text = DateTime.Now.ToString("HH：mm")
            End If
        End If
    End Sub

    Private Sub TimerUp_Tick(sender As Object, e As EventArgs) Handles TimerUp.Tick
        If Not driving Then
            Label1.Text = EnglishStation(StationID + 1)
        Else
            Label1.Text = "Next：" & EnglishStation(StationID + 1)
        End If
        If Label3.Top > 251 Then
            Label3.Top -= 1
            Label4.Top -= 1
            Label5.Top -= 1
            Label6.Top -= 1
            Label7.Top -= 1
            Label1.Top -= 1
        Else
            time += 1
        End If
        If time = 100 Then
            TimerUp.Stop()
            DriveTime += 1
            time = 0
            Label3.Top = 385
            Label4.Top = 385
            Label5.Top = 385
            Label6.Top = 385
            Label7.Top = 385
            up = False
            If Not driving And TransferChinese(StationID + 1) <> "" Then
                TimerTransfer.Start()
                Label14.Text = TransferChinese(StationID + 1)
            Else
                TimerUp2.Start()
                Label8.Text = DestChinese
                Me.Refresh()
            End If
            If Not driving Then
                If DoorOpenSide(StationID + 1) = "左側開門" Then
                    Label2.Text = "本側開門"
                    Label2.Font = New Font("Noto Sans CJK TC Regular", 33.75)
                End If
                Label8.Text = DestChinese
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub TimerUp2_Tick(sender As Object, e As EventArgs) Handles TimerUp2.Tick
        If Label3.Top > 318 Then
            Label3.Top -= 1
            Label4.Top -= 1
            Label5.Top -= 1
            Label6.Top -= 1
            Label7.Top -= 1
            Label1.Top -= 1
        ElseIf Not driving Then
            Me.Refresh()
            TimerUp2.Stop()
            Label1.Top = 385
            If DriveTime = 2 Then
                If StationID + 3 = FormStart.BusStop Then
                    TimerUp2.Stop()
                    Application.Restart()
                Else
                    Try
                        My.Computer.Audio.Play("警示音.wav")
                    Catch
                    End Try
                    DriveTime = 0
                    StationID += 1
                    Label9.Text = ChineseStation(StationID + 0)
                    Label10.Text = ChineseStation(StationID + 1)
                    Label11.Text = ChineseStation(StationID + 2)
                    If Label11.Text = "(終點站)" Then
                        Label7.Visible = False
                        Label13.Visible = False
                    End If
                    If GotoRedLine And ChineseStation(StationID + 1) = "中山" Then
                        DestChinese = " 🅁   淡   水"
                        DestEnglish = " 🅁   Tamsui"
                        Label8.Text = DestChinese
                        Label8.ForeColor = Color.Red
                        RectangleShape1.BorderColor = Color.Red
                    End If
                    TimerUpdateStationName.Start()
                    Label2.Font = New Font("Noto Sans CJK TC Regular", 33.75)
                    Label2.BackColor = Color.Black
                    Label2.ForeColor = Color.Green
                    Label2.Text = DateTime.Now.ToString("HH：mm")
                End If
            Else
                Timer1.Start()
            End If
        ElseIf driving Then
            TimerUp2.Stop()
            Label1.Top = 385
            blink = 0
            up = False
            DriveTime += 1
        End If
    End Sub

    Private Sub TimerUpdateStationName_Tick(sender As Object, e As EventArgs) Handles TimerUpdateStationName.Tick
        If Label9.Top > 318 Then
            Label3.Top -= 1
            Label4.Top -= 1
            Label5.Top -= 1
            Label6.Top -= 1
            Label7.Top -= 1
            Label9.Top -= 1
            Label10.Top -= 1
            Label11.Top -= 1
            Label12.Top -= 1
            Label13.Top -= 1
        Else
            TimerUpdateStationName.Stop()
            Label3.Text = Label9.Text
            Label4.Text = Label10.Text
            Label5.Text = Label11.Text
            Label3.Top = 318
            Label4.Top = 318
            Label5.Top = 318
            Label6.Top = 318
            Label7.Top = 318
            Label9.Top = 385
            Label10.Top = 385
            Label11.Top = 385
            Label12.Top = 385
            Label13.Top = 385
            Me.Refresh()
            TimerCurrentTime.Stop()
            clock = 0
            TimerDrive.Start()
        End If
    End Sub

    Private Sub TimerDrive_Tick(sender As Object, e As EventArgs) Handles TimerDrive.Tick
        driving = True
        blink += 1
        If blink Mod 2 = 1 Then
            If Not up Then
                Label6.Visible = False
            End If
            Label2.Text = DateTime.Now.ToString("HH　mm")
        Else
            Label6.Visible = True
            Label2.Text = DateTime.Now.ToString("HH：mm")
        End If
        If blink = 10 Then
            blink = 0
            TimerUp.Start()
            Label8.Text = DestEnglish
            Me.Refresh()
            up = True
        End If
        If DriveTime = 1 Then
            TimerDrive.Stop()
            Try
                My.Computer.Audio.Play(FormStart.Controls("label" + (12 + StationID * 6).ToString).Text)
            Catch
            End Try
            driving = False
            blink = 0
            DriveTime = 0
            TimerCurrentTime.Start()
            Timer1.Start()
            If DoorOpenSide(StationID + 1) = "左側開門" Then
                Label2.Font = New Font("Noto Sans CJK TC Regular", 33)
                Label2.BackColor = Color.Green
                Label2.ForeColor = Color.Yellow
                Label2.Text = "本側開門"
            End If
            Label6.Visible = True
        End If
        If DoorOpenSide(StationID + 1) <> "左側開門" Then
            If blink Mod 2 = 1 Then
                Label2.Text = DateTime.Now.ToString("HH　mm")
            Else
                Label2.Text = DateTime.Now.ToString("HH：mm")
            End If
        End If
    End Sub

    Private Sub TimerTransfer_Tick(sender As Object, e As EventArgs) Handles TimerTransfer.Tick
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label1.Visible = False
        If Label14.Width > 825 And (Label14.Left + Label14.Width) > TransferLabelStartX + 12 Then
            Label14.Left -= 4
        ElseIf Label14.Width <= 825 And Label14.Left > 218 Then
            Label14.Left -= 4
        Else
            TimerTransfer.Stop()
            TimerTransfer2.Start()
        End If
    End Sub

    Private Sub TimerTransfer2_Tick(sender As Object, e As EventArgs) Handles TimerTransfer2.Tick
        time += 1
        If time = 100 And transfer = False Then
            TimerTransfer2.Stop()
            time = 0
            Label14.Left = TransferLabelStartX
            Label14.Text = TransferEnglish(StationID + 1)
            transfer = True
            Label8.Text = DestEnglish
            Me.Refresh()
            If DoorOpenSide(StationID + 1) = "左側開門" Then
                Label2.Text = "Exit this side"
                Label2.Font = New Font("Noto Sans CJK TC Regular", 24)
            End If
            TimerTransfer.Start()
        End If
        If time = 100 And transfer = True Then
            TimerTransfer2.Stop()
            time = 0
            Label14.Left = TransferLabelStartX
            transfer = False
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            If Label5.Text <> "(終點站)" Then
                Label7.Visible = True
            End If
            Label1.Visible = True
            Label1.Text = ""
            Me.Refresh()
            If DoorOpenSide(StationID + 1) = "左側開門" Then
                Label2.Text = "本側開門"
                Label2.Font = New Font("Noto Sans CJK TC Regular", 33)
            End If
            Label8.Text = DestChinese
            TimerUp2.Start()
        End If
    End Sub

    Private Sub TimerCurrentTime_Tick(sender As Object, e As EventArgs) Handles TimerCurrentTime.Tick
        clock += 1
        If clock Mod 2 = 1 And DoorOpenSide(StationID + 1) = "右側開門" Then
            Label2.Text = DateTime.Now.ToString("HH　mm")
        ElseIf clock Mod 2 = 0 And DoorOpenSide(StationID + 1) = "右側開門" Then
            Label2.Text = DateTime.Now.ToString("HH：mm")
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class
