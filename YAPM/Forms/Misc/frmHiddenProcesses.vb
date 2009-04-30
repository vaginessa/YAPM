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

Imports System.Windows.Forms

Public Class frmHiddenProcesses

    Private Const NO_INFO_RETRIEVED As String = "N/A"

    Private Sub frmHiddenProcesses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call API.SetWindowTheme(Me.lvProcess.Handle, "explorer", Nothing)
        Dim theConnection As New cConnection
        theConnection.ConnectionType = cConnection.TypeOfConnection.LocalConnection

        Me.lvProcess.ClearItems()
        Me.lvProcess.ConnectionObj = theConnection

        Try
            theConnection.Connect()
        Catch ex As Exception
            '
        End Try
        Me.TimerProcess.Enabled = True

    End Sub

    Private Sub TimerProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerProcess.Tick
        Me.lvProcess.UpdateItems()
        lblTotal.Text = Me.lvProcess.Items.Count.ToString & " processes"
        Dim _hidd As Integer = 0
        For Each p As cProcess In Me.lvProcess.GetAllItems
            If p.Infos.IsHidden Then
                _hidd += 1
            End If
        Next
        lblHidden.Text = _hidd.ToString & " hidden processes"
        lblVisible.Text = (Me.lvProcess.Items.Count - _hidd).ToString & " visible processes"
    End Sub

    Private Sub handleMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles handleMethod.Click
        handleMethod.Checked = True
        bruteforceMethod.Checked = False
        Me.lvProcess.ClearItems()
        Me.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.HandleMethod
    End Sub

    Private Sub bruteforceMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bruteforceMethod.Click
        handleMethod.Checked = False
        bruteforceMethod.Checked = True
        Me.lvProcess.ClearItems()
        Me.lvProcess.EnumMethod = asyncCallbackProcEnumerate.ProcessEnumMethode.BruteForce
    End Sub

    Private Sub lvProcess_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvProcess.MouseDoubleClick
        For Each it As cProcess In Me.lvProcess.GetSelectedItems
            Dim frm As New frmProcessInfo
            frm.SetProcess(it)
            frm.Show()
        Next
    End Sub

    Private Sub FileDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileDetailsToolStripMenuItem1.Click
        If Me.lvProcess.SelectedItems.Count > 0 Then
            Dim cp As cProcess = Me.lvProcess.GetSelectedItem
            Dim s As String = cp.Infos.Path
            If IO.File.Exists(s) Then
                frmMain.DisplayDetailsFile(s)
            End If
        End If
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        For Each cp As cProcess In Me.lvProcess.GetSelectedItems
            If IO.File.Exists(cp.Infos.Path) Then
                cFile.ShowFileProperty(cp.Infos.Path, Me.Handle)
            End If
        Next
    End Sub

    Private Sub OpenFirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFirectoryToolStripMenuItem.Click
        For Each cp As cProcess In Me.lvProcess.GetSelectedItems
            If cp.Infos.Path <> NO_INFO_RETRIEVED Then
                cFile.OpenDirectory(cp.Infos.Path)
            End If
        Next
    End Sub

    Private Sub GoogleSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoogleSearchToolStripMenuItem.Click
        For Each cp As cProcess In Me.lvProcess.GetSelectedItems
            My.Application.DoEvents()
            Call SearchInternet(cp.Infos.Name, Me.Handle)
        Next
    End Sub
End Class
