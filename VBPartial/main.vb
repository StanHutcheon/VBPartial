Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System.Text

Public Class main

    'Huge thanks to planetbeing for the original partial-zip code located at https://github.com/planetbeing/partial-zip
    'Shoutout to GreggJTurner for providing the C# code which this was based off.

    Public Function vbpartial(ByVal zipUrl As String, ByVal filename As String, ByVal destination As String)
        Dim num2 As Integer
        Dim requestUriString As String = zipUrl
        Dim str2 As String = filename
        Dim path As String = destination
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
        request.Method = "HEAD"
        Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
        Dim contentLength As Integer = CInt(response.ContentLength)
        If (contentLength > &H10015) Then
            num2 = ((contentLength - &HFFFF) - &H16)
        Else
            num2 = 0
        End If
        request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
        request.AddRange(num2, contentLength - 1)
        response = DirectCast(request.GetResponse, HttpWebResponse)
        Dim bytes As Byte() = Encoding.Unicode.GetBytes(New StreamReader(response.GetResponseStream, Encoding.Unicode).ReadToEnd)
        Dim num3 As Integer = FindPattern(bytes, BitConverter.GetBytes(&H6054B50))
        Dim buffer As Byte() = New Byte(&H16 - 1) {}
        Dim i As Integer
        For i = 0 To &H15 - 1
            buffer(i) = bytes((num3 + i))
        Next i
        Dim reader As New BinaryReader(New MemoryStream(buffer), Encoding.Unicode)
        reader.ReadInt32()
        reader.ReadInt16()
        reader.ReadInt16()
        reader.ReadInt16()
        Dim num5 As Integer = reader.ReadInt16
        Dim num6 As Integer = reader.ReadInt32
        Dim from As Integer = reader.ReadInt32
        reader.ReadInt16()
        request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
        request.AddRange(from, ((from + num6) - 1))
        response = DirectCast(request.GetResponse, HttpWebResponse)
        reader = New BinaryReader(New MemoryStream(Encoding.Unicode.GetBytes(New StreamReader(response.GetResponseStream, Encoding.Unicode).ReadToEnd)), Encoding.Unicode)
        Dim numArray As Integer() = New Integer(num5 - 1) {}
        Dim numArray2 As Short() = New Short(num5 - 1) {}
        Dim numArray3 As Short() = New Short(num5 - 1) {}
        Dim numArray4 As Short() = New Short(num5 - 1) {}
        Dim numArray5 As Short() = New Short(num5 - 1) {}
        Dim numArray6 As Short() = New Short(num5 - 1) {}
        Dim numArray7 As Short() = New Short(num5 - 1) {}
        Dim numArray8 As Integer() = New Integer(num5 - 1) {}
        Dim numArray9 As Integer() = New Integer(num5 - 1) {}
        Dim numArray10 As Integer() = New Integer(num5 - 1) {}
        Dim numArray11 As Short() = New Short(num5 - 1) {}
        Dim numArray12 As Short() = New Short(num5 - 1) {}
        Dim numArray13 As Short() = New Short(num5 - 1) {}
        Dim numArray14 As Short() = New Short(num5 - 1) {}
        Dim numArray15 As Short() = New Short(num5 - 1) {}
        Dim numArray16 As Integer() = New Integer(num5 - 1) {}
        Dim numArray17 As Integer() = New Integer(num5 - 1) {}
        Dim strArray As String() = New String(num5 - 1) {}
        Dim strArray2 As String() = New String(num5 - 1) {}
        Dim strArray3 As String() = New String(num5 - 1) {}
        Dim j As Integer
        For j = 0 To num5 - 1
            numArray(j) = reader.ReadInt32
            numArray2(j) = reader.ReadInt16
            numArray3(j) = reader.ReadInt16
            numArray4(j) = reader.ReadInt16
            numArray5(j) = reader.ReadInt16
            numArray6(j) = reader.ReadInt16
            numArray7(j) = reader.ReadInt16
            numArray8(j) = reader.ReadInt32
            numArray9(j) = reader.ReadInt32
            numArray10(j) = reader.ReadInt32
            numArray11(j) = reader.ReadInt16
            numArray12(j) = reader.ReadInt16
            numArray13(j) = reader.ReadInt16
            numArray14(j) = reader.ReadInt16
            numArray15(j) = reader.ReadInt16
            numArray16(j) = reader.ReadInt32
            numArray17(j) = reader.ReadInt32
            Dim buffer3 As Byte() = New Byte(numArray11(j) - 1) {}
            reader.Read(buffer3, 0, numArray11(j))
            strArray(j) = Encoding.ASCII.GetString(buffer3)
            If (numArray12(j) <> 0) Then
                buffer3 = New Byte(numArray12(j) - 1) {}
                reader.Read(buffer3, 0, numArray12(j))
                strArray2(j) = Encoding.ASCII.GetString(buffer3)
            End If
            If (numArray13(j) <> 0) Then
                buffer3 = New Byte(numArray13(j) - 1) {}
                reader.Read(buffer3, 0, numArray13(j))
                strArray3(j) = Encoding.ASCII.GetString(buffer3)
            End If
        Next j
        Dim flag As Boolean = False
        Dim index As Integer = 0
        Dim k As Integer
        For k = 0 To num5 - 1
            If (strArray(k) = str2) Then
                flag = True
                index = k
            End If
        Next k
        If Not flag Then
            Return False
        Else
            num2 = numArray17(index)
            request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
            request.AddRange(num2, ((num2 + 30) - 1))
            response = DirectCast(request.GetResponse, HttpWebResponse)
            reader = New BinaryReader(New MemoryStream(Encoding.Unicode.GetBytes(New StreamReader(response.GetResponseStream, Encoding.Unicode).ReadToEnd)), Encoding.Unicode)
            reader.ReadInt32()
            reader.ReadInt16()
            reader.ReadInt16()
            Dim num11 As Short = reader.ReadInt16
            reader.ReadInt16()
            reader.ReadInt16()
            reader.ReadInt32()
            reader.ReadInt32()
            reader.ReadInt32()
            Dim num12 As Short = reader.ReadInt16
            Dim num13 As Short = reader.ReadInt16
            Dim buffer4 As Byte() = New Byte(numArray9(index) - 1) {}
            num2 = (((numArray17(index) + 30) + num12) + num13)
            request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
            request.AddRange(num2, ((num2 + numArray9(index)) - 1))
            response = DirectCast(request.GetResponse, HttpWebResponse)
            response.GetResponseStream.Read(buffer4, 0, buffer4.Length)
            If (num11 = 8) Then
                Dim stream As New DeflateStream(New MemoryStream(buffer4), CompressionMode.Decompress)
                Dim buffer5 As Byte() = New Byte(numArray10(index) - 1) {}
                stream.Read(buffer5, 0, buffer5.Length)
                File.WriteAllBytes(path, buffer5)
                Return True
            Else
                File.WriteAllBytes(path, buffer4)
                Return True
            End If
        End If
    End Function

    Private Function FindPattern(ByVal data As Byte(), ByVal pattern As Byte()) As Integer
        Dim i As Integer
        For i = 0 To data.Length - 1
            If (data(i) <> pattern(0)) Then
                Continue For
            End If
            Dim flag As Boolean = True
            Dim j As Integer
            For j = 1 To pattern.Length - 1
                If (data((i + j)) <> pattern(j)) Then
                    flag = False
                    Exit For
                End If
            Next j
            If flag Then
                Return i
            End If
        Next i
        Return -1
    End Function

End Class
