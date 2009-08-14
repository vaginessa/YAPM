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

Imports System.Text

Public Class cWindow
    Inherits cGeneralObject

    Private _windowInfos As windowInfos
    Private Shared WithEvents _connection As cWindowConnection

    Private _oldCaption As String

#Region "Properties"

    Public Shared Property Connection() As cWindowConnection
        Get
            Return _connection
        End Get
        Set(ByVal value As cWindowConnection)
            _connection = value
        End Set
    End Property

#End Region

#Region "Constructors & destructor"

    Public Sub New(ByRef infos As windowInfos)
        _windowInfos = New windowInfos(infos)
        _connection = Connection
    End Sub

    ' This constructor should NOT be used to get informations of a window, has
    ' it creates only an instance of cWindow with 'handle' information.
    ' It is used to call instance.Close(), instance.Show().... etc., rather
    ' than call cWindow.SharedClose(hWnd), cWindow.SharedShow(hWnd)...
    Public Sub New(ByVal handle As Integer)
        _windowInfos = New windowInfos(0, 0, New IntPtr(handle), "")
    End Sub

#End Region

#Region "Normal properties"

    Public ReadOnly Property Infos() As windowInfos
        Get
            Return _windowInfos
        End Get
    End Property

#End Region

#Region "Other properties"

    Public WriteOnly Property Visible() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                Show()
            Else
                Hide()
            End If
        End Set
    End Property
    Public WriteOnly Property Opacity() As Byte
        Set(ByVal value As Byte)
            SetOpacity(value)
        End Set
    End Property
    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            SetEnabled(value)
        End Set
    End Property
    Public ReadOnly Property SmallIcon() As System.Drawing.Icon
        Get
            If _connection.ConnectionObj.ConnectionType = cConnection.TypeOfConnection.LocalConnection Then
                Dim i As IntPtr = GetWindowSmallIcon()
                If Not (i = IntPtr.Zero) Then
                    Return System.Drawing.Icon.FromHandle(i)
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property Caption() As String
        Get
            If Me.IsKilledItem = False Then
                _oldCaption = Me.Infos.Caption
                Return _oldCaption
            Else
                Return _oldCaption
            End If
        End Get
        Set(ByVal value As String)
            Call SetCaption(value)
        End Set
    End Property

#End Region

    ' Merge infos
    Public Sub Refresh()
        Call RefreshSpecialInformations()
    End Sub

#Region "Special informations (GDI, affinity)"

    ' Refresh some non fixed infos
    ' For now IT IS NOT ASYNC
    ' Because create ~50 threads-pools/sec is not really cool
    Private WithEvents asyncNonFixed As asyncCallbackWindowGetNonFixedInfos
    Private Sub RefreshSpecialInformations()
        Select Case _connection.ConnectionObj.ConnectionType
            Case cConnection.TypeOfConnection.RemoteConnectionViaSocket

            Case cConnection.TypeOfConnection.RemoteConnectionViaWMI

            Case Else
                ' Local
                If asyncNonFixed Is Nothing Then
                    asyncNonFixed = New asyncCallbackWindowGetNonFixedInfos(Me.Infos.Handle, _connection)
                End If
                asyncNonFixed.Process()
        End Select
    End Sub
    Private Sub nonFixedInfosGathered(ByVal infos As asyncCallbackWindowGetNonFixedInfos.TheseInfos) Handles asyncNonFixed.GatheredInfos
        Me.Infos.SetNonFixedInfos(infos)
    End Sub

#End Region

#Region "All actions on window (close, ...)"

    Private Sub actionDone(ByVal Success As Boolean, ByVal action As asyncCallbackWindowAction.ASYNC_WINDOW_ACTION, ByVal handle As Integer, ByVal msg As String, ByVal actionNumber As Integer)
        If Success = False Then
            MsgBox("Error : " & msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, _
                   "Could not " & action.ToString & " (window = " & handle.ToString & ")")
        End If
        RemovePendingTask(actionNumber)
    End Sub

    Private _theAction As asyncCallbackWindowAction

    Public Function Close() As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.Close, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function Flash() As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.Flash, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function StopFlashing() As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.StopFlashing, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function BringToFront(ByVal value As Boolean) As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.BringToFront, Me.Infos.Handle, CInt(value), 0, 0, newAction))
    End Function
    Public Function SetAsForegroundWindow() As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SetAsForegroundWindow, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function SetAsActiveWindow() As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SetAsActiveWindow, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function Minimize() As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.Minimize, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function Maximize() As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.Maximize, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function Show() As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.Show, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function Hide() As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.Hide, Me.Infos.Handle, 0, 0, 0, newAction))
    End Function
    Public Function SetPositions(ByVal r As Native.Api.NativeStructs.Rect) As Boolean
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SetPosition, Me.Infos.Handle, 0, 0, 0, newAction, r))
    End Function
    Public Function SendMessage(ByVal msg As Integer, ByVal param1 As Integer, ByVal param2 As Integer) As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SendMessage, Me.Infos.Handle, msg, param1, param2, newAction))
    End Function
    Private Function SetEnabled(ByVal value As Boolean) As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SetEnabled, Me.Infos.Handle, CInt(value), 0, 0, newAction))
    End Function
    Private Function SetOpacity(ByVal value As Byte) As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SetOpacity, Me.Infos.Handle, CInt(value), 0, 0, newAction))
    End Function
    Private Function SetCaption(ByVal st As String) As Integer
        If _theAction Is Nothing Then
            _theAction = New asyncCallbackWindowAction(New asyncCallbackWindowAction.HasMadeAction(AddressOf actionDone), _connection)
        End If
        Dim t As New System.Threading.WaitCallback(AddressOf _theAction.Process)
        Dim newAction As Integer = cGeneralObject.GetActionCount
        AddPendingTask(newAction, t)
        Call Threading.ThreadPool.QueueUserWorkItem(t, New  _
            asyncCallbackWindowAction.poolObj(asyncCallbackWindowAction.ASYNC_WINDOW_ACTION.SetCaption, Me.Infos.Handle, 0, 0, 0, newAction, ss:=st))
    End Function

#End Region

#Region "Get information overriden methods"

    ' Retrieve informations by its name
    Public Overrides Function GetInformation(ByVal info As String) As String
        Dim res As String = NO_INFO_RETRIEVED

        If info = "ObjectCreationDate" Then
            res = _objectCreationDate.ToLongDateString & " -- " & _objectCreationDate.ToLongTimeString
        ElseIf info = "PendingTaskCount" Then
            res = PendingTaskCount.ToString
        End If

        Select Case info
            Case "Name", "Caption"
                res = Me.Caption
            Case "Handle", "Id"
                res = Me.Infos.Handle.ToString
            Case "Process"
                res = Me.Infos.ProcessId.ToString & " -- " & Me.Infos.ProcessName
            Case "IsTask"
                res = Me.Infos.IsTask.ToString
            Case "Enabled"
                res = Me.Infos.Enabled.ToString
            Case "Visible"
                res = Me.Infos.Visible.ToString
            Case "ThreadId"
                res = Me.Infos.ThreadId.ToString
            Case "Opacity"
                res = Me.Infos.Opacity.ToString
            Case "Left"
                res = Me.Infos.Left.ToString
            Case "Height"
                res = Me.Infos.Height.ToString
            Case "Top"
                res = Me.Infos.Top.ToString
            Case "Width"
                res = Me.Infos.Width.ToString
        End Select

        Return res
    End Function
    Public Overrides Function GetInformation(ByVal info As String, ByRef res As String) As Boolean

        ' Old values (from last refresh)
        Static _old_CpuUsage As String = ""
        Static _old_ObjectCreationDate As String = ""
        Static _old_PendingTaskCount As String = ""
        Static _old_Name As String = ""
        Static _old_Handle As String = ""
        Static _old_Process As String = ""
        Static _old_IsTask As String = ""
        Static _old_Enabled As String = ""
        Static _old_Visible As String = ""
        Static _old_ThreadId As String = ""
        Static _old_Opacity As String = ""
        Static _old_Left As String = ""
        Static _old_Height As String = ""
        Static _old_Top As String = ""
        Static _old_Width As String = ""

        Dim hasChanged As Boolean = True

        If info = "ObjectCreationDate" Then
            res = _objectCreationDate.ToLongDateString & " -- " & _objectCreationDate.ToLongTimeString
            If res = _old_ObjectCreationDate Then
                hasChanged = False
            Else
                _old_ObjectCreationDate = res
                Return True
            End If
        ElseIf info = "PendingTaskCount" Then
            res = PendingTaskCount.ToString
            If res = _old_PendingTaskCount Then
                hasChanged = False
            Else
                _old_PendingTaskCount = res
                Return True
            End If
        End If

        Select Case info
            Case "Name", "Caption"
                res = Me.Caption
                If res = _old_Name Then
                    hasChanged = False
                Else
                    _old_Name = res
                End If
            Case "Handle", "Id"
                res = Me.Infos.Handle.ToString
                If res = _old_Handle Then
                    hasChanged = False
                Else
                    _old_Handle = res
                End If
            Case "Process"
                res = Me.Infos.ProcessId.ToString & " -- " & Me.Infos.ProcessName
                If res = _old_Process Then
                    hasChanged = False
                Else
                    _old_Process = res
                End If
            Case "IsTask"
                res = Me.Infos.IsTask.ToString
                If res = _old_IsTask Then
                    hasChanged = False
                Else
                    _old_IsTask = res
                End If
            Case "Enabled"
                res = Me.Infos.Enabled.ToString
                If res = _old_Enabled Then
                    hasChanged = False
                Else
                    _old_Enabled = res
                End If
            Case "Visible"
                res = Me.Infos.Visible.ToString
                If res = _old_Visible Then
                    hasChanged = False
                Else
                    _old_Visible = res
                End If
            Case "ThreadId"
                res = Me.Infos.ThreadId.ToString
                If res = _old_ThreadId Then
                    hasChanged = False
                Else
                    _old_ThreadId = res
                End If
            Case "Opacity"
                res = Me.Infos.Opacity.ToString
                If res = _old_Opacity Then
                    hasChanged = False
                Else
                    _old_Opacity = res
                End If
            Case "Left"
                res = Me.Infos.Left.ToString
                If res = _old_Left Then
                    hasChanged = False
                Else
                    _old_Left = res
                End If
            Case "Height"
                res = Me.Infos.Height.ToString
                If res = _old_Height Then
                    hasChanged = False
                Else
                    _old_Height = res
                End If
            Case "Top"
                res = Me.Infos.Top.ToString
                If res = _old_Top Then
                    hasChanged = False
                Else
                    _old_Top = res
                End If
            Case "Width"
                res = Me.Infos.Width.ToString
                If res = _old_Width Then
                    hasChanged = False
                Else
                    _old_Width = res
                End If
        End Select

        Return hasChanged
    End Function


#End Region

    ' Get small icon handle of window
    Private Function GetWindowSmallIcon() As IntPtr
        Dim res As IntPtr
        Dim out As IntPtr
        res = Native.Api.NativeFunctions.SendMessageTimeout(_windowInfos.Handle, Native.Api.NativeEnums.WindowMessage.GetIcon, _
                                     New IntPtr(Native.Api.NativeEnums.IconSize.ICON_SMALL), IntPtr.Zero, _
                                     Native.Api.NativeEnums.SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 0, out)

        If out = IntPtr.Zero Then
            If (IntPtr.Size = 4) Then
                ' 32 Bits
                out = CType(Native.Api.NativeFunctions.GetClassLongPtr32(_windowInfos.Handle, Native.Api.NativeConstants.GCL_HICONSM), IntPtr)
            ElseIf (IntPtr.Size = 8) Then
                ' 64 bits
                out = Native.Api.NativeFunctions.GetClassLongPtr64(_windowInfos.Handle, Native.Api.NativeConstants.GCL_HICONSM)
            End If
        End If

        If out = IntPtr.Zero Then
            res = Native.Api.NativeFunctions.SendMessageTimeout(Native.Api.NativeFunctions.GetWindowLongPtr(_windowInfos.Handle, _
                                  Native.Api.NativeEnums.GetWindowLongOffset.HwndParent), _
                                  Native.Api.NativeEnums.WindowMessage.GetIcon, _
                                  New IntPtr(Native.Api.NativeEnums.IconSize.ICON_SMALL), IntPtr.Zero, _
                                  Native.Api.NativeEnums.SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 0, out)
        End If

        Return out
    End Function

#Region "Shared functions (local)"

    Public Shared Function LocalGetForegroundAppPID() As Integer
        Dim l As IntPtr = Native.Api.NativeFunctions.GetForegroundWindow
        Return asyncCallbackWindowEnumerate.GetProcIdFromWindowHandle(l)
    End Function

    ' Get all windows
    Public Shared Function CurrentLocalWindows(Optional ByVal all As Boolean = True) As Dictionary(Of String, cWindow)
        ' Local
        Dim currWnd As IntPtr
        Dim cpt As Integer

        Dim _dico As New Dictionary(Of String, cWindow)

        currWnd = Native.Api.NativeFunctions.GetWindow(Native.Api.NativeFunctions.GetDesktopWindow(), Native.Api.NativeEnums.GetWindow_Cmd.GW_CHILD)
        cpt = 0
        Do While Not (currWnd = IntPtr.Zero)

            ' Get procId from hwnd
            Dim pid As Integer = asyncCallbackWindowEnumerate.GetProcIdFromWindowHandle(currWnd)
            'If all OrElse Array.IndexOf(pObj.pid, pid) >= 0 Then
            ' Then this window belongs to one of our processes
            'If all OrElse asyncCallbackWindowEnumerate.GetCaptionLenght(currWnd) > 0 Then
            Dim tid As Integer = asyncCallbackWindowEnumerate.GetThreadIdFromWindowHandle(currWnd)
            Dim key As String = pid.ToString & "-" & tid.ToString & "-" & currWnd.ToString
            If _dico.ContainsKey(key) = False Then
                _dico.Add(key, New cWindow(New windowInfos(pid, tid, currWnd, asyncCallbackWindowEnumerate.GetCaption(currWnd))))
            End If
            'End If
            'End If

            currWnd = Native.Api.NativeFunctions.GetWindow(currWnd, Native.Api.NativeEnums.GetWindow_Cmd.GW_HWNDNEXT)
        Loop

        Return _dico
    End Function

    ' Close
    ' MUST BE USE FOR OWNED WINDOWS ONLY
    ' Because SendMessage is synchron and may cause thread to be hung
    Public Shared Function LocalClose(ByVal handle As IntPtr) As IntPtr
        Return Native.Api.NativeFunctions.SendMessage(handle, Native.Api.NativeEnums.WindowMessage.Close, IntPtr.Zero, IntPtr.Zero)
    End Function

    ' ShowWindowForeground
    Public Shared Function LocalShowWindowForeground(ByVal handle As IntPtr) As Boolean
        Return Native.Api.NativeFunctions.SetForegroundWindow(handle)
    End Function

#End Region

End Class
