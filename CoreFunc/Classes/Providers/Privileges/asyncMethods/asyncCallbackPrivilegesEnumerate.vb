﻿Option Strict On

Imports CoreFunc.cModuleConnection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Management

Public Class asyncCallbackPrivilegesEnumerate

    Private Const NO_INFO_RETRIEVED As String = "N/A"

    Public Structure poolObj
        Public ctrl As Control
        Public deg As [Delegate]
        Public con As cPrivilegeConnection
        Public pid As Integer
        Public Sub New(ByRef ctr As Control, ByVal de As [Delegate], ByRef co As cPrivilegeConnection, ByVal pi As Integer)
            ctrl = ctr
            deg = de
            con = co
            pid = pi
        End Sub
    End Structure


    Public Shared Sub Process(ByVal thePoolObj As Object)

        Dim pObj As poolObj = DirectCast(thePoolObj, poolObj)
        If pObj.con.ConnectionObj.IsConnected = False Then
            Exit Sub
        End If

        Select Case pObj.con.ConnectionObj.ConnectionType

            Case cConnection.TypeOfConnection.RemoteConnectionViaSocket

            Case cConnection.TypeOfConnection.RemoteConnectionViaWMI

            Case Else
                ' Local
                Dim _dico As New Dictionary(Of String, privilegeInfos)

                Dim ret As API.PrivilegeInfo() = GetPrivilegesList(pObj.pid)

                For Each tmp As API.PrivilegeInfo In ret
                    _dico.Add(tmp.Name, New privilegeInfos(tmp.Name, pObj.pid))
                Next

                pObj.ctrl.Invoke(pObj.deg, True, _dico, API.GetError)

        End Select

    End Sub



    ' Get privileges list of process
    Private Shared Function GetPrivilegesList(ByVal _pid As Integer) As API.PrivilegeInfo()

        Dim ListPrivileges() As API.PrivilegeInfo
        ReDim ListPrivileges(-1)
        Dim hProcessToken As Integer
        Dim hProcess As Integer
        Dim RetLen As Integer
        Dim TokenPriv As New API.TOKEN_PRIVILEGES
        Dim strBuff As String
        Dim lngBuff As Integer
        Dim i As Integer

        hProcess = API.OpenProcess(API.PROCESS_RIGHTS.PROCESS_QUERY_INFORMATION, 0, _pid)
        If hProcess > 0 Then
            API.OpenProcessToken(hProcess, API.TOKEN_QUERY, hProcessToken)
            If hProcessToken > 0 Then

                ' Get tokeninfo length
                API.GetTokenInformation(hProcessToken, 3, 0, 0, RetLen)
                Dim TokenInformation As IntPtr = Marshal.AllocHGlobal(RetLen)
                ' Get token information
                API.GetTokenInformation(hProcessToken, 3, CInt(TokenInformation), RetLen, 0)
                ' Get a valid structure
                TokenPriv = getTokenPrivilegeStructureFromPointer(TokenInformation, RetLen)

                ReDim ListPrivileges(TokenPriv.PrivilegeCount - 1)
                For i = 0 To TokenPriv.PrivilegeCount - 1
                    API.LookupPrivilegeNameA("", TokenPriv.Privileges(i).pLuid, "", lngBuff)
                    strBuff = Space$(lngBuff - 1)
                    API.LookupPrivilegeNameA("", TokenPriv.Privileges(i).pLuid, strBuff, lngBuff)
                    ListPrivileges(i).Name = strBuff
                    ListPrivileges(i).Status = TokenPriv.Privileges(i).Attributes
                    ListPrivileges(i).pLuid = TokenPriv.Privileges(i).pLuid
                    lngBuff = 0
                Next i
                API.CloseHandle(hProcessToken)
                Marshal.FreeHGlobal(TokenInformation)
            End If
            API.CloseHandle(hProcess)
        End If

        Return ListPrivileges

    End Function


    Private Shared Function getTokenPrivilegeStructureFromPointer(ByVal ptr As IntPtr, _
        ByVal RetLen As Integer) As API.TOKEN_PRIVILEGES

        'Public Structure LUID
        '	Dim lowpart As Integer
        '	Dim highpart As Integer
        'End Structure
        'Private Structure LUID_AND_ATTRIBUTES
        '	Dim pLuid As LUID
        '	Dim Attributes As Integer
        'End Structure
        'Private Structure TOKEN_PRIVILEGES
        '	Dim PrivilegeCount As Integer
        '	Dim Privileges() As LUID_AND_ATTRIBUTES
        'End Structure

        Dim ret As New API.TOKEN_PRIVILEGES

        ' Fill in int array from unmanaged memory
        Dim arr(CInt(RetLen / 4)) As Integer
        Marshal.Copy(ptr, arr, 0, arr.Length - 1)

        ' Get number of privileges
        Dim pCount As Integer = arr(0)     'CInt((RetLen - 4) / 12)
        ReDim ret.Privileges(pCount - 1)
        ret.PrivilegeCount = pCount

        ' Fill Privileges() array of ret
        ' Each item of array composed of three integer (lowPart, highPart and Attributes)
        Dim ep As Integer = 1
        For x As Integer = 0 To pCount - 1
            ret.Privileges(x).pLuid.lowpart = arr(ep)
            ret.Privileges(x).pLuid.highpart = arr(ep + 1)
            ret.Privileges(x).Attributes = arr(ep + 2)
            ep += 3
        Next

        Return ret

    End Function

End Class
