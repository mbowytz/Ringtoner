Public Class PeekAdapter

    Private Sub UploadFiles()

        
    End Sub

    Private Function CheckPath(ByVal strPath As String) As Boolean
        If Dir$(strPath) <> "" Then
            CheckPath = True
        Else
            CheckPath = False
        End If
    End Function

    Public Function FindPeekPath() As String
        Dim pgmFiles As String = ""
        Dim PeekExe As String = "PeekDesktop.exe"
        Dim PeekPath As String = "\Peek\"
        Dim PeekPath2 As String = "\Peek.1.09.20b\"
        Dim PeekPath3 As String = "\Peek.1.09.18\"
        Dim PeekPath4 As String = "\Peek.1.10.00\"

        pgmFiles = Environ$("ProgramFiles")

        If (CheckPath(pgmFiles & PeekPath & PeekExe)) Then
            Return pgmFiles & PeekPath
        ElseIf (CheckPath(pgmFiles & PeekPath2 & PeekExe)) Then
            Return pgmFiles & PeekPath
        ElseIf (CheckPath(pgmFiles & PeekPath3 & PeekExe)) Then
            Return pgmFiles & PeekPath
        ElseIf (CheckPath(pgmFiles & PeekPath4 & PeekExe)) Then
            Return pgmFiles & PeekPath
        End If

        pgmFiles = Environ$("ProgramFiles(x86)")

        If (CheckPath(pgmFiles & PeekPath & PeekExe)) Then
            Return pgmFiles & PeekPath
        ElseIf (CheckPath(pgmFiles & PeekPath2 & PeekExe)) Then
            Return pgmFiles & PeekPath
        ElseIf (CheckPath(pgmFiles & PeekPath3 & PeekExe)) Then
            Return pgmFiles & PeekPath
        ElseIf (CheckPath(pgmFiles & PeekPath4 & PeekExe)) Then
            Return pgmFiles & PeekPath
        Else
            Return "x"
        End If

    End Function
    Private Function FindTMSHexe(ByVal PeekPath As String) As String

        Dim tmshExe As String = "tmsh\tmsh.exe"

        If (PeekPath.Equals("x")) Then
            Return "x"
        ElseIf (CheckPath(PeekPath & tmshExe)) Then
            'MessageBox.Show("Found tmsh " & tmshPath & tmshPath & tmshExe)
            Return PeekPath & tmshExe
        Else
            'MessageBox.Show("ERROR Can't find tmsh anywhere!")
            Return "x"
        End If

    End Function

    Private Function GetUSBcableCOMport() As String
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject
        ' Dim str As String
        Dim devName As String
        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_PnPEntity")
        moReturn = moSearch.Get

        For Each mo In moReturn
            devName = CStr(mo.Properties.Item("Name").Value)
            If devName.Contains("Prolific") Then
                'The cable is stored like: "Prolific USB-to-Serial Comm Port (COM5)"
                Return devName.Split(New Char() {"("c})((devName.Split(New Char() {"("c}).Length - 1)).Replace("COM", "").Replace(")", "").Replace(" ", "")
            End If
        Next
        Return "0"
    End Function


    Public Sub UploadFile(ByVal f As String, ByVal midi1 As String, ByVal midi2 As String, ByVal midi3 As String, ByVal midi4 As String, ByVal midi5 As String)

        Dim comPort As String = GetUSBcableCOMport()
        Dim tmshFileName As String = FindTMSHexe(FindPeekPath())

        If (comPort.Contains("0")) Then
            MessageBox.Show("Sorry, but your Peek cable doesn't seem to be connected or it's not configured right.")
        ElseIf (tmshFileName = "x") Then
            MessageBox.Show("Sorry, but the Peek Installer directory can't be found. Download a Peek Firmware Upgrader, run it and try again.")
        ElseIf (String.IsNullOrEmpty(midi1) Or String.IsNullOrEmpty(midi2) Or String.IsNullOrEmpty(midi3) Or String.IsNullOrEmpty(midi4) Or String.IsNullOrEmpty(midi5)) Then
            MessageBox.Show("You need to specify files for all fields.")
        ElseIf (CheckPath(midi1).Equals(False) Or CheckPath(midi2).Equals(False) Or CheckPath(midi3).Equals(False) Or CheckPath(midi4).Equals(False) Or CheckPath(midi5).Equals(False)) Then
            MessageBox.Show("Please recheck your file names - at least one was not found")
        Else

            'Dim comPort As String = GetUSBcableCOMport()

            Dim tmshProcess As New Process
            tmshProcess.StartInfo.UseShellExecute = False
            tmshProcess.StartInfo.RedirectStandardOutput = True
            tmshProcess.StartInfo.RedirectStandardError = True
            tmshProcess.StartInfo.RedirectStandardInput = True
            tmshProcess.StartInfo.FileName = (tmshFileName)
            tmshProcess.StartInfo.Arguments = ("-ps" & comPort & " -ttlocosto")
            'tmshProcess.StartInfo.WorkingDirectory = tmshPath 'Something else??????
            tmshProcess.StartInfo.CreateNoWindow = True
            Dim sLine As String = "the"

            'Point of no return!!!
            '   Return
            MessageBox.Show("We're good to go!  Found the Peek Cable on Port Num " & comPort & " and the Peek upgrade software is at " & tmshFileName)
            MessageBox.Show("Starting upload...please wait for a message to appear. Wiggle your Peek's wheel to keep the backlight on.")

            tmshProcess.Start()
            sLine = tmshProcess.StandardOutput.ReadLine

            If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                'couldn't start tmsh
                tmshProcess.StandardInput.WriteLine("exit")
            Else
                tmshProcess.StandardInput.WriteLine("ping")
                sLine = tmshProcess.StandardOutput.ReadLine
                If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                    tmshProcess.StandardInput.WriteLine("exit")
                    MessageBox.Show("Can't communicate with your Peek - please try again.")
                    Return
                Else
                    'goto Peek directory
                    tmshProcess.StandardInput.WriteLine("cd Peek")
                    'sLine = tmshProcess.StandardOutput.ReadLine

                    'MessageBox.Show("sLine:" & sLine)

                    If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                        'failed changing Directory
                        tmshProcess.StandardInput.WriteLine("exit")
                        MessageBox.Show("Cd Peek Failed!")
                        Return
                    End If

                    ' tmshProcess.StandardInput.WriteLine("exit")
                    'MessageBox.Show("Cd Peek Success!")
                    'Return

                    'add ring.cfg
                    tmshProcess.StandardInput.WriteLine("fwr output.xml ring.cfg")
                    sLine = tmshProcess.StandardOutput.ReadLine
                    If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                        'failed updating ring.cfg
                        tmshProcess.StandardInput.WriteLine("exit")
                        MessageBox.Show("Failed updating ring.cfg!")
                        Return
                    End If

                    'change dir down one level
                    tmshProcess.StandardInput.WriteLine("cd ..")
                    sLine = tmshProcess.StandardOutput.ReadLine
                    If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                        'failed changing dir
                        tmshProcess.StandardInput.WriteLine("exit")
                        Return
                    End If

                    'load file #1
                    If (Not String.IsNullOrEmpty(midi1)) Then
                        tmshProcess.StandardInput.WriteLine("fwr " & Chr(34) & midi1 & Chr(34) & " original.mid")
                        sLine = tmshProcess.StandardOutput.ReadLine
                        If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                            'Failed on file 1
                            'Else
                            '    MessageBox.Show("Midi1 Success!")
                        End If
                    End If

                    '                    tmshProcess.StandardInput.WriteLine("exit")
                    '                    MessageBox.Show("SUCCESS! " & midi1)
                    '                    Return

                    'load file #2
                    If (Not String.IsNullOrEmpty(midi2)) Then
                        tmshProcess.StandardInput.WriteLine("fwr " & Chr(34) & midi2 & Chr(34) & " type2.mid")
                        sLine = tmshProcess.StandardOutput.ReadLine
                        If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                            'Failed on file 2
                            'Else
                            '    MessageBox.Show("Midi2 Success!")
                        End If
                    End If

                    'load file #3
                    If (Not String.IsNullOrEmpty(midi3)) Then
                        tmshProcess.StandardInput.WriteLine("fwr " & Chr(34) & midi3 & Chr(34) & " type3.mid")
                        sLine = tmshProcess.StandardOutput.ReadLine
                        If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                            'Failed on file 3
                            'Else
                            '    MessageBox.Show("Midi3 Success!")
                        End If
                    End If

                    'load file #4
                    If (Not String.IsNullOrEmpty(midi4)) Then
                        tmshProcess.StandardInput.WriteLine("fwr " & Chr(34) & midi4 & Chr(34) & " type4.mid")
                        sLine = tmshProcess.StandardOutput.ReadLine
                        If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                            'Failed on file 4
                            'Else
                            '    MessageBox.Show("Midi4 Success!")
                        End If
                    End If

                    'load file #5
                    If (Not String.IsNullOrEmpty(midi5)) Then
                        tmshProcess.StandardInput.WriteLine("fwr " & Chr(34) & midi5 & Chr(34) & " type5.mid")
                        sLine = tmshProcess.StandardOutput.ReadLine
                        If (Not String.IsNullOrEmpty(sLine) And sLine.Contains("ERROR")) Then
                            'Failed on file 5
                            'Else
                            '    MessageBox.Show("Midi5 Success!")
                        End If
                    End If

                End If

                'all done - yeah!
                tmshProcess.StandardInput.WriteLine("exit")
                MessageBox.Show("RINGTONE UPLOAD COMPLETE! :-) Turn your Peek off and on to finish the process.")

            End If

        End If

    End Sub
End Class
