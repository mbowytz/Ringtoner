Public Class MainForm
    Private Sub Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Go.Click

        '       MessageBox.Show("Com Port:" & GetUSBcableCOMport())

        'validation, all that jazz
        If (String.IsNullOrEmpty(File5.NameField) Or String.IsNullOrEmpty(File2.NameField) Or String.IsNullOrEmpty(File3.NameField) Or String.IsNullOrEmpty(File4.NameField) Or String.IsNullOrEmpty(File6.NameField)) Then
            MessageBox.Show("You must specify a title for each ringtone.")
        Else
            Dim xml As New OutputFile(File5.NameField, File2.NameField, File3.NameField, File4.NameField, File6.NameField)
            xml.WriteXML(".\output.xml")
            Dim midi1 As String = File5.FileField
            Dim midi2 As String = File2.FileField
            Dim midi3 As String = File3.FileField
            Dim midi4 As String = File4.FileField
            Dim midi5 As String = File6.FileField
            Dim p As New PeekAdapter()
            p.UploadFile(".\output.xml", midi1, midi2, midi3, midi4, midi5)
        End If

    End Sub

    Private Sub File5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File5.Load

    End Sub

    Private Sub File3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File3.Load

    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RingtoneReset.Click

        'Use the fields for the default ringtone settings
        'as set up in the upgrade installer directory.

        Dim p As New PeekAdapter()
        Dim peekPath = p.FindPeekPath()

        File5.NameField = "Peek"
        File5.FileField = peekPath & "tmsh\Peek.mid"

        File2.NameField = "Sunrise"
        File2.FileField = peekPath & "tmsh\Sunrise.mid"

        File3.NameField = "Nightfall"
        File3.FileField = peekPath & "tmsh\Nightfall.mid"

        File4.NameField = "Musicbox"
        File4.FileField = peekPath & "tmsh\Musicbox.mid"

        File6.NameField = "Walkabout"
        File6.FileField = peekPath & "tmsh\Walkabout.mid"

    End Sub
End Class
