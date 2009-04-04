﻿Option Strict On

Imports CoreFunc.cProcessConnection
Imports System.Runtime.InteropServices
Imports System.Text

Public Class asyncCallbackThreadKill

    Private _id As Integer
    Private _connection As cThreadConnection

    Public Event HasKilled(ByVal Success As Boolean, ByVal id As Integer, ByVal msg As String)

    Public Sub New(ByVal id As Integer, ByRef procConnection As cThreadConnection)
        _id = id
        _connection = procConnection
    End Sub

    Public Sub Process()
        Select Case _connection.ConnectionObj.ConnectionType
            Case cConnection.TypeOfConnection.RemoteConnectionViaSocket

            Case cConnection.TypeOfConnection.RemoteConnectionViaWMI

            Case Else
                ' Local
                Dim hProc As Integer
                Dim ret As UInteger = -1
                hProc = API.OpenThread(API.THREAD_RIGHTS.THREAD_TERMINATE, 0, _id)
                If hProc > 0 Then
                    ret = API.TerminateThread(New IntPtr(hProc), 0)
                    API.CloseHandle(hProc)
                    RaiseEvent HasKilled(ret <> 0, 0, API.GetError)
                Else
                    RaiseEvent HasKilled(False, _id, API.GetError)
                End If
        End Select
    End Sub

End Class