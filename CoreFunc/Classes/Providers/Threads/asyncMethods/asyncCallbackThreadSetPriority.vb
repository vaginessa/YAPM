﻿Option Strict On

Imports CoreFunc.cProcessConnection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Management

Public Class asyncCallbackThreadSetPriority

    Private _id As Integer
    Private _level As System.Diagnostics.ThreadPriorityLevel
    Private _connection As cThreadConnection

    Public Event HasSetPriority(ByVal Success As Boolean, ByVal msg As String)

    Public Sub New(ByVal id As Integer, ByVal level As System.Diagnostics.ThreadPriorityLevel, ByRef procConnection As cThreadConnection)
        _id = id
        _level = level
        _connection = procConnection
    End Sub

    Public Sub Process()
        Select Case _connection.ConnectionObj.ConnectionType
            Case cConnection.TypeOfConnection.RemoteConnectionViaSocket

            Case cConnection.TypeOfConnection.RemoteConnectionViaWMI
               
            Case Else
                ' Local
                Dim hProc As Integer
                Dim r As UInteger = -1
                hProc = API.OpenThread(API.THREAD_RIGHTS.THREAD_SET_INFORMATION, 0, _id)
                If hProc > 0 Then
                    r = API.SetThreadPriority(New IntPtr(hProc), _level)
                    API.CloseHandle(hProc)
                    RaiseEvent HasSetPriority(r <> 0, API.GetError)
                Else
                    RaiseEvent HasSetPriority(False, API.GetError)
                End If
        End Select
    End Sub

End Class