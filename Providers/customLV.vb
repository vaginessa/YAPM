﻿' =======================================================
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

Imports System.Runtime.InteropServices

Public MustInherit Class customLV
    Inherits DoubleBufferedLV

    Friend Declare Function GetTickCount Lib "kernel32" () As Integer


    ' ========================================
    ' Friend
    ' ========================================

    Friend _firstItemUpdate As Boolean = True
    Friend _columnsName() As String

    Friend _IMG As ImageList
    Friend m_SortingColumn As ColumnHeader

    Friend _foreColor As Color = Color.FromArgb(30, 30, 30)

    Public Shared NEW_ITEM_COLOR As Color = Color.FromArgb(128, 255, 0)
    Public Shared DELETED_ITEM_COLOR As Color = Color.FromArgb(255, 64, 48)


    Private _catchErrors As Boolean = False


    ' ========================================
    ' Public
    ' ========================================

    ' Catch or not errors
    Public Property CatchErrors() As Boolean
        Get
            Return _catchErrors
        End Get
        Set(ByVal value As Boolean)
            _catchErrors = value
        End Set
    End Property

    ' Call this to update items in listview
    Public Overridable Sub UpdateItems()
        ' It's overriden, nothing here
    End Sub

    ' Update the items and display an error
    Public Overridable Sub UpdateTheItems()
        If _catchErrors Then
            Try
                Call UpdateItems()
            Catch ex As Exception
                If InStr(ex.Message, "0x800706BA", CompareMethod.Binary) > 0 Then
                    MsgBox("RPC server is not available. Make sure that WMI is installed, that 'remote procedure call (RPC)' service is started and that no firewall restrict access to RPC service.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Cannot retrieve information")
                ElseIf InStr(ex.Message, "0x80070005", CompareMethod.Binary) > 0 Then
                    MsgBox("Access is denied. Make sure that you have the rights to access to the remote computer, and that the passwork and login you entered are correct.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Cannot retrieve information")
                Else
                    MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Cannot retrieve information")
                End If
            End Try
        Else
            Call UpdateItems()
        End If
    End Sub

    ' Choose column
    Public Sub ChooseColumns()

        Dim frm As New frmChooseColumns
        frm.ConcernedListView = Me
        frm.ShowDialog()

        ' Recreate subitem buffer and get columns name again
        Call CreateSubItemsBuffer()

        If Me.Items.Count = 0 Then
            Exit Sub
        End If

        ' We have to set name to all items again
        For Each it As ListViewItem In Me.Items
            it.Name = it.Tag.ToString
        Next

        ' Refresh items
        _firstItemUpdate = True
        Me.BeginUpdate()
        Call Me.UpdateItems()
        Call Me.UpdateItems()
        Me.EndUpdate()
    End Sub



    ' ========================================
    ' Private
    ' ========================================

    ' Add an item (specific to type of list)
    Friend Overridable Function AddItemWithStyle(ByVal key As String) As ListViewItem
        Return Nothing
    End Function

    ' Create some subitems
    Friend Sub CreateSubItemsBuffer()

        ' Get column names
        Dim _size As Integer = Me.Columns.Count - 1
        ReDim _columnsName(_size)
        For x As Integer = 0 To _size
            _columnsName(x) = Me.Columns.Item(x).Text.Replace("< ", "").Replace("> ", "")
        Next

    End Sub

End Class