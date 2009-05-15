﻿Option Strict On

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic

' State object for reading client data asynchronously

Public Class AsynchronousSocketListener
    ' Thread signal.


    Public Delegate Sub ReceivedDataEventHandler(ByRef data As cSocketData)
    Public Delegate Sub SentDataEventHandler()
    Public Delegate Sub DisconnectedEventHandler()
    Public Delegate Sub ConnectedEventHandler()
    Public Delegate Sub SocketErrorHandler()

    Public Event ReceivedData As ReceivedDataEventHandler
    Public Event SentData As SentDataEventHandler
    Public Event Disconnected As DisconnectedEventHandler
    Public Event Connected As ConnectedEventHandler
    Public Event SocketError As SocketErrorHandler


    Private listener As Socket

    ' This server waits for a connection and then uses  asychronous operations to
    ' accept the connection, get data from the connected client, 
    ' echo that data back to the connected client.
    ' It then disconnects from the client and waits for another client. 
    Public Sub Connect(ByVal port As Integer)

        ' Create a TCP/IP socket.
        Try
            listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            ' Bind the socket to the local endpoint and listen for incoming connections.
            listener.Bind(New IPEndPoint(IPAddress.Any, port))
            listener.Listen(1)

            ' Start an asynchronous socket to listen for connections.
            Trace.WriteLine("Waiting for client...")
            'While True
            '    Threading.Thread.Sleep(500)
            listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)
            'End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while connecting")
            RaiseEvent Disconnected()
            Exit Sub
        End Try
    End Sub 'Main


    Public Sub Disconnect()
        Try
            ' Do not accept anymore send/receive
            Trace.WriteLine("Client Shudown connection...")
            listener.Shutdown(SocketShutdown.Both)
            ' Disconnect
            Trace.WriteLine("Client BeginDisconnect...")
            listener.BeginDisconnect(False, AddressOf disconnectCallback, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while disconnecting")
            RaiseEvent Disconnected()
            Exit Sub
        End Try
    End Sub

    ' Callback for disconnect
    Private Sub disconnectCallback(ByVal asyncResult As IAsyncResult)
        ' OK we are now disconnected
        Try
            Trace.WriteLine("Client EndDisconnect...")
            Call listener.EndDisconnect(asyncResult)
            Trace.WriteLine("Client disconnected...")
            RaiseEvent Disconnected()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while disconnecting")
            RaiseEvent Disconnected()
            Exit Sub
        End Try
    End Sub

    Public Sub AcceptCallback(ByVal ar As IAsyncResult)

        ' Get the socket that handles the client request.
        'Dim listener As Socket = CType(ar.AsyncState, Socket)
        ' End the operation.
        Try
            Dim handler As Socket = listener.EndAccept(ar)
            listener = handler

            Trace.WriteLine("CLIENT ACCEPTED")
            RaiseEvent Connected()

            ' Create the state object for the async receive.
            Dim state As New StateObject
            state.workSocket = handler
            Trace.WriteLine("Server waiting for data...")
            handler.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, 0, New AsyncCallback(AddressOf ReadCallback), state)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while accepting connection")
            RaiseEvent Disconnected()
            Exit Sub
        End Try
    End Sub 'AcceptCallback


    Public Sub ReadCallback(ByVal ar As IAsyncResult)
        Dim content As String = String.Empty

        ' Retrieve the state object and the handler socket
        ' from the asynchronous state object.
        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket

        ' Read data from the client socket.
        Dim bytesRead As Integer
        Try
            bytesRead = handler.EndReceive(ar)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while receinving data")
            RaiseEvent Disconnected()
            Exit Sub
        End Try

        Trace.WriteLine("SERVER RECEIVED DATA")

        If bytesRead > 0 Then
            ' There might be more data, so store the data received so far.

            If state.receivedBuff Is Nothing Then
                ' Then this is the first part we get
                ReDim state.receivedBuff(bytesRead)
            Else
                ' Redim memory allocated
                ReDim Preserve state.receivedBuff(bytesRead + state.receivedSize)
            End If

            ' Copy buffer to global buffer
            Buffer.BlockCopy(state.buffer, 0, state.receivedBuff, state.receivedSize, bytesRead)
            state.receivedSize += bytesRead

            ' Get the rest of the data.
            Try
                handler.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, 0, New AsyncCallback(AddressOf ReadCallback), state)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while receiving data")
                RaiseEvent Disconnected()
                Exit Sub
            End Try
        Else
            ' All the data has arrived; put it in response.

            Dim cDat As cSocketData = cSerialization.DeserializeObject(state.receivedBuff)
            If cDat IsNot Nothing Then
                RaiseEvent ReceivedData(cDat)
                Trace.WriteLine("DATA HAS A SIZE OF " & state.receivedSize.ToString)
            End If
        End If

        If bytesRead < StateObject.BUFFER_SIZE Then
            ' Try to get a socketData from buffer, because it is the last part of
            ' the datas
            Dim cDat As cSocketData = cSerialization.DeserializeObject(state.receivedBuff)
            If cDat IsNot Nothing Then
                Trace.WriteLine("DATA HAS A SIZE OF " & state.receivedSize.ToString)
                ReDim state.receivedBuff(0)
                state.receivedSize = 0
                RaiseEvent ReceivedData(cDat)
            End If
        End If

    End Sub 'ReadCallback

    Public Sub Send(ByVal dat As cSocketData)
        ' Convert the string data to byte data using ASCII encoding.
        Dim byteData As Byte() = cSerialization.GetSerializedObject(dat)

        ' Begin sending the data to the remote device.
        Trace.WriteLine("Server sending...")
        Try
            listener.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), listener)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while sending data")
            RaiseEvent Disconnected()
            Exit Sub
        End Try
    End Sub 'Send


    Private Sub SendCallback(ByVal ar As IAsyncResult)
        ' Retrieve the socket from the state object.
        Dim handler As Socket = CType(ar.AsyncState, Socket)

        Try
            ' Complete sending the data to the remote device.
            Dim bytesSent As Integer = handler.EndSend(ar)
            Trace.WriteLine("SERVER HAS SENT")
            RaiseEvent SentData()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error while sending data")
            RaiseEvent Disconnected()
            Exit Sub
        End Try
    End Sub 'SendCallback
End Class 'AsynchronousSocketListener