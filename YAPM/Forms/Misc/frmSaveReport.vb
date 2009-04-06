' =======================================================
' Yet Another Process Monitor (YAPM)
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

Public Class frmSaveReport

    Private _repType As String
    Private _path As String

    Public Property ReportType() As String
        Get
            Return _repType
        End Get
        Set(ByVal value As String)
            _repType = value
        End Set
    End Property
    Public Property ReportPath() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property


    ' Public functions to save reports
    Public Sub SaveReportLog()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s
                    Me.pgb.Maximum = frmMain.log.LineCount

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.log.Items
                            c = "Date : " & it.Text
                            c &= vbTab & "Event : " & it.SubItems(1).Text
                            c &= vbNewLine
                            stream.Write(c)
                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.log.LineCount) & " result(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim col(1) As cHTML.HtmlColumnStructure
                        col(0).sizePercent = 30
                        col(0).title = "Date"
                        col(1).sizePercent = 70
                        col(1).title = "Event"
                        Dim title As String = "Log : " & CStr(frmMain.log.LineCount) & " item(s)"
                        Dim _html As New cHTML(col, s, title)

                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.log.Items
                            Dim _lin(1) As String
                            _lin(0) = it.Text
                            _lin(1) = it.SubItems(1).Text
                            _html.AppendLine(_lin)
                            x += 1
                            UpdateProgress(x)
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("log")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportServices()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s

                    Me.pgb.Maximum = frmMain.lvServices.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim x As Integer = 0
                        For Each cm As cService In frmMain.lvServices.GetAllItems

                            Try
                                ' Try to access to the service (avoid to write lines if service
                                ' is deleted)
                                Dim suseless As String = cm.Infos.LoadOrderGroup

                                c &= "Name" & vbTab & vbTab
                                c &= cm.Infos.Name & vbNewLine
                                c &= "Common name" & vbTab & vbTab
                                c &= cm.Infos.DisplayName & vbNewLine
                                c &= "Path" & vbTab & vbTab
                                c &= cm.Infos.ImagePath & vbNewLine
                                c &= "ObjectName" & vbTab & vbTab
                                c &= cm.Infos.ObjectName & vbNewLine
                                c &= "State" & vbTab & vbTab
                                c &= cm.Infos.State.ToString & vbNewLine
                                c &= "Startup" & vbTab & vbTab
                                c &= cm.Infos.StartType.ToString & vbNewLine & vbNewLine & vbNewLine

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try

                            stream.Write(c)

                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvServices.Items.Count) & " service(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim title As String = CStr(frmMain.lvServices.Items.Count) & " service(s)"
                        Dim _html As New cHTML2(s, title, 25)

                        Dim x As Integer = 0
                        For Each cm As cService In frmMain.lvServices.GetAllItems
                            Try
                                ' Try to access to the service (avoid to write lines if service
                                ' is deleted)
                                Dim suseless As String = cm.Infos.LoadOrderGroup

                                _html.AppendTitleLine(cm.Infos.Name)
                                Dim _lin(1) As String
                                _lin(0) = "Name"
                                _lin(1) = cm.Infos.Name
                                _html.AppendLine(_lin)
                                _lin(0) = "Common name"
                                _lin(1) = cm.Infos.DisplayName
                                _html.AppendLine(_lin)
                                _lin(0) = "Path"
                                _lin(1) = cm.Infos.ImagePath
                                _html.AppendLine(_lin)
                                _lin(0) = "ObjectName"
                                _lin(1) = cm.Infos.ObjectName
                                _html.AppendLine(_lin)
                                _lin(0) = "State"
                                _lin(1) = cm.Infos.State.ToString
                                _html.AppendLine(_lin)
                                _lin(0) = "Startup"
                                _lin(1) = cm.Infos.StartType.ToString
                                _html.AppendLine(_lin)

                                x += 1
                                UpdateProgress(x)

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("services")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportWindows()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s
                    Me.pgb.Maximum = frmMain.lvWindows.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim x As Integer = 0
                        For Each cm As cWindow In frmMain.lvWindows.GetAllItems

                            Try
                                ' Try to access to the window (avoid to write lines if window
                                ' is deleted)
                                Dim suseless As String = cm.Caption

                                c &= "ParentProcess" & vbTab & vbTab & CStr(cm.ParentProcessId) & " -- " & cm.ParentProcessName & vbNewLine
                                c &= "ThreadId" & vbTab & vbTab & CStr(cm.ParentThreadId) & vbNewLine
                                c &= "Window ID" & vbTab & vbTab
                                c &= CStr(cm.Handle) & vbNewLine
                                c &= "Caption" & vbTab & vbTab
                                c &= cm.Caption & vbNewLine
                                c &= "Enabled" & vbTab & vbTab
                                c &= CStr(cm.Enabled) & vbNewLine
                                c &= "Visible" & vbTab & vbTab
                                c &= CStr(cm.Visible) & vbNewLine
                                c &= "IsTask" & vbTab & vbTab
                                c &= CStr(cm.IsTask) & vbNewLine
                                c &= "Opacity" & vbTab & vbTab
                                c &= CStr(cm.Opacity) & vbNewLine
                                c &= "Height" & vbTab & vbTab
                                c &= CStr(cm.Height) & vbNewLine
                                c &= "Left" & vbTab & vbTab
                                c &= CStr(cm.Left) & vbNewLine
                                c &= "Top" & vbTab & vbTab
                                c &= CStr(cm.Top) & vbNewLine
                                c &= "Width" & vbTab & vbTab
                                c &= CStr(cm.Width) & vbNewLine & vbNewLine & vbNewLine

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try

                            stream.Write(c)

                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvWindows.Items.Count) & " windows(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim title As String = CStr(frmMain.lvWindows.Items.Count) & " windows(s)"
                        Dim _html As New cHTML2(s, title, 25)

                        Dim x As Integer = 0
                        For Each cm As cWindow In frmMain.lvWindows.GetAllItems
                            Try
                                ' Try to access to the window (avoid to write lines if window
                                ' is deleted)
                                Dim suseless As String = cm.Caption

                                _html.AppendTitleLine("ParentProcess  " & CStr(cm.ParentProcessId) & "  --  " & cm.ParentProcessName)
                                Dim _lin(1) As String
                                _lin(0) = "ThreadID"
                                _lin(1) = CStr(cm.ParentThreadId)
                                _html.AppendLine(_lin)
                                _lin(0) = "Window ID"
                                _lin(1) = CStr(cm.Handle)
                                _html.AppendLine(_lin)
                                _lin(0) = "Caption"
                                _lin(1) = cm.Caption
                                _html.AppendLine(_lin)
                                _lin(0) = "Enabled"
                                _lin(1) = CStr(cm.Enabled)
                                _html.AppendLine(_lin)
                                _lin(0) = "Visible"
                                _lin(1) = CStr(cm.Visible)
                                _html.AppendLine(_lin)
                                _lin(0) = "IsTask"
                                _lin(1) = CStr(cm.IsTask)
                                _html.AppendLine(_lin)
                                _lin(0) = "Opacity"
                                _lin(1) = CStr(cm.Opacity)
                                _html.AppendLine(_lin)
                                _lin(0) = "Height"
                                _lin(1) = CStr(cm.Height)
                                _html.AppendLine(_lin)
                                _lin(0) = "Left"
                                _lin(1) = CStr(cm.Left)
                                _html.AppendLine(_lin)
                                _lin(0) = "Top"
                                _lin(1) = CStr(cm.Top)
                                _html.AppendLine(_lin)
                                _lin(0) = "Width"
                                _html.AppendLine(_lin)
                                _lin(1) = CStr(cm.Width)

                                x += 1
                                UpdateProgress(x)

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("windows")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportThreads()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s
                    Me.pgb.Maximum = frmMain.lvThreads.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.lvThreads.Items
                            Dim cm As cThread = CType(it.Tag, cThread)

                            Try
                                ' Try to access to the thread (avoid to write lines if thread
                                ' is deleted)
                                'TODO_
                                'Dim suseless As String = cm.PriorityString

                                'c = "ProcessId" & CStr(cm.Id) & "   --   thread : " & it.Text & vbNewLine
                                'c &= "Priority" & vbTab & vbTab
                                'c &= cm.PriorityString & vbNewLine
                                'c &= "Base priority " & vbTab & vbTab
                                'c &= CStr(cm.BasePriority) & vbNewLine
                                'c &= "State" & vbTab & vbTab
                                'c &= cm.ThreadState & vbNewLine
                                'c &= "Wait reason" & vbTab & vbTab
                                'c &= cm.WaitReason & vbNewLine
                                'c &= "Start address" & vbTab & vbTab
                                'c &= CStr(cm.StartAddress) & vbNewLine
                                'c &= "PriorityBoostEnabled" & vbTab & vbTab
                                'c &= CStr(cm.PriorityBoostEnabled) & vbNewLine
                                'c &= "Start time" & vbTab & vbTab
                                'c &= cm.StartTime.ToLongDateString & " -- " & cm.StartTime.ToLongTimeString & vbNewLine
                                'c &= "TotalProcessorTime" & vbTab & vbTab
                                'c &= cm.TotalProcessorTime.ToString & vbNewLine
                                'c &= "PrivilegedProcessorTime" & vbTab & vbTab
                                'c &= cm.PrivilegedProcessorTime.ToString & vbNewLine
                                'c &= "UserProcessorTime" & vbTab & vbTab
                                'c &= CStr(cm.UserProcessorTime.ToString) & vbNewLine
                                'c &= "ProcessorAffinity" & vbTab & vbTab
                                'c &= CStr(cm.ProcessorAffinity) & vbNewLine & vbNewLine & vbNewLine
                            Catch ex As Exception
                                'Call Me.ReportFailed(ex)
                            End Try

                            stream.Write(c)

                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvThreads.Items.Count) & " thread(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim title As String = CStr(frmMain.lvThreads.Items.Count) & " thread(s)"
                        Dim _html As New cHTML2(s, title, 25)

                        Dim x As Integer = 0
                        Dim it As ListViewItem
                        For Each it In frmMain.lvThreads.Items
                            Dim cm As cThread = CType(it.Tag, cThread)
                            Try
                                ' Try to access to the thread (avoid to write lines if thread
                                ' is deleted)
                                Dim suseless As String = cm.Infos.Priority.ToString

                                _html.AppendTitleLine("ProcessId" & CStr(cm.Infos.Id) & "   --   thread : " & it.Text)
                                Dim _lin(1) As String
                                _lin(0) = "Priority"
                                _lin(1) = cm.Infos.Priority.ToString
                                _html.AppendLine(_lin)
                                _lin(0) = "Base priority "
                                _lin(1) = cm.Infos.BasePriority.ToString
                                _html.AppendLine(_lin)
                                _lin(0) = "State"
                                _lin(1) = cm.Infos.State.ToString
                                _html.AppendLine(_lin)
                                _lin(0) = "Wait reason"
                                _lin(1) = cm.Infos.WaitReason.ToString
                                _html.AppendLine(_lin)
                                _lin(0) = "Start address"
                                _lin(1) = "0x" & cm.Infos.StartAddress.ToString("x")
                                _html.AppendLine(_lin)
                                _lin(0) = "Start time"
                                'TODO_
                                ' ADD MISSING PROPERTIES
                                '_lin(1) = cm.StartTime.ToLongDateString & " -- " & cm.StartTime.ToLongTimeString
                                '_html.AppendLine(_lin)
                                '_lin(0) = "TotalProcessorTime"
                                '_lin(1) = cm.TotalProcessorTime.ToString
                                '_html.AppendLine(_lin)
                                '_lin(0) = "PrivilegedProcessorTime"
                                '_lin(1) = cm.PrivilegedProcessorTime.ToString
                                '_html.AppendLine(_lin)
                                '_lin(0) = "UserProcessorTime"
                                '_lin(1) = CStr(cm.UserProcessorTime.ToString)
                                '_html.AppendLine(_lin)
                                _lin(0) = "ProcessorAffinity"
                                _lin(1) = CStr(cm.Infos.AffinityMask)
                                _html.AppendLine(_lin)

                                x += 1
                                UpdateProgress(x)

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("threads")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportHandles()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s
                    Me.pgb.Maximum = frmMain.lvHandles.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim x As Integer = 0
                        Dim it As ListViewItem
                        For Each it In frmMain.lvHandles.Items
                            c = "Type : " & it.Text
                            c &= "  Process : " & it.SubItems(6).Text
                            c &= "  Name: " & it.SubItems(1).Text
                            c &= "  Handle : " & it.SubItems(5).Text
                            c &= "  HandleCount : " & it.SubItems(2).Text
                            c &= "  PointerCount : " & it.SubItems(3).Text
                            c &= "  ObjectCount : " & it.SubItems(4).Text & vbNewLine
                            stream.Write(c)
                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvHandles.Items.Count) & " handle(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim col(6) As cHTML.HtmlColumnStructure
                        col(0).sizePercent = 11
                        col(0).title = "Type"
                        col(1).sizePercent = 12
                        col(1).title = "Process"
                        col(2).sizePercent = 41
                        col(2).title = "Name"
                        col(3).sizePercent = 10
                        col(3).title = "Handle"
                        col(4).sizePercent = 10
                        col(4).title = "HandleCount"
                        col(5).sizePercent = 9
                        col(5).title = "PointerCount"
                        col(6).sizePercent = 9
                        col(6).title = "ObjectCount"

                        Dim title As String = CStr(frmMain.lvHandles.Items.Count) & " handle(s)"
                        Dim _html As New cHTML(col, s, title)

                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.lvHandles.Items
                            Dim _lin(6) As String
                            _lin(0) = it.Text
                            _lin(1) = it.SubItems(6).Text
                            _lin(2) = it.SubItems(1).Text
                            _lin(3) = it.SubItems(5).Text
                            _lin(4) = it.SubItems(2).Text
                            _lin(5) = it.SubItems(3).Text
                            _lin(6) = it.SubItems(4).Text
                            _html.AppendLine(_lin)
                            x += 1
                            UpdateProgress(x)
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("handles")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportModules()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s
                    Me.pgb.Maximum = frmMain.lvModules.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.lvModules.Items
                            Dim cm As cModule = CType(it.Tag, cModule)
                            c = "Module : " & it.Text & "  --  " & cm.Infos.FileInfo.FileName & vbNewLine

                            c &= "Process owner" & vbTab & vbTab
                            c &= CStr(cm.Infos.ProcessId) & " -- " & cProcess.GetProcessName(cm.Infos.ProcessId) & vbNewLine
                            c &= "Version" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.FileVersion & vbNewLine
                            c &= "Comments" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.Comments & vbNewLine
                            c &= "CompanyName" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.CompanyName & vbNewLine
                            c &= "LegalCopyright" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.LegalCopyright & vbNewLine
                            c &= "ProductName" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.ProductName & vbNewLine
                            c &= "Language" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.Language & vbNewLine
                            c &= "InternalName" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.InternalName & vbNewLine
                            c &= "LegalTrademarks" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.LegalTrademarks & vbNewLine
                            c &= "OriginalFilename" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.OriginalFilename & vbNewLine
                            c &= "FileBuildPart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.FileBuildPart) & vbNewLine
                            c &= "FileDescription" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.FileDescription & vbNewLine
                            c &= "FileMajorPart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.FileMajorPart) & vbNewLine
                            c &= "FileMinorPart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.FileMinorPart) & vbNewLine
                            c &= "FilePrivatePart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.FilePrivatePart) & vbNewLine
                            c &= "IsDebug" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.IsDebug) & vbNewLine
                            c &= "IsPatched" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.IsPatched) & vbNewLine
                            c &= "IsPreRelease" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.IsPreRelease) & vbNewLine
                            c &= "IsPrivateBuild" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.IsPrivateBuild) & vbNewLine
                            c &= "IsSpecialBuild" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.IsSpecialBuild) & vbNewLine
                            c &= "PrivateBuild" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.PrivateBuild & vbNewLine
                            c &= "ProductBuildPart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.ProductBuildPart) & vbNewLine
                            c &= "ProductMajorPart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.ProductMajorPart) & vbNewLine
                            c &= "ProductMinorPart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.ProductMinorPart) & vbNewLine
                            c &= "ProductPrivatePart" & vbTab & vbTab
                            c &= CStr(cm.Infos.FileInfo.ProductPrivatePart) & vbNewLine
                            c &= "ProductVersion" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.ProductVersion & vbNewLine
                            c &= "SpecialBuild" & vbTab & vbTab
                            c &= cm.Infos.FileInfo.SpecialBuild & vbNewLine & vbNewLine & vbNewLine

                            stream.Write(c)
                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvModules.Items.Count) & " modules(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim title As String = CStr(frmMain.lvModules.Items.Count) & " modules(s)"
                        Dim _html As New cHTML2(s, title, 25)

                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.lvModules.Items
                            Dim cm As cModule = CType(it.Tag, cModule)
                            _html.AppendTitleLine("Module : " & it.Text & "  --  " & cm.Infos.FileInfo.FileName)
                            Dim _lin(1) As String
                            _lin(0) = "Process owner"
                            _lin(1) = CStr(cm.Infos.ProcessId) & " -- " & cProcess.GetProcessName(cm.Infos.ProcessId)
                            _html.AppendLine(_lin)
                            _lin(0) = "Version"
                            _lin(1) = cm.Infos.FileInfo.FileVersion
                            _html.AppendLine(_lin)
                            _lin(0) = "Comments"
                            _lin(1) = cm.Infos.FileInfo.Comments
                            _html.AppendLine(_lin)
                            _lin(0) = "CompanyName"
                            _lin(1) = cm.Infos.FileInfo.CompanyName
                            _html.AppendLine(_lin)
                            _lin(0) = "LegalCopyright"
                            _lin(1) = cm.Infos.FileInfo.LegalCopyright
                            _html.AppendLine(_lin)
                            _lin(0) = "ProductName"
                            _lin(1) = cm.Infos.FileInfo.ProductName
                            _html.AppendLine(_lin)
                            _lin(0) = "Language"
                            _lin(1) = cm.Infos.FileInfo.Language
                            _html.AppendLine(_lin)
                            _lin(0) = "InternalName"
                            _lin(1) = cm.Infos.FileInfo.InternalName
                            _html.AppendLine(_lin)
                            _lin(0) = "LegalTrademarks"
                            _lin(1) = cm.Infos.FileInfo.LegalTrademarks
                            _html.AppendLine(_lin)
                            _lin(0) = "OriginalFilename"
                            _lin(1) = cm.Infos.FileInfo.OriginalFilename
                            _html.AppendLine(_lin)
                            _lin(0) = "FileBuildPart"
                            _lin(1) = CStr(cm.Infos.FileInfo.FileBuildPart)
                            _html.AppendLine(_lin)
                            _lin(0) = "FileDescription"
                            _lin(1) = cm.Infos.FileInfo.FileDescription
                            _html.AppendLine(_lin)
                            _lin(0) = "FileMajorPart"
                            _lin(1) = CStr(cm.Infos.FileInfo.FileMajorPart)
                            _html.AppendLine(_lin)
                            _lin(0) = "FileMinorPart"
                            _lin(1) = CStr(cm.Infos.FileInfo.FileMinorPart)
                            _html.AppendLine(_lin)
                            _lin(0) = "FilePrivatePart"
                            _lin(1) = CStr(cm.Infos.FileInfo.FilePrivatePart)
                            _html.AppendLine(_lin)
                            _lin(0) = "IsDebug"
                            _lin(1) = CStr(cm.Infos.FileInfo.IsDebug)
                            _html.AppendLine(_lin)
                            _lin(0) = "IsPatched"
                            _lin(1) = CStr(cm.Infos.FileInfo.IsPatched)
                            _html.AppendLine(_lin)
                            _lin(0) = "IsPreRelease"
                            _lin(1) = CStr(cm.Infos.FileInfo.IsPreRelease)
                            _html.AppendLine(_lin)
                            _lin(0) = "IsPrivateBuild"
                            _lin(1) = CStr(cm.Infos.FileInfo.IsPrivateBuild)
                            _html.AppendLine(_lin)
                            _lin(0) = "IsSpecialBuild"
                            _lin(1) = CStr(cm.Infos.FileInfo.IsSpecialBuild)
                            _html.AppendLine(_lin)
                            _lin(0) = "PrivateBuild"
                            _lin(1) = cm.Infos.FileInfo.PrivateBuild
                            _html.AppendLine(_lin)
                            _lin(0) = "ProductBuildPart"
                            _lin(1) = CStr(cm.Infos.FileInfo.ProductBuildPart)
                            _html.AppendLine(_lin)
                            _lin(0) = "ProductMajorPart"
                            _lin(1) = CStr(cm.Infos.FileInfo.ProductMajorPart)
                            _html.AppendLine(_lin)
                            _lin(0) = "ProductMinorPart"
                            _lin(1) = CStr(cm.Infos.FileInfo.ProductMinorPart)
                            _html.AppendLine(_lin)
                            _lin(0) = "ProductPrivatePart"
                            _lin(1) = CStr(cm.Infos.FileInfo.ProductPrivatePart)
                            _html.AppendLine(_lin)
                            _lin(0) = "ProductVersion"
                            _lin(1) = cm.Infos.FileInfo.ProductVersion
                            _html.AppendLine(_lin)
                            _lin(0) = "SpecialBuild"
                            _lin(1) = cm.Infos.FileInfo.SpecialBuild
                            _html.AppendLine(_lin)

                            x += 1
                            UpdateProgress(x)
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("modules")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportSearch()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s
                    Me.pgb.Maximum = frmMain.lvSearchResults.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.lvSearchResults.Items
                            c = "Type : " & it.Text
                            c &= "  Result : " & it.SubItems(1).Text
                            c &= "  Field : " & it.SubItems(2).Text & vbNewLine
                            stream.Write(c)
                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvSearchResults.Items.Count) & " result(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim col(2) As cHTML.HtmlColumnStructure
                        col(0).sizePercent = 22
                        col(0).title = "Type"
                        col(1).sizePercent = 50
                        col(1).title = "Result"
                        col(2).sizePercent = 28
                        col(2).title = "Field"
                        Dim title As String = "Search result for '" & frmMain.txtSearchString.TextBoxText & "' -- " & CStr(frmMain.lvSearchResults.Items.Count) & " result(s)"
                        Dim _html As New cHTML(col, s, title)

                        Dim it As ListViewItem
                        Dim x As Integer = 0
                        For Each it In frmMain.lvSearchResults.Items
                            Dim _lin(2) As String
                            _lin(0) = it.Text
                            _lin(1) = it.SubItems(1).Text
                            _lin(2) = it.SubItems(2).Text
                            _html.AppendLine(_lin)
                            x += 1
                            UpdateProgress(x)
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("search")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    Public Sub SaveReportMonitoring()

        ReportSaved("monitoring")
    End Sub

    ' Report has been succesfully saved
    Private Sub ReportSaved(ByVal type As String)
        '_repType = type
        Me.lblProgress.Text = "Saving done."
        Me.pgb.Value = Me.pgb.Maximum
        Me.cmdOK.Enabled = True
        Me.cmdOpenReport.Enabled = True
        Me.cmdGO.Enabled = False
        Me.cmdGO.Enabled = True
        MsgBox("Save is ok !", MsgBoxStyle.Information, "Error")
    End Sub

    ' Report saving failed
    Private Sub ReportFailed(ByVal ex As Exception)
        Me.pgb.Value = Me.pgb.Maximum
        Me.cmdOK.Enabled = True
        Me.cmdGO.Enabled = False
        Me.cmdOK.Text = "Quit"
        Me.lblProgress.Text = "Saving failed"
        Me.cmdOpenReport.Enabled = False
        Me.cmdGO.Enabled = True
        MsgBox("Error while saving report : " & ex.Message, MsgBoxStyle.Critical, "Error")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub cmdOpenReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenReport.Click
        Call cFile.ShellOpenFile(Me._path, Me.Handle)
    End Sub

    Private Sub frmSaveReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblProgress.Text = "Waiting for save..."
        With Me.pgb
            .Maximum = 1
            .Minimum = 0
            .Value = 0
        End With
    End Sub

    Private Sub UpdateProgress(ByVal value As Integer)
        Me.pgb.Value = value
        Me.lblProgress.Text = "Computing item " & CStr(value) & "/" & CStr(Me.pgb.Maximum)
        My.Application.DoEvents()
    End Sub

    Private Sub cmdGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGO.Click
        Me.cmdGO.Enabled = False
        Select Case Me.ReportType
            Case "services"
                Call Me.SaveReportServices()
            Case "windows"
                Call Me.SaveReportWindows()
            Case "modules"
                Call Me.SaveReportModules()
            Case "threads"
                Call Me.SaveReportThreads()
            Case "handles"
                Call Me.SaveReportHandles()
            Case "monitoring"
                Call Me.SaveReportMonitoring()
            Case "processes"
                Call Me.SaveReportProcesses()
            Case "search"
                Call Me.SaveReportSearch()
            Case "log"
                Call Me.SaveReportLog()
        End Select
    End Sub
    Public Sub SaveReportProcesses()
        frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt"
        frmMain.saveDial.Title = "Save report"
        Try
            If frmMain.saveDial.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As String = frmMain.saveDial.FileName
                If Len(s) > 0 Then
                    ' Create file report
                    Dim c As String = vbNullString

                    Me.ReportPath = s

                    Me.pgb.Maximum = frmMain.lvServices.Items.Count

                    If s.Substring(s.Length - 3, 3).ToLower = "txt" Then
                        Dim stream As New System.IO.StreamWriter(s, False)
                        ' txt
                        Dim x As Integer = 0
                        For Each cm As cService In frmMain.lvServices.GetAllItems

                            Try
                                ' Try to access to the service (avoid to write lines if service
                                ' is deleted)
                                Dim suseless As String = cm.Infos.LoadOrderGroup

                                c &= "Name" & vbTab & vbTab
                                c &= cm.Infos.Name & vbNewLine
                                c &= "Common name" & vbTab & vbTab
                                c &= cm.Infos.DisplayName & vbNewLine
                                c &= "Path" & vbTab & vbTab
                                c &= cm.Infos.ImagePath & vbNewLine
                                c &= "ObjectName" & vbTab & vbTab
                                c &= cm.Infos.ObjectName & vbNewLine
                                c &= "State" & vbTab & vbTab
                                c &= cm.Infos.State.ToString & vbNewLine
                                c &= "Startup" & vbTab & vbTab
                                c &= cm.Infos.StartType.ToString & vbNewLine & vbNewLine & vbNewLine

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try

                            stream.Write(c)

                            x += 1
                            UpdateProgress(x)
                        Next
                        c = CStr(frmMain.lvServices.Items.Count) & " service(s)"
                        stream.Write(c)
                        stream.Close()
                    Else
                        ' HTML
                        Dim title As String = CStr(frmMain.lvServices.Items.Count) & " service(s)"
                        Dim _html As New cHTML2(s, title, 25)

                        Dim x As Integer = 0
                        For Each cm As cService In frmMain.lvServices.GetAllItems
                            Try
                                ' Try to access to the service (avoid to write lines if service
                                ' is deleted)
                                Dim suseless As String = cm.Infos.LoadOrderGroup

                                _html.AppendTitleLine(cm.Infos.Name)
                                Dim _lin(1) As String
                                _lin(0) = "Name"
                                _lin(1) = cm.Infos.Name
                                _html.AppendLine(_lin)
                                _lin(0) = "Common name"
                                _lin(1) = cm.Infos.DisplayName
                                _html.AppendLine(_lin)
                                _lin(0) = "Path"
                                _lin(1) = cm.Infos.ImagePath
                                _html.AppendLine(_lin)
                                _lin(0) = "ObjectName"
                                _lin(1) = cm.Infos.ObjectName
                                _html.AppendLine(_lin)
                                _lin(0) = "State"
                                _lin(1) = cm.Infos.State.ToString
                                _html.AppendLine(_lin)
                                _lin(0) = "Startup"
                                _lin(1) = cm.Infos.StartType.ToString
                                _html.AppendLine(_lin)

                                x += 1
                                UpdateProgress(x)

                            Catch ex As Exception
                                '  Call Me.ReportFailed(ex)
                            End Try
                        Next

                        _html.ExportHTML()
                    End If

                    ReportSaved("processes")
                End If
            End If
        Catch ex As Exception
            Call Me.ReportFailed(ex)
        End Try
        Me.cmdGO.Enabled = True
    End Sub
    
End Class