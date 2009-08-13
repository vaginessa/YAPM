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

Namespace Native.Api.Security

    <Flags()> _
    Public Enum ServiceManagerAccess As UInteger
        Connect = &H1
        CreateService = &H2
        EnumerateService = &H4
        Lock = &H8
        QueryLockStatus = &H10
        ModifyBootConfig = &H20
        All = StandardRights.Required Or Connect Or CreateService Or EnumerateService Or Lock Or QueryLockStatus Or ModifyBootConfig
    End Enum

End Namespace