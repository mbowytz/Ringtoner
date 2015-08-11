Public Class File

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        FileDialog.ShowDialog()
        FilePath.Text = FileDialog.FileName
    End Sub

    Public Property NameField() As String
        Get
            Return NameText.Text
        End Get
        Set(ByVal value As String)
            NameText.Text = value
        End Set
    End Property

    Public Property FileField() As String
        Get
            Return FilePath.Text
        End Get
        Set(ByVal value As String)
            FilePath.Text = value
        End Set
    End Property
End Class
