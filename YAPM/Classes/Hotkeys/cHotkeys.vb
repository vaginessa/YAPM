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

Public Class cHotkeys

    ' ========================================
    ' API declarations
    ' ========================================

    Private Const vbKeyShift As Integer = 16
    Private Const vbKeyControl As Integer = 17
    Private Const vbKeyAlt As Integer = 18
    Private Const vbShiftMask As Integer = vbKeyShift
    Private Const vbCtrlMask As Integer = vbKeyControl
    Private Const vbAltMask As Integer = vbKeyAlt


    ' ========================================
    ' Private attributes
    ' ========================================
    Private hKeyHook As Integer
    Private boolStopHooking As Boolean              ' Private !
    Private _col As New Collection

    ' Delegate function (function which replace the 'normal' one)
    Private myCallbackDelegate As HookProc = Nothing

    Private Delegate Function HookProc(ByVal code As Integer, ByVal wParam As Integer, _
                        ByRef lParam As API.KBDLLHOOKSTRUCT) As Integer

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowsHookEx(ByVal hook As API.HookType, ByVal callback As HookProc, ByVal hMod As Integer, ByVal dwThreadId As UInteger) As IntPtr
    End Function

    ' ========================================
    ' Public properties
    ' ========================================
    Public ReadOnly Property HotKeysCollection() As Collection
        Get
            Return _col
        End Get
    End Property
    Public ReadOnly Property ActionsAvailable() As String()
        Get
            Dim s() As String
            ReDim s(1)
            s(0) = "Kill foreground application"
            s(1) = "Exit YAPM"
            Return s
        End Get
    End Property

    ' ========================================
    ' Public functions
    ' ========================================

    ' Add a key to collection
    Public Function AddHotkey(ByVal hotkey As cShortcut) As Boolean
        Dim sKey As String = "|" & CStr(CInt(hotkey.Key1)) & "|" & CStr(CInt(hotkey.Key2)) & "|" & CStr(CInt(hotkey.Key3))
        Try
            _col.Add(Key:=sKey, Item:=hotkey)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Remove key from collection
    Public Function RemoveHotKey(ByVal hotkey As cShortcut) As Boolean
        Dim sKey As String = "|" & CStr(CInt(hotkey.Key1)) & "|" & CStr(CInt(hotkey.Key2)) & "|" & CStr(CInt(hotkey.Key3))
        Try
            _col.Remove(sKey)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function RemoveHotKey(ByVal hotkey As String) As Boolean
        Try
            _col.Remove(hotkey)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub New()
        Call AttachKeyboardHook()
    End Sub
    Protected Overrides Sub Finalize()
        Call DetachKeyboardHook()
    End Sub


    ' ========================================
    ' Private functions
    ' ========================================

    ' ========================================
    ' Start hooking of keyboard
    ' ========================================
    Private Sub AttachKeyboardHook()
        If hKeyHook = 0 Then

            ' Initialize our delegate
            Me.myCallbackDelegate = New HookProc(AddressOf Me.KeyboardFilter)

            hKeyHook = CInt(SetWindowsHookEx(API.HookType.WH_KEYBOARD_LL, _
                        Me.myCallbackDelegate, 0, 0)) ' 0 -> all threads
            GC.KeepAlive(Me.myCallbackDelegate)
        End If

    End Sub

    ' ========================================
    ' Stop hooking of keyboard
    ' ========================================
    Private Sub DetachKeyboardHook()

        If (hKeyHook <> 0) Then
            Call API.UnhookWindowsHookEx(hKeyHook)
            hKeyHook = 0
        End If

    End Sub


    ' ========================================
    ' This function is called each time a key is pressed
    ' ========================================
    Private Function KeyboardFilter(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As API.KBDLLHOOKSTRUCT) As Integer
        Dim bAlt As Boolean
        Dim bCtrl As Boolean
        Dim bShift As Boolean
        Dim cSs As Object


        If nCode = API.HC_ACTION And Not boolStopHooking Then

            bShift = (API.GetAsyncKeyState(vbKeyShift) <> 0)
            bAlt = (API.GetAsyncKeyState(vbKeyAlt) <> 0)
            bCtrl = (API.GetAsyncKeyState(vbKeyControl) <> 0)

            ' Check for each of our cShortCut if the shortcut is activated
            For Each cSs In _col

                Dim cs As cShortcut = CType(cSs, cShortcut)

                If cs.Enabled Then

                    If (cs.Key1 = cShortcut.ShorcutKeys.VK_NO_BUTTON) Or (cs.Key1 = vbShiftMask And bShift) Or (cs.Key1 = vbAltMask And bAlt) Or _
                        (cs.Key1 = vbCtrlMask And bCtrl) Then

                        ' Then the first of the 3 keys is pressed
                        ' Check the second one
                        If (cs.Key2 = cShortcut.ShorcutKeys.VK_NO_BUTTON) Or (cs.Key2 = vbShiftMask And bShift) Or (cs.Key2 = vbAltMask And bAlt) Or _
                            (cs.Key2 = vbCtrlMask And bCtrl) Then

                            ' The the second of the 3 keys is pressed
                            ' Check this last one
                            If (lParam.vkCode = cs.Key3) Then

                                ' The third of the 3 keys is pressed
                                boolStopHooking = True                      ' We stop hooking shortcuts

                                ' Process emergency action
                                cs.RaiseAction()

                                boolStopHooking = False                     ' Now we can hook another shortcuts
                                Exit For

                            End If

                        End If

                    End If

                End If

            Next cSs

        End If

        ' Next hook
        KeyboardFilter = API.CallNextHookEx(hKeyHook, nCode, wParam, lParam)

    End Function
End Class