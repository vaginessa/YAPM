' =======================================================
' Yet Another Process Monitor (YAPM)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yaprocmon/
' =======================================================


' YAPM is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' YAPM is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with YAPM; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA


Option Strict On

Public Class frmWindowPosition

    ' Default values
    Private defR As cWindow.RECT

    ' New positions (defR must be initialized by cmdOk_Click)
    Public ReadOnly Property NewRect() As cWindow.RECT
        Get
            Return defR
        End Get
    End Property

    ' Define current position of form
    Public Sub SetCurrentPositions(ByVal r As cWindow.RECT)
        defR = r
        Me.txtHeight.Text = CStr(r.Bottom - r.Top)
        Me.txtLeft.Text = CStr(r.Left)
        Me.txtTop.Text = CStr(r.Top)
        Me.txtWidth.Text = CStr(r.Right - r.Left)
    End Sub

    Private Sub cmdDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefault.Click
        Call SetCurrentPositions(Me.defR)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        With defR
            .Bottom = CInt(Val(Me.txtTop.Text) + Val(Me.txtHeight.Text))
            .Left = CInt(Val(Me.txtLeft.Text))
            .Right = CInt(Val(Me.txtLeft.Text) + Val(Me.txtWidth.Text))
            .Top = CInt(Val(Me.txtTop.Text))
        End With
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmWindowPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With frmMain
            .SetToolTip(Me.txtHeight, "Height of the form.")
            .SetToolTip(Me.txtLeft, "Left position of the form.")
            .SetToolTip(Me.txtWidth, "Width of the form.")
            .SetToolTip(Me.txtTop, "Top position of the form.")
            .SetToolTip(Me.cmdDefault, "Reset values.")
            .SetToolTip(Me.cmdOK, "Validate values.")
        End With
    End Sub
End Class