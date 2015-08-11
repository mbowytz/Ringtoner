Imports System.Xml

Public Class OutputFile
    Private files As New List(Of String)
    Public Sub New(ByVal ParamArray files() As String)
        For Each f As String In files
            ' MessageBox.Show("F=" & f)
            Me.files.Add(f)
        Next
    End Sub

    Public Sub WriteXML(ByVal outputFile As String)

        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.Encoding = New System.Text.UTF8Encoding(False) 'Remove Byte Order Marking (BOM)

        Using writer As XmlWriter = XmlWriter.Create(outputFile, settings)
            ' Write XML data.

            writer.WriteStartDocument()
            '-
            writer.WriteStartElement("Peek")
            '--
            writer.WriteStartElement("ScrollTimeout")
            writer.WriteValue(30)
            writer.WriteEndElement()

            '--
            For Each f As String In files
                writer.WriteStartElement("Ring")
                '---
                writer.WriteStartElement("Name")
                Dim fi As New IO.FileInfo(f)
                'MessageBox.Show("Name:" & fi.Name)
                writer.WriteString(fi.Name) 'fs)
                writer.WriteEndElement()
                '---
                writer.WriteEndElement()
            Next
            '--
            writer.WriteEndElement()

            writer.Flush()
        End Using

    End Sub
End Class
