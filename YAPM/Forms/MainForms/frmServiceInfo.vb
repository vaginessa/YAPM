﻿' =======================================================
' Yet Another (remote) Process Monitor (YAPM)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yaprocmon/
' =======================================================


' YAPM is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 3 of the License, or
' (at your option) any later version.
'
' YAPM is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with YAPM; if not, see http://www.gnu.org/licenses/.


Option Strict On

Imports System.Runtime.InteropServices

Public Class frmServiceInfo

    Private WithEvents curServ As cService
    Private Const NO_INFO_RETRIEVED As String = "N/A"
    Private m_SortingColumn As ColumnHeader
    Private WithEvents _AsyncDownload As cAsyncProcInfoDownload
    Private _asyncDlThread As Threading.Thread

    Private WithEvents theConnection As cConnection
    Private _local As Boolean = True
    Private _notWMI As Boolean
    Private __con As Management.ConnectionOptions


    ' Refresh current tab
    Private Sub refreshServiceTab()

        If curServ Is Nothing Then Exit Sub

        Select Case Me.tabProcess.SelectedTab.Text

            Case "General - 1"
                If curServ.Infos.FileInfo IsNot Nothing Then
                    Me.txtImageVersion.Text = curServ.Infos.FileInfo.FileVersion
                    Me.lblCopyright.Text = curServ.Infos.FileInfo.LegalCopyright
                    Me.lblDescription.Text = curServ.Infos.FileInfo.FileDescription
                Else
                    Me.txtImageVersion.Text = NO_INFO_RETRIEVED
                    Me.lblCopyright.Text = NO_INFO_RETRIEVED
                    Me.lblDescription.Text = NO_INFO_RETRIEVED
                End If
                Me.txtName.Text = curServ.Infos.Name
                If Me.curServ.Infos.ProcessId > 0 Then
                    Me.txtProcess.Text = curServ.Infos.ProcessName & " -- " & curServ.Infos.ProcessId
                Else
                    Me.txtProcess.Text = "Not started"
                End If
                Me.txtServicePath.Text = curServ.GetInformation("ImagePath")
                Me.txtStartType.Text = curServ.Infos.StartType.ToString
                Me.txtState.Text = curServ.Infos.State.ToString
                Me.txtType.Text = curServ.Infos.ServiceType.ToString
                Me.cbStart.Text = Me.txtStartType.Text
                Me.cmdGoProcess.Enabled = (Me.curServ.Infos.ProcessId > 0)
                Me.cmdPause.Enabled = ((Me.curServ.Infos.AcceptedControl And API.SERVICE_ACCEPT.PauseContinue) = API.SERVICE_ACCEPT.PauseContinue)
                Me.cmdShutdown.Enabled = ((Me.curServ.Infos.AcceptedControl And API.SERVICE_ACCEPT.Shutdown) = API.SERVICE_ACCEPT.Shutdown)
                Me.cmdStop.Enabled = ((Me.curServ.Infos.AcceptedControl And API.SERVICE_ACCEPT.Stop) = API.SERVICE_ACCEPT.Stop)
                Me.cmdStart.Enabled = (Me.curServ.Infos.State = API.SERVICE_STATE.Stopped)


            Case "General - 2"
                Me.txtCheckPoint.Text = curServ.Infos.CheckPoint.ToString
                Me.txtDiagnosticMessageFile.Text = curServ.Infos.DiagnosticMessageFile
                Me.txtErrorControl.Text = curServ.Infos.ErrorControl.ToString
                Me.txtObjectName.Text = curServ.Infos.ObjectName
                Me.txtLoadOrderGroup.Text = curServ.Infos.LoadOrderGroup
                Me.txtServiceFlags.Text = curServ.Infos.ServiceFlags.ToString
                Me.txtServiceSpecificExitCode.Text = curServ.Infos.ServiceSpecificExitCode.ToString
                Me.txtServiceStartName.Text = curServ.Infos.ServiceStartName
                Me.txtTagID.Text = curServ.Infos.TagID.ToString
                Me.txtWaitHint.Text = curServ.Infos.WaitHint.ToString
                Me.txtWin32ExitCode.Text = curServ.Infos.Win32ExitCode.ToString
                Me.rtbDescription.Text = Me.curServ.Infos.Description


            Case "Dependencies"
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

                addDependentServices(curServ, n)
                addServicesDependedOn(curServ, n3)

                If n.Nodes.Count > 0 Then
                    n.ImageKey = "ko"
                    n.SelectedImageKey = "ko"
                Else
                    n.ImageKey = "ok"
                    n.SelectedImageKey = "ok"
                End If
                If n3.Nodes.Count > 0 Then
                    n3.ImageKey = "ko"
                    n3.SelectedImageKey = "ko"
                Else
                    n3.ImageKey = "ok"
                    n3.SelectedImageKey = "ok"
                End If


            Case "Informations"

                ' Description
                Dim s As String = vbNullString
                Dim description As String = vbNullString
                Dim diagnosticsMessageFile As String = curServ.Infos.DiagnosticMessageFile
                Dim group As String = curServ.Infos.LoadOrderGroup
                Dim objectName As String = curServ.Infos.ObjectName
                Dim tag As String = vbNullString
                Dim sp As String = curServ.GetInformation("ImagePath")

                ' OK it's not the best way to retrive the description...
                ' (if @ -> extract string to retrieve description)
                Dim sTemp As String = curServ.Infos.Description
                If InStr(sTemp, "@", CompareMethod.Binary) > 0 Then
                    description = cFile.IntelligentPathRetrieving(sTemp)
                Else
                    description = sTemp
                End If
                description = Replace(curServ.Infos.Description, "\", "\\")


                s = "{\rtf1\ansi\ansicpg1252\deff0\deflang1036{\fonttbl{\f0\fswiss\fprq2\fcharset0 Tahoma;}}"
                s = s & "{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\f0\fs18   \b Service properties\b0\par"
                s = s & "\tab Name :\tab\tab\tab " & curServ.Infos.Name & "\par"
                s = s & "\tab Common name :\tab\tab " & curServ.Infos.DisplayName & "\par"
                If Len(sp) > 0 Then s = s & "\tab Path :\tab\tab\tab " & Replace(curServ.GetInformation("ImagePath"), "\", "\\") & "\par"
                If Len(description) > 0 Then s = s & "\tab Description :\tab\tab " & description & "\par"
                If Len(group) > 0 Then s = s & "\tab Group :\tab\tab\tab " & group & "\par"
                If Len(objectName) > 0 Then s = s & "\tab ObjectName :\tab\tab " & objectName & "\par"
                If Len(diagnosticsMessageFile) > 0 Then s = s & "\tab DiagnosticsMessageFile :\tab\tab " & diagnosticsMessageFile & "\par"
                s = s & "\tab State :\tab\tab\tab " & curServ.Infos.State.ToString & "\par"
                s = s & "\tab Startup :\tab\tab " & curServ.Infos.StartType.ToString & "\par"
                If curServ.Infos.ProcessId > 0 Then s = s & "\tab Owner process :\tab\tab " & curServ.Infos.ProcessId & "-- " & cProcess.GetProcessName(curServ.Infos.ProcessId) & "\par"
                s = s & "\tab Service type :\tab\tab " & curServ.Infos.ServiceType.ToString & "\par"

                s = s & "}"

                rtb.Rtf = s
        End Select
    End Sub

    ' Refresh information tab
    Private Sub refreshInfosTab()
        Try


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
    End Sub

    Private Sub frmProcessInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Some tooltips

        ' Icons
        If pctBigIcon.Image Is Nothing Then
            Try
                pctBigIcon.Image = GetIcon(Me.txtServicePath.Text, False).ToBitmap
                pctSmallIcon.Image = GetIcon(Me.txtServicePath.Text, True).ToBitmap
            Catch ex As Exception
                pctSmallIcon.Image = Me.imgProcess.Images("noicon")
                pctBigIcon.Image = Me.imgMain.Images("noicon32")
            End Try
        End If

        Call Connect()
        Call refreshServiceTab()

    End Sub

    ' Get process to monitor
    Public Sub SetService(ByRef service As cService)

        curServ = service

        Me.Text = curServ.Infos.Name

        _local = (cProcess.Connection.ConnectionObj.ConnectionType = cConnection.TypeOfConnection.LocalConnection)
        _notWMI = (cProcess.Connection.ConnectionObj.ConnectionType <> cConnection.TypeOfConnection.RemoteConnectionViaWMI)

        Me.cmdShowFileDetails.Enabled = _local
        Me.cmdShowFileProperties.Enabled = _local
        Me.cmdOpenDirectory.Enabled = _local

        ' Verify file
        If _local Then
            Try
                Dim bVer As Boolean = Security.WinTrust.WinTrust.VerifyEmbeddedSignature(Me.txtServicePath.Text)
                If bVer Then
                    gpProcGeneralFile.Text = "Image file (successfully verified)"
                Else
                    gpProcGeneralFile.Text = "Image file (not verified)"
                End If
            Catch ex As Exception
                '
            End Try
        Else
            gpProcGeneralFile.Text = "Image file (no verification was made)"
        End If
    End Sub

    ' Change caption
    Private Sub ChangeCaption()
        Me.Text = curServ.Infos.Name
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

    Private Sub cmdOpenDirectory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOpenDirectory.Click
        ' Open directory of selected service
        If Me.txtServicePath.Text <> NO_INFO_RETRIEVED Then
            cFile.OpenDirectory(Me.txtServicePath.Text)
        End If
    End Sub

    Private Sub pctBigIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctBigIcon.MouseDown
        Me.ToolStripMenuItem6.Enabled = (Me.pctBigIcon.Image IsNot Nothing)
    End Sub

    Private Sub pctSmallIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSmallIcon.MouseDown
        Me.ToolStripMenuItem7.Enabled = (Me.pctSmallIcon.Image IsNot Nothing)
    End Sub

    Private Sub tabProcess_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProcess.SelectedIndexChanged
        Call Me.refreshServiceTab()
        Call ChangeCaption()
    End Sub

    Private Sub rtb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtb.TextChanged
        Me.cmdInfosToClipB.Enabled = (Me.rtb.TextLength > 0)
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        My.Computer.Clipboard.SetImage(Me.pctBigIcon.Image)
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        My.Computer.Clipboard.SetImage(Me.pctSmallIcon.Image)
    End Sub

    Private Sub cmdGetOnlineInfos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetOnlineInfos.Click
        If _asyncDlThread IsNot Nothing Then
            ' Already trying to get infos
            Exit Sub
        End If
        _AsyncDownload = New cAsyncProcInfoDownload(curServ.Infos.Name)

        ' Start async download of infos
        _asyncDlThread = New Threading.Thread(AddressOf _AsyncDownload.BeginDownload)
        With _asyncDlThread
            .IsBackground = True
            .Priority = Threading.ThreadPriority.Lowest
            .Start()
        End With
    End Sub

    ' Here we finished to download informations from internet
    Private _asyncInfoRes As cAsyncProcInfoDownload.InternetProcessInfo
    Private _asyncDownloadDone As Boolean = False
    Private Sub _AsyncDownload_GotInformations(ByRef result As cAsyncProcInfoDownload.InternetProcessInfo) Handles _AsyncDownload.GotInformations
        _asyncInfoRes = result
        _asyncDownloadDone = True
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Call Me.tabProcess_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Call tabProcess_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    ' Connection
    Public Sub Connect()
        ' Connect providers
        'theConnection.CopyFromInstance(frmMain.theConnection)
        Try
            theConnection = frmMain.theConnection
            theConnection.Connect()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can not connect")
        End Try
    End Sub

    Private Sub theConnection_Connected() Handles theConnection.Connected
        '
    End Sub

    Private Sub theConnection_Disconnected() Handles theConnection.Disconnected
        '
    End Sub

    Private Sub cmdShowFileDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowFileDetails.Click
        Dim s As String = Me.txtServicePath.Text
        If IO.File.Exists(s) Then
            frmMain.DisplayDetailsFile(s)
        End If
    End Sub

    Private Sub cmdShowFileProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowFileProperties.Click
        ' File properties for selected process
        If IO.File.Exists(Me.txtServicePath.Text) Then
            cFile.ShowFileProperty(Me.txtServicePath.Text, Me.Handle)
        End If
    End Sub

    Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
        If frmMain.Pref.warnDangerous Then
            If MsgBox("Are you sure you want to suspend this service ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Dangerous action") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        curServ.PauseService()
    End Sub

    Private Sub cmdResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResume.Click
        curServ.ResumeService()
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        curServ.StartService()
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        If frmMain.Pref.warnDangerous Then
            If MsgBox("Are you sure you want to stop this service ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Dangerous action") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        curServ.StopService()
    End Sub

    Private Sub cmdShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShutdown.Click
        If frmMain.Pref.warnDangerous Then
            If MsgBox("Are you sure you want to shutdown this service ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Dangerous action") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        curServ.ShutDownService()
    End Sub

    Private Sub cmdSetStartType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetStartType.Click
        If frmMain.Pref.warnDangerous Then
            If MsgBox("Are you sure you want to change start type ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Dangerous action") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        Select Case cbStart.Text
            Case "BootStart"
                curServ.SetServiceStartType(API.SERVICE_START_TYPE.BootStart)
            Case "SystemStart"
                curServ.SetServiceStartType(API.SERVICE_START_TYPE.SystemStart)
            Case "AutoStart"
                curServ.SetServiceStartType(API.SERVICE_START_TYPE.AutoStart)
            Case "DemandStart"
                curServ.SetServiceStartType(API.SERVICE_START_TYPE.DemandStart)
            Case "StartDisabled"
                curServ.SetServiceStartType(API.SERVICE_START_TYPE.StartDisabled)
        End Select
    End Sub

    Private Sub cmdGoProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGoProcess.Click
        If cProcess._currentProcesses.ContainsKey(curServ.Infos.ProcessId.ToString) Then
            Dim frm As New frmProcessInfo
            frm.SetProcess(cProcess._currentProcesses(curServ.Infos.ProcessId.ToString))
            frm.Show()
        End If
    End Sub

    Private Sub txtServicePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServicePath.TextChanged
        Dim s As String = Me.txtServicePath.Text
        Dim b As Boolean = False
        b = (Me._local AndAlso System.IO.File.Exists(s))
        Me.cmdShowFileDetails.Enabled = b
        Me.cmdShowFileProperties.Enabled = b
        Me.cmdOpenDirectory.Enabled = b
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        ' Refresh informations about process
        If Not (Me.tabProcess.SelectedTab.Text = "Informations" Or _
                Me.tabProcess.SelectedTab.Text = "Dependencies") Then _
            Call Me.refreshServiceTab()

        ' Display caption
        Call ChangeCaption()

        ' If online infos received, display it
        If _asyncDownloadDone Then
            Me.lblSecurityRisk.Text = "Risk : " & _asyncInfoRes._Risk.ToString
            Me.rtbOnlineInfos.Text = _asyncInfoRes._Description
            _asyncDlThread.Abort()
            _asyncInfoRes = Nothing
            _asyncDlThread = Nothing
            _asyncDownloadDone = False
        End If
    End Sub

#Region "Powerfull recursives methods for treeviews"
    ' Recursive method to add items in our treeview
    Private Sub addDependentServices(ByRef o As cService, ByVal n As TreeNode)
        For Each o1 As cService In cService.GetServiceWhichDependFrom(o.Infos.Name).Values
            Dim n2 As New TreeNode
            With n2
                .ImageKey = "service"
                .SelectedImageKey = "service"
                .Text = o1.Infos.Name
            End With
            n.Nodes.Add(n2)
            addDependentServices(o1, n2)
        Next o1
    End Sub
    ' Recursive method to add items in our treeview
    Private Sub addServicesDependedOn(ByRef o As cService, ByVal n As TreeNode)
        For Each o1 As cService In cService.GetDependencies(o.Infos.Name).Values
            Dim n2 As New TreeNode
            With n2
                .ImageKey = "service"
                .SelectedImageKey = "service"
                .Text = o1.Infos.Name
            End With
            n.Nodes.Add(n2)
            addServicesDependedOn(o1, n2)
        Next o1
    End Sub
#End Region

    Private Sub cmdServDet1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServDet1.Click
        If Me.tv2.SelectedNode IsNot Nothing Then
            Dim s As String = Me.tv2.SelectedNode.Text
            Dim it As cService = cService.GetServiceByName(s)
            If it IsNot Nothing Then
                Dim frm As New frmServiceInfo
                frm.SetService(it)
                frm.Show()
            End If
        End If
    End Sub

    Private Sub cmdServDet2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServDet2.Click
        If Me.tv.SelectedNode IsNot Nothing Then
            Dim s As String = Me.tv.SelectedNode.Text
            Dim it As cService = cService.GetServiceByName(s)
            If it IsNot Nothing Then
                Dim frm As New frmServiceInfo
                frm.SetService(it)
                frm.Show()
            End If
        End If
    End Sub

End Class