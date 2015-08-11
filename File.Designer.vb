<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class File
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FilePath = New System.Windows.Forms.TextBox
        Me.Browse = New System.Windows.Forms.Button
        Me.FileDialog = New System.Windows.Forms.OpenFileDialog
        Me.NameText = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'FilePath
        '
        Me.FilePath.Location = New System.Drawing.Point(115, 4)
        Me.FilePath.Name = "FilePath"
        Me.FilePath.Size = New System.Drawing.Size(272, 20)
        Me.FilePath.TabIndex = 0
        '
        'Browse
        '
        Me.Browse.Location = New System.Drawing.Point(393, 3)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(75, 23)
        Me.Browse.TabIndex = 1
        Me.Browse.Text = "Browse..."
        Me.Browse.UseVisualStyleBackColor = True
        '
        'FileDialog
        '
        Me.FileDialog.DefaultExt = "*.mid"
        Me.FileDialog.Filter = "Ringtones|*.mid"
        '
        'NameText
        '
        Me.NameText.Location = New System.Drawing.Point(4, 4)
        Me.NameText.Name = "NameText"
        Me.NameText.Size = New System.Drawing.Size(105, 20)
        Me.NameText.TabIndex = 2
        '
        'File
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NameText)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Me.FilePath)
        Me.Name = "File"
        Me.Size = New System.Drawing.Size(468, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FilePath As System.Windows.Forms.TextBox
    Friend WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents FileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents NameText As System.Windows.Forms.TextBox

End Class
