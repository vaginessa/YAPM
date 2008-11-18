Option Strict On

Public Class frmMain

    Private bProcessHover As Boolean = True

    Private Const HELP_PATH As String = "C:\Users\Admin\Desktop\YAPM\YAPM\Help\help.htm"

    ' Refresh process list in listview
    Private Sub refreshProcessList()

        Dim p As cProc
        Dim proc() As cProc
        Dim lvi As ListViewItem
        Dim x As Integer = 0
        Dim exist As Boolean = False

        ' Here is the list of the differents columns :
        ' Name
        ' PID
        ' User
        ' Processor time
        ' Memory
        ' Threads
        ' Priority
        ' Path

        ReDim proc(0)
        mdlProcess.Enumerate(proc)

        ' Refresh (or suppress) all processes displayed in listview
        For Each lvi In Me.lvProcess.Items

            ' Test if process exist
            For Each p In proc
                If p.Pid = CInt(Val(lvi.SubItems(1).Text)) And p.Name = lvi.Text Then
                    exist = True
                    p.IsDisplayed = True
                    Exit For
                End If
            Next

            If exist = False Then
                ' Process no longer exists
                lvi.Remove()
            Else

                ' Refresh process informations
                exist = exist
            End If
            exist = False
        Next

        ' Add all non displayed processe (new processes)
        For Each p In proc

            If p.IsDisplayed = False Then

                p.IsDisplayed = True

                ' Get the process name
                Dim o As String = p.Name
                Dim it As New ListViewItem

                If Len(o) > 0 Then

                    it.Text = o

                    Dim lsub1 As New ListViewItem.ListViewSubItem
                    lsub1.Text = CStr(p.Pid)

                    Dim lsub2 As New ListViewItem.ListViewSubItem
                    Dim lsub3 As New ListViewItem.ListViewSubItem
                    Dim lsub4 As New ListViewItem.ListViewSubItem
                    Dim lsub5 As New ListViewItem.ListViewSubItem
                    Dim lsub6 As New ListViewItem.ListViewSubItem
                    Dim lsub7 As New ListViewItem.ListViewSubItem
                    Dim lsub8 As New ListViewItem.ListViewSubItem

                    If p.Pid > 4 Then

                        lsub2.Text = "N/A"

                        ' Add icon
                        Try

                            Dim fName As String = mdlProcess.GetPath(p.Pid)

                            If IO.File.Exists(fName) Then
                                Dim img As System.Drawing.Icon = GetIcon(fName, True)
                                imgProcess.Images.Add(fName, img)
                                it.ImageKey = fName
                            Else
                                it.ImageKey = "noicon"
                            End If

                            lsub7.Text = fName

                        Catch ex As Exception
                            it.ImageKey = "noicon"
                            lsub7.Text = "N/A"
                            it.ForeColor = Color.Gray
                            lsub8.Text = "N/A"
                        End Try

                    Else
                        lsub2.Text = "SYSTEM"
                        lsub3.Text = "N/A"
                        lsub4.Text = "N/A"
                        lsub5.Text = "N/A"
                        lsub6.Text = "N/A"
                        lsub7.Text = "N/A"
                        lsub8.Text = "N/A"
                        it.ImageKey = "noIcon"
                    End If

                    it.SubItems.Add(lsub1)
                    it.SubItems.Add(lsub2)
                    it.SubItems.Add(lsub3)
                    it.SubItems.Add(lsub4)
                    it.SubItems.Add(lsub5)
                    it.SubItems.Add(lsub6)
                    it.SubItems.Add(lsub7)
                    it.SubItems.Add(lsub8)

                    it.Group = lvProcess.Groups(0)

                    lvProcess.Items.Add(it)
                End If
            End If

        Next


        ' Here we retrieve some informations for all our displayed processes
        For Each lvi In Me.lvProcess.Items

            Try
                Dim id As Integer = CInt(Val(lvi.SubItems(1).Text))
                'Dim pci As PROCESS_CHANGEABLES_INFOS = mdlProcess.GetProcessChangeableInfos(id)
                Dim gProc As Process = Process.GetProcessById(id)

                ' Processor time
                ' Memory
                ' Threads
                ' Priority
                ' Path

                Dim ts As TimeSpan = gProc.TotalProcessorTime
                Dim fName As String = mdlProcess.GetPath(id)
                Dim s As String = String.Format("{0:00}", ts.TotalHours) & ":" & _
                    String.Format("{0:00}", ts.Minutes) & ":" & _
                    String.Format("{0:00}", ts.Seconds)

                With lvi
                    .SubItems(3).Text = s
                    .SubItems(4).Text = CStr(gProc.WorkingSet64 / 1024) & " Kb"
                    .SubItems(5).Text = CStr(gProc.Threads.Count)
                    .SubItems(6).Text = gProc.PriorityClass.ToString
                    .SubItems(8).Text = gProc.StartTime.ToLongDateString & " -- " & gProc.StartTime.ToLongTimeString
                End With

                lvi.Tag = Nothing

            Catch ex As Exception
                ' Access denied or ?
                lvi.Tag = ex
            End Try

        Next

    End Sub

    Private Sub timerProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerProcess.Tick
        refreshProcessList()
        Me.Text = "Yet Another Process Monitor -- " & CStr(Me.lvProcess.Items.Count) & " processes running"
    End Sub

    Private Sub lvProcess_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProcess.SelectedIndexChanged
        ' New process selected
        If lvProcess.SelectedItems.Count = 1 Then
            Dim it As ListViewItem = lvProcess.SelectedItems.Item(0)

            Me.lblProcessName.Text = "Process name : " & it.Text
            Me.lblProcessPath.Text = "Unable to retrieve path"

            If it.Tag Is Nothing Then

                Try
                    Dim proc As Process = Process.GetProcessById(CInt(it.SubItems(1).Text))

                    Me.cbPriority.Text = proc.PriorityClass.ToString

                    ' Description
                    Dim s As String = ""
                    s = "{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
                    s = s & "{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b File properties\b0\par"
                    s = s & "\tab File name :\tab\tab " & it.Text & "\par"
                    s = s & "\tab Path :\tab\tab\tab " & Replace(it.SubItems(7).Text, "\", "\\") & "\par"
                    s = s & "\tab Description :\tab\tab " & proc.MainModule.FileVersionInfo.FileDescription & "\par"
                    s = s & "\tab Company name :\tab\tab " & proc.MainModule.FileVersionInfo.CompanyName & "\par"
                    s = s & "\tab Version :\tab\tab " & proc.MainModule.FileVersionInfo.FileVersion & "\par"
                    s = s & "\tab Copyright :\tab\tab " & proc.MainModule.FileVersionInfo.LegalCopyright & "\par"
                    s = s & "\par"
                    s = s & "  \b Process description\b0\par"
                    s = s & "\tab PID :\tab\tab\tab " & it.SubItems(1).Text & "\par"
                    s = s & "\tab Threads :\tab\tab " & it.SubItems(5).Text & "\par"
                    s = s & "\tab Start time :\tab\tab " & it.SubItems(8).Text & "\par"
                    s = s & "\tab Priority :\tab\tab\tab " & it.SubItems(6).Text & "\par"
                    s = s & "\tab User :\tab\tab\tab " & it.SubItems(2).Text & "\par"
                    s = s & "\tab Processor time :\tab\tab " & it.SubItems(3).Text & "\par"
                    s = s & "\tab Memory :\tab\tab " & it.SubItems(4).Text & "\par"
                    s = s & "\par"
                    s = s & "  \b On line informations\b0\par"
                    s = s & "\tab Description :\tab\tab " & "Here is the online description" & "\par"
                    s = s & "\tab State :\tab\tab\tab " & "Here is the online state" & "\par"

                    If chkModules.Checked Then
                        ' Retrieve modules
                        s = s & "\par"
                        s = s & "  \b Loaded modules\b0\par"
                        Dim p As ProcessModuleCollection = proc.Modules
                        Dim m As ProcessModule
                        For Each m In p
                            s = s & "\tab " & Replace(m.FileVersionInfo.FileName, "\", "\\") & "\par"
                        Next

                        ' Retrieve threads infos
                        s = s & "\par"
                        s = s & "  \b Threads\b0\par"
                        Dim t As ProcessThreadCollection = proc.Threads
                        Dim pt As ProcessThread
                        For Each pt In t
                            s = s & "\tab " & CStr(pt.Id) & "\par"
                            s = s & "\tab\tab " & "Priority level : " & CStr(pt.PriorityLevel.ToString) & "\par"
                            Dim tsp As TimeSpan = pt.TotalProcessorTime
                            Dim s2 As String = String.Format("{0:00}", tsp.TotalHours) & ":" & _
                                String.Format("{0:00}", tsp.Minutes) & ":" & _
                                String.Format("{0:00}", tsp.Seconds)
                            s = s & "\tab\tab " & "Start address : " & CStr(pt.StartAddress) & "\par"
                            s = s & "\tab\tab " & "Start time : " & pt.StartTime.ToLongDateString & " -- " & pt.StartTime.ToLongTimeString & "\par"
                            s = s & "\tab\tab " & "State : " & CStr(pt.ThreadState.ToString) & "\par"
                            s = s & "\tab\tab " & "Processor time : " & s2 & "\par"
                        Next
                    End If
                    s = s & "}"

                    rtb.Rtf = s

                    ' Icons
                    Try
                        pctBigIcon.Image = GetIcon(it.SubItems(7).Text, False).ToBitmap
                        pctSmallIcon.Image = GetIcon(it.SubItems(7).Text, True).ToBitmap
                    Catch ex As Exception
                        pctSmallIcon.Image = Me.imgProcess.Images("noicon")
                        pctBigIcon.Image = Me.imgMain.Images("noicon32")
                    End Try

                    Me.lblProcessName.Text = "Process name : " & it.Text
                    Me.lblProcessPath.Text = "Process path : " & it.SubItems(7).Text

                Catch ex As Exception
                    Dim s As String = ""
                    Dim er As Exception = ex

                    s = "{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
                    s = s & "{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b An error occured\b0\par"
                    s = s & "\tab Message :\tab " & er.Message & "\par"
                    s = s & "\tab Source :\tab\tab " & er.Source & "\par"
                    If Len(er.HelpLink) > 0 Then s = s & "\tab Help link :\tab " & er.HelpLink & "\par"
                    s = s & "}"

                    rtb.Rtf = s

                    pctSmallIcon.Image = Me.imgProcess.Images("noicon")
                    pctBigIcon.Image = Me.imgMain.Images("noicon32")
                End Try

            Else
                ' Error
                Dim s As String = ""
                Dim er As Exception = CType(it.Tag, Exception)

                s = "{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
                s = s & "{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b An error occured\b0\par"
                s = s & "\tab Message :\tab " & er.Message & "\par"
                s = s & "\tab Source :\tab\tab " & er.Source & "\par"
                If Len(er.HelpLink) > 0 Then s = s & "\tab Help link :\tab " & er.HelpLink & "\par"
                s = s & "}"

                rtb.Rtf = s

                pctSmallIcon.Image = Me.imgProcess.Images("noicon")
                pctBigIcon.Image = Me.imgMain.Images("noicon32")
            End If

        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Me.pctProcess_Click(Nothing, Nothing)

        refreshProcessList()
        refreshServiceList()
        With Me
            .panelActions1.BackColor = .BackColor
            .panelActions2.BackColor = .BackColor
            .panelActions3.BackColor = .BackColor
            .panelActions4.BackColor = .BackColor
            .pctInfo.BackColor = .BackColor
            .gpProc1.BackColor = .BackColor
        End With

        If mdlPrivileges.IsAdministrator = False Then
            MsgBox("You are not logged as an administrator. You cannot retrieve informations for system processes.", MsgBoxStyle.Critical, "You are not part of administrator group")
        End If

        ' Create tooltips
        SetToolTip(Me.lblResCount, "Number of results. Click on the number to view results.")
        SetToolTip(Me.txtSearch, "Enter text here to search a process/service.")
        SetToolTip(Me.chkModules, "Check if you want to retrieve modules and threads infos when you click on listview.")
        SetToolTip(Me.cmdInfosToClipB, "Copy process informations to clipboard. Use left click to copy as text, right click to copy as rtf (preserve text style).")
        SetToolTip(Me.lblProcessPath, "Path of the main executable.")
        SetToolTip(Me.lblServicePath, "Path of the main executable of the service.")
        SetToolTip(Me.cbPriority, "Change selected processes priority.")
        SetToolTip(Me.cmdSetPriority, "Set priority.")
        SetToolTip(Me.cmdKill, "Kill selected processes.")
        SetToolTip(Me.cmdPause, "Suspend selected processes.")
        SetToolTip(Me.cmdResume, "Resume selected processes.")
        SetToolTip(Me.cmdAffinity, "Change affinity of selected processes.")
        SetToolTip(Me.lnkOpenDir, "Open file location of selected processes.")
        SetToolTip(Me.lnkProp, "Open property box for selected processes.")
        SetToolTip(Me.cmdTray, "Hide main form (double click on icon on tray to restore).")
        SetToolTip(Me.tv, "Selected service depends on this.")
        SetToolTip(Me.tv2, "This services depend on selected service.")

        ' Load help file
        Dim path As String = HELP_PATH
        If IO.File.Exists(path) = False Then
            WBHelp.Document.Write("<body link=blue vlink=purple><span>Help file cannot be found. <p></span><span>Please download help file at <a href=" & Chr(34) & "http://sourceforge.net/projects/yaprocmon/" & Chr(34) & ">http://sourceforge.net/projects/yaprocmon</a> and save it in Help directory.</span></body>")
        Else
            WBHelp.Navigate(path)
        End If

    End Sub

    Private Sub txtSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Click
        Call txtSearch_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If bProcessHover Then
            Dim it As ListViewItem
            For Each it In lvProcess.Items
                If InStr(LCase(it.Text), LCase(txtSearch.Text)) = 0 Then
                    it.Group = lvProcess.Groups(0)
                Else
                    it.Group = lvProcess.Groups(1)
                End If
            Next
            Me.lblResCount.Text = CStr(lvProcess.Groups(1).Items.Count)
        Else
            Dim it As ListViewItem
            For Each it In lvServices.Items
                If InStr(LCase(it.Text), LCase(txtSearch.Text)) = 0 And _
                        InStr(LCase(it.SubItems.Item(1).Text), LCase(txtSearch.Text)) = 0 Then
                    it.Group = lvServices.Groups(0)
                Else
                    it.Group = lvServices.Groups(1)
                End If
            Next
            Me.lblResCount.Text = CStr(lvServices.Groups(1).Items.Count)
        End If
    End Sub

    'Private Sub lvMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMain.SelectedIndexChanged
    '    If lvMain.SelectedItems.Count > 0 Then
    '        Dim it As ListViewItem = lvMain.SelectedItems.Item(0)
    '        Select Case it.Index
    '            Case 0
    '                Me.panelMain.Visible = True
    '                Me.panelMain2.Visible = False
    '                Me.panelMain3.Visible = False
    '                Me.panelMain4.Visible = False
    '                Me.panelMain5.Visible = False
    '                Me.panelActions1.Visible = True
    '                Me.panelActions2.Visible = False
    '                Me.panelActions3.Visible = False
    '                Me.panelActions4.Visible = False
    '                Me.panelActions5.Visible = False
    '                Me.panelInfos.Visible = True
    '                Me.panelInfos2.Visible = False
    '            Case 1
    '                Me.panelMain.Visible = False
    '                Me.panelMain2.Visible = True
    '                Me.panelMain3.Visible = False
    '                Me.panelMain4.Visible = False
    '                Me.panelMain5.Visible = False
    '                Me.panelActions1.Visible = False
    '                Me.panelActions2.Visible = True
    '                Me.panelActions3.Visible = False
    '                Me.panelActions4.Visible = False
    '                Me.panelActions5.Visible = False
    '                Me.panelInfos.Visible = False
    '                Me.panelInfos2.Visible = True
    '            Case 2
    '                Me.panelMain.Visible = False
    '                Me.panelMain2.Visible = False
    '                Me.panelMain3.Visible = True
    '                Me.panelMain4.Visible = False
    '                Me.panelMain5.Visible = False
    '                Me.panelActions1.Visible = False
    '                Me.panelActions2.Visible = False
    '                Me.panelActions3.Visible = True
    '                Me.panelActions4.Visible = False
    '                Me.panelActions5.Visible = False
    '            Case 3
    '                Me.panelMain.Visible = False
    '                Me.panelMain2.Visible = False
    '                Me.panelMain3.Visible = False
    '                Me.panelMain4.Visible = True
    '                Me.panelMain5.Visible = False
    '                Me.panelActions1.Visible = False
    '                Me.panelActions2.Visible = False
    '                Me.panelActions3.Visible = False
    '                Me.panelActions4.Visible = True
    '                Me.panelActions5.Visible = False
    '            Case 4
    '                Me.panelMain.Visible = False
    '                Me.panelMain2.Visible = False
    '                Me.panelMain3.Visible = False
    '                Me.panelMain4.Visible = False
    '                Me.panelMain5.Visible = True
    '                Me.panelActions1.Visible = False
    '                Me.panelActions2.Visible = False
    '                Me.panelActions3.Visible = False
    '                Me.panelActions4.Visible = False
    '                Me.panelActions5.Visible = True
    '        End Select
    '    End If
    'End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.panelMain.Left = 206
        Me.panelMain.Top = 34 + 27
        Me.panelMain2.Left = 206
        Me.panelMain2.Top = 34 + 27
        Me.panelMain3.Left = 206
        Me.panelMain3.Top = 34 + 27
        Me.panelMain4.Left = 206
        Me.panelMain4.Top = 34 + 27
        Me.panelActions1.Left = 3
        Me.panelActions1.Top = 266 + 27
        Me.panelActions2.Left = 3
        Me.panelActions2.Top = 266 + 27
        Me.panelActions3.Left = 3
        Me.panelActions3.Top = 266 + 27
        Me.panelActions4.Left = 3
        Me.panelActions4.Top = 266 + 27
        Me.panelInfos.Left = 206
        Me.panelInfos.Top = 280 + 27
        Me.panelInfos2.Left = 206
        Me.panelInfos2.Top = 280 + 27
    End Sub

    Private Sub cmdKill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKill.Click
        ' Kill selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If it.SubItems(7).Text <> "N/A" Then _
            Process.GetProcessById(CInt(it.SubItems(1).Text)).Kill()
        Next
    End Sub

    Private Sub cmdResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResume.Click
        ' Resume selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If it.SubItems(7).Text <> "N/A" Then _
            ResumeProcess(CInt(it.SubItems(1).Text))
        Next
    End Sub

    Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
        ' Stop selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If it.SubItems(7).Text <> "N/A" Then _
            SuspendProcess(CInt(it.SubItems(1).Text))
        Next
    End Sub

    Private Sub cmdAffinity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAffinity.Click
        ' Choose affinity for selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            'INSERT CODE HERE
            'If it.SubItems(7).Text <> "N/A" Then _
            'http://www.vbfrance.com/codes/AFFINITE-PROCESSUS-THREADS_42365.aspx
        Next
    End Sub

    Private Sub cmdSetPriority_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetPriority.Click
        ' Set priority to selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Dim p As ProcessPriorityClass
            Select Case cbPriority.SelectedIndex
                Case -1
                    Exit Sub
                Case 0
                    p = ProcessPriorityClass.Idle
                Case 1
                    p = ProcessPriorityClass.BelowNormal
                Case 2
                    p = ProcessPriorityClass.Normal
                Case 3
                    p = ProcessPriorityClass.AboveNormal
                Case 4
                    p = ProcessPriorityClass.High
                Case 5
                    p = ProcessPriorityClass.RealTime
            End Select
            If it.SubItems(7).Text <> "N/A" Then _
            SetProcessPriority(CInt(it.SubItems(1).Text), p)
        Next
    End Sub

    ' Refresh service list
    Private Sub refreshServiceList()

        Dim o As System.ServiceProcess.ServiceController() = System.ServiceProcess.ServiceController.GetServices()
        Dim o1 As System.ServiceProcess.ServiceController

        For Each o1 In o

            Dim it As New ListViewItem

            it.Text = o1.ServiceName
            it.ImageKey = "service"

            Dim lsub1 As New ListViewItem.ListViewSubItem
            Dim lsub2 As New ListViewItem.ListViewSubItem
            Dim lsub3 As New ListViewItem.ListViewSubItem
            Dim lsub4 As New ListViewItem.ListViewSubItem
            Dim lsub5 As New ListViewItem.ListViewSubItem

            Dim path As String = CStr(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\" & it.Text, "ImagePath", ""))
            If path.Chars(0) = Chr(34) Then
                path = path.Substring(1, path.Length - 2)
            End If

            lsub4.Text = path
            lsub2.Text = o1.Status.ToString
            lsub3.Text = mdlProcess.GetServiceStartTypeFromInt(CInt(Val(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\" & it.Text, "Start", ""))))
            lsub1.Text = o1.DisplayName
            lsub5.Text = CStr(IIf(o1.CanPauseAndContinue, "Pause/Continue ", "")) & _
                        CStr(IIf(o1.CanShutdown, "Shutdown ", "")) & _
                        CStr(IIf(o1.CanStop, "Stop ", ""))

            it.SubItems.Add(lsub1)
            it.SubItems.Add(lsub2)
            it.SubItems.Add(lsub3)
            it.SubItems.Add(lsub4)
            it.SubItems.Add(lsub5)

            lvServices.Items.Add(it)

        Next

    End Sub

    Private Sub timerServices_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerServices.Tick
        ' refreshServiceList()
    End Sub

    Private Sub lvServices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvServices.SelectedIndexChanged
        ' New process selected
        If lvServices.SelectedItems.Count > 0 Then
            Dim it As ListViewItem = lvServices.SelectedItems.Item(0)
            Try
                'Dim proc As Process = Process.GetProcessById(CInt(it.SubItems(1).Text))

                Me.lblServiceName.Text = "Service name : " & it.Text
                Me.lblServicePath.Text = "Service path : " & it.SubItems(4).Text

                ' Description
                Dim s As String = vbNullString
                Dim description As String = vbNullString
                Dim diagnosticsMessageFile As String = vbNullString
                Dim group As String = vbNullString
                Dim objectName As String = vbNullString
                Dim tag As String = vbNullString

                s = GetServiceInfo(it.Text, "ImagePath")
                description = GetServiceInfo(it.Text, "Description")
                diagnosticsMessageFile = GetServiceInfo(it.Text, "DiagnosticsMessageFile")
                group = GetServiceInfo(it.Text, "Group")
                objectName = GetServiceInfo(it.Text, "ObjectName")

                s = "{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
                s = s & "{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b Service properties\b0\par"
                s = s & "\tab Name :\tab\tab\tab " & it.Text & "\par"
                s = s & "\tab Common name :\tab\tab " & it.SubItems(1).Text & "\par"
                If Len(it.SubItems(4).Text) > 0 Then s = s & "\tab Path :\tab\tab\tab " & Replace(it.SubItems(4).Text, "\", "\\") & "\par"
                If Len(description) > 0 Then s = s & "\tab Description :\tab\tab " & description & "\par"
                If Len(group) > 0 Then s = s & "\tab Group :\tab\tab\tab " & group & "\par"
                If Len(objectName) > 0 Then s = s & "\tab ObjectName :\tab\tab " & objectName & "\par"
                If Len(diagnosticsMessageFile) > 0 Then s = s & "\tab DiagnosticsMessageFile :\tab\tab " & diagnosticsMessageFile & "\par"
                If Len(it.SubItems(2).Text) > 0 Then s = s & "\tab State :\tab\tab\tab " & it.SubItems(2).Text & "\par"
                If Len(it.SubItems(3).Text) > 0 Then s = s & "\tab Startup :\tab\tab " & it.SubItems(3).Text & "\par"
                If Len(it.SubItems(5).Text) > 0 Then s = s & "\tab Availables actions :\tab " & it.SubItems(5).Text & "\par"


                's = s & "\par"
                's = s & "  \b Process description\b0\par"
                's = s & "\tab PID :\tab\tab\tab " & it.SubItems(1).Text & "\par"
                's = s & "\tab Threads :\tab\tab " & it.SubItems(5).Text & "\par"
                's = s & "\tab Start time :\tab\tab " & it.SubItems(8).Text & "\par"
                's = s & "\tab Priority :\tab\tab\tab " & it.SubItems(6).Text & "\par"
                's = s & "\tab User :\tab\tab\tab " & it.SubItems(2).Text & "\par"
                's = s & "\tab Processor time :\tab\tab " & it.SubItems(3).Text & "\par"
                's = s & "\tab Memory :\tab\tab " & it.SubItems(4).Text & "\par"
                's = s & "\par"
                's = s & "  \b On line informations\b0\par"
                's = s & "\tab Description :\tab\tab " & "Here is the online description" & "\par"
                's = s & "\tab State :\tab\tab\tab " & "Here is the online state" & "\par"

                s = s & "}"

                rtb2.Rtf = s

                ' Treeviews stuffs
                Dim n As New TreeNode
                Dim n3 As New TreeNode
                n.Text = "Dependencies"
                n3.Text = "Depends on"

                tv.Nodes.Clear()
                tv.Nodes.Add(n)
                tv2.Nodes.Clear()
                tv2.Nodes.Add(n3)

                n.Expand()
                n3.Expand()

                Dim o As System.ServiceProcess.ServiceController() = System.ServiceProcess.ServiceController.GetServices()
                Dim o1 As System.ServiceProcess.ServiceController

                For Each o1 In o
                    If o1.ServiceName = it.Text Then
                        ' Here we have 2 recursive methods to add nodes to treeview
                        addDependentServices(o1, n)
                        addServicesDependedOn(o1, n3)
                        Exit For
                    End If
                Next

                If n.Nodes.Count > 0 Then n.ImageKey = "ko" Else n.ImageKey = "ok"
                If n3.Nodes.Count > 0 Then n3.ImageKey = "ko" Else n3.ImageKey = "ok"

            Catch ex As Exception
                Dim s As String = ""
                Dim er As Exception = ex

                s = "{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
                s = s & "{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b An error occured\b0\par"
                s = s & "\tab Message :\tab " & er.Message & "\par"
                s = s & "\tab Source :\tab\tab " & er.Source & "\par"
                If Len(er.HelpLink) > 0 Then s = s & "\tab Help link :\tab " & er.HelpLink & "\par"
                s = s & "}"

                rtb2.Rtf = s
            End Try

        End If
    End Sub

#Region "Powerfull recursives methods for treeviews"
    ' Recursive method to add items in our treeview
    Private Sub addDependentServices(ByVal o As System.ServiceProcess.ServiceController, ByVal n As TreeNode)
        Dim o1 As System.ServiceProcess.ServiceController
        For Each o1 In o.DependentServices
            Dim n2 As New TreeNode
            With n2
                .ImageKey = "service"
                .Text = o1.ServiceName
            End With
            n.Nodes.Add(n2)
            addDependentServices(o1, n2)
        Next o1
    End Sub
    ' Recursive method to add items in our treeview
    Private Sub addServicesDependedOn(ByVal o As System.ServiceProcess.ServiceController, ByVal n As TreeNode)
        Dim o1 As System.ServiceProcess.ServiceController
        For Each o1 In o.ServicesDependedOn
            Dim n2 As New TreeNode
            With n2
                .ImageKey = "service"
                .Text = o1.ServiceName
            End With
            n.Nodes.Add(n2)
            addServicesDependedOn(o1, n2)
        Next o1
    End Sub
#End Region

    Private Sub panelInfos2_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Resize controls rtb2,tv and tv2
        Try
            Dim h As Integer = CInt(panelInfos2.Height - 47)
            tv.Height = h
            tv2.Height = h
            tv2.Top = 41 + tv.Height + 6
            rtb2.Width = panelInfos2.Width - 162
            rtb2.Height = panelInfos2.Height - 44
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTray.Click
        Me.Hide()
    End Sub

    Private Sub Tray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        saveDial.ShowDialog()
        Dim s As String = saveDial.FileName
        If Len(s) > 0 Then
            MsgBox(s)
        End If
    End Sub

    Private Sub pctJobs_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctJobs.MouseEnter
        Me.pctJobs.BorderStyle = BorderStyle.None
        Me.pctJobs.BackColor = Color.White
        Me.pctHelp.BorderStyle = BorderStyle.None
        Me.pctHelp.BackColor = Me.BackColor
        Me.pctService.BorderStyle = BorderStyle.None
        Me.pctService.BackColor = Me.BackColor
        Me.pctProcess.BorderStyle = BorderStyle.None
        Me.pctProcess.BackColor = Me.BackColor
    End Sub

    Private Sub pctProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctProcess.Click
        Me.bProcessHover = True
        Me.panelMain.Visible = True
        Me.panelMain2.Visible = False
        Me.panelMain3.Visible = False
        Me.panelMain4.Visible = False
        Me.panelActions1.Visible = True
        Me.panelActions2.Visible = False
        Me.panelActions3.Visible = False
        Me.panelActions4.Visible = False
        Me.panelInfos.Visible = True
        Me.panelInfos2.Visible = False
        Me.lblProcess.Enabled = True
        Me.lblProcess.ForeColor = Color.Red
        Me.lblServices.Enabled = False
        Me.lblServices.ForeColor = Color.Black
        Me.lblAddJobs.Enabled = False
        Me.lblAddJobs.ForeColor = Color.Black
        Me.lblHelp.Enabled = False
        Me.lblHelp.ForeColor = Color.Black
        Me.chkModules.Visible = True
    End Sub

    Private Sub pctService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctService.Click
        Me.bProcessHover = False
        Me.panelMain.Visible = False
        Me.panelMain2.Visible = True
        Me.panelMain3.Visible = False
        Me.panelMain4.Visible = False
        Me.panelActions1.Visible = False
        Me.panelActions2.Visible = True
        Me.panelActions3.Visible = False
        Me.panelActions4.Visible = False
        Me.panelInfos.Visible = False
        Me.panelInfos2.Visible = True
        Me.lblProcess.Enabled = False
        Me.lblProcess.ForeColor = Color.Black
        Me.lblServices.Enabled = True
        Me.lblServices.ForeColor = Color.Red
        Me.lblAddJobs.Enabled = False
        Me.lblAddJobs.ForeColor = Color.Black
        Me.lblHelp.Enabled = False
        Me.lblHelp.ForeColor = Color.Black
        Me.chkModules.Visible = False
    End Sub

    Private Sub pctJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctJobs.Click
        Me.bProcessHover = False
        Me.panelMain.Visible = False
        Me.panelMain2.Visible = False
        Me.panelMain3.Visible = True
        Me.panelMain4.Visible = False
        Me.panelActions1.Visible = False
        Me.panelActions2.Visible = False
        Me.panelActions3.Visible = True
        Me.panelActions4.Visible = False
        Me.lblProcess.Enabled = False
        Me.lblProcess.ForeColor = Color.Black
        Me.lblServices.Enabled = False
        Me.lblServices.ForeColor = Color.Black
        Me.lblAddJobs.Enabled = True
        Me.lblAddJobs.ForeColor = Color.Red
        Me.lblHelp.Enabled = False
        Me.lblHelp.ForeColor = Color.Black
    End Sub

    Private Sub pctHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctHelp.Click
        Me.bProcessHover = False
        Me.panelMain.Visible = False
        Me.panelMain2.Visible = False
        Me.panelMain3.Visible = False
        Me.panelMain4.Visible = True
        Me.panelActions1.Visible = False
        Me.panelActions2.Visible = False
        Me.panelActions3.Visible = False
        Me.panelActions4.Visible = True
        Me.lblProcess.Enabled = False
        Me.lblProcess.ForeColor = Color.Black
        Me.lblServices.Enabled = False
        Me.lblServices.ForeColor = Color.Black
        Me.lblAddJobs.Enabled = False
        Me.lblAddJobs.ForeColor = Color.Black
        Me.lblHelp.Enabled = True
        Me.lblHelp.ForeColor = Color.Red
    End Sub

    Private Sub pctService_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctService.MouseEnter
        Me.pctJobs.BorderStyle = BorderStyle.None
        Me.pctJobs.BackColor = Me.BackColor
        Me.pctHelp.BorderStyle = BorderStyle.None
        Me.pctHelp.BackColor = Me.BackColor
        Me.pctService.BorderStyle = BorderStyle.None
        Me.pctService.BackColor = Color.White
        Me.pctProcess.BorderStyle = BorderStyle.None
        Me.pctProcess.BackColor = Me.BackColor
    End Sub

    Private Sub pctProcess_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctProcess.MouseEnter
        Me.pctJobs.BorderStyle = BorderStyle.None
        Me.pctJobs.BackColor = Me.BackColor
        Me.pctHelp.BorderStyle = BorderStyle.None
        Me.pctHelp.BackColor = Me.BackColor
        Me.pctService.BorderStyle = BorderStyle.None
        Me.pctService.BackColor = Me.BackColor
        Me.pctProcess.BorderStyle = BorderStyle.None
        Me.pctProcess.BackColor = Color.White
    End Sub

    Private Sub pctHelp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctHelp.MouseEnter
        Me.pctJobs.BorderStyle = BorderStyle.None
        Me.pctJobs.BackColor = Me.BackColor
        Me.pctHelp.BorderStyle = BorderStyle.None
        Me.pctHelp.BackColor = Color.White
        Me.pctService.BorderStyle = BorderStyle.None
        Me.pctService.BackColor = Me.BackColor
        Me.pctProcess.BorderStyle = BorderStyle.None
        Me.pctProcess.BackColor = Me.BackColor
    End Sub

    Private Sub ExecuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteToolStripMenuItem.Click
        '
    End Sub

    Private Sub TakeFullPowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeFullPowerToolStripMenuItem.Click
        If TakeFullPowerToolStripMenuItem.Checked = False Then
            Me.TakeFullPowerToolStripMenuItem.Checked = True
            Me.Visible = False
            Call mdlPrivileges.SetDebuPrivilege()
            Me.lvProcess.Items.Clear()
            refreshProcessList()
            Me.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.AboutToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        My.Computer.Clipboard.SetImage(Me.pctBigIcon.Image)
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        My.Computer.Clipboard.SetImage(Me.pctSmallIcon.Image)
    End Sub

    Private Sub pctBigIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctBigIcon.MouseDown
        Me.ToolStripMenuItem6.Enabled = (Me.pctBigIcon.Image IsNot Nothing)
    End Sub

    Private Sub pctSmallIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSmallIcon.MouseDown
        Me.ToolStripMenuItem7.Enabled = (Me.pctSmallIcon.Image IsNot Nothing)
    End Sub

    Private Sub cmdInfosToClipB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdInfosToClipB.Click
        If Me.rtb.Text.Length > 0 Then
            My.Computer.Clipboard.SetText(Me.rtb.Text, TextDataFormat.Text)
        End If
    End Sub

    Private Sub cmdInfosToClipB_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdInfosToClipB.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.rtb.Rtf.Length > 0 Then
                My.Computer.Clipboard.SetText(Me.rtb.Rtf, TextDataFormat.Rtf)
            End If
        End If
    End Sub

    Private Sub rtb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtb.TextChanged
        Me.cmdInfosToClipB.Enabled = (rtb.Rtf.Length > 0)
    End Sub

    Private Sub KillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).Kill()
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                mdlProcess.SuspendProcess(CInt(Val(it.SubItems(1).Text)))
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub ResumeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumeToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                mdlProcess.ResumeProcess(CInt(Val(it.SubItems(1).Text)))
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub IdleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdleToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).PriorityClass = ProcessPriorityClass.Idle
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub BelowNormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BelowNormalToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).PriorityClass = ProcessPriorityClass.BelowNormal
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).PriorityClass = ProcessPriorityClass.Normal
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub AboveNormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboveNormalToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).PriorityClass = ProcessPriorityClass.AboveNormal
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub HighToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HighToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).PriorityClass = ProcessPriorityClass.High
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub RealTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealTimeToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            Try
                If it.SubItems(7).Text <> "N/A" Then _
                Process.GetProcessById(CInt(Val(it.SubItems(1).Text))).PriorityClass = ProcessPriorityClass.RealTime
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If IO.File.Exists(it.SubItems(7).Text) Then
                If it.SubItems(7).Text <> "N/A" Then _
                ShowFileProperty(it.SubItems(7).Text)
            End If
        Next
    End Sub

    Private Sub OpenFirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFirectoryToolStripMenuItem.Click
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If it.SubItems(7).Text <> "N/A" Then _
            OpenDirectory(it.SubItems(7).Text)
        Next
    End Sub

    Private Sub lblResCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblResCount.Click
        If bProcessHover Then
            Me.lvProcess.Focus()
            Try
                System.Windows.Forms.SendKeys.Send(Me.lvProcess.Groups(1).Items(0).Text)
            Catch ex As Exception
            End Try
        Else
            Me.lvServices.Focus()
            Try
                System.Windows.Forms.SendKeys.Send(Me.lvServices.Groups(1).Items(0).Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SetToolTip(ByVal ctrl As Control, ByVal text As String)
        Dim tToolTip As ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        With ttooltip
            .SetToolTip(ctrl, text)
            .IsBalloon = True
            .Active = True
        End With
    End Sub

    Private Sub chkModules_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkModules.VisibleChanged
        If Me.chkModules.Visible Then
            Me.txtSearch.Left = 157
            Me.txtSearch.Width = 362
        Else
            Me.txtSearch.Left = 4
            Me.txtSearch.Width = 515
        End If
    End Sub

    Private Sub lnkProp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProp.LinkClicked
        ' File properties for selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If IO.File.Exists(it.SubItems(7).Text) Then
                If it.SubItems(7).Text <> "N/A" Then _
                ShowFileProperty(it.SubItems(7).Text)
            End If
        Next
    End Sub

    Private Sub lnkOpenDir_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenDir.LinkClicked
        ' Open directory of selected processes
        Dim it As ListViewItem
        For Each it In Me.lvProcess.SelectedItems
            If it.SubItems(7).Text <> "N/A" Then _
            OpenDirectory(it.SubItems(7).Text)
        Next
    End Sub

    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub lnkProjectPage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProjectPage.LinkClicked
        mdlFile.ShellOpenFile("http://sourceforge.net/projects/yaprocmon")
    End Sub

    Private Sub lnkWebsite_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkWebsite.LinkClicked
        mdlFile.ShellOpenFile("http://yaprocmon.sourceforge.net/")
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        MsgBox("YAPM is up to date !", MsgBoxStyle.Information, "No new update available")
    End Sub

    Private Sub cmdDonate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDonate.Click
        MsgBox("You just gave 500$ to me...", MsgBoxStyle.Information, "Thanks you !")
    End Sub
End Class
