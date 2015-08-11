<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Go = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.File6 = New Ringtoner.File
        Me.File5 = New Ringtoner.File
        Me.File4 = New Ringtoner.File
        Me.File3 = New Ringtoner.File
        Me.File2 = New Ringtoner.File
        Me.RingtoneReset = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Go
        '
        Me.Go.Location = New System.Drawing.Point(431, 211)
        Me.Go.Name = "Go"
        Me.Go.Size = New System.Drawing.Size(75, 46)
        Me.Go.TabIndex = 4
        Me.Go.Text = "&Go"
        Me.Go.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ringtone Title"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ringtone Midi File"
        '
        'File6
        '
        Me.File6.FileField = ""
        Me.File6.Location = New System.Drawing.Point(38, 176)
        Me.File6.Name = "File6"
        Me.File6.NameField = ""
        Me.File6.Size = New System.Drawing.Size(472, 29)
        Me.File6.TabIndex = 5
        '
        'File5
        '
        Me.File5.FileField = ""
        Me.File5.Location = New System.Drawing.Point(38, 34)
        Me.File5.Name = "File5"
        Me.File5.NameField = ""
        Me.File5.Size = New System.Drawing.Size(472, 29)
        Me.File5.TabIndex = 1
        '
        'File4
        '
        Me.File4.FileField = ""
        Me.File4.Location = New System.Drawing.Point(38, 141)
        Me.File4.Name = "File4"
        Me.File4.NameField = ""
        Me.File4.Size = New System.Drawing.Size(472, 29)
        Me.File4.TabIndex = 4
        '
        'File3
        '
        Me.File3.FileField = ""
        Me.File3.Location = New System.Drawing.Point(38, 105)
        Me.File3.Name = "File3"
        Me.File3.NameField = ""
        Me.File3.Size = New System.Drawing.Size(472, 29)
        Me.File3.TabIndex = 3
        '
        'File2
        '
        Me.File2.FileField = ""
        Me.File2.Location = New System.Drawing.Point(38, 69)
        Me.File2.Name = "File2"
        Me.File2.NameField = ""
        Me.File2.Size = New System.Drawing.Size(472, 29)
        Me.File2.TabIndex = 2
        '
        'RingtoneReset
        '
        Me.RingtoneReset.Location = New System.Drawing.Point(41, 211)
        Me.RingtoneReset.Name = "RingtoneReset"
        Me.RingtoneReset.Size = New System.Drawing.Size(116, 46)
        Me.RingtoneReset.TabIndex = 8
        Me.RingtoneReset.Text = "&Ringtone Reset"
        Me.RingtoneReset.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 279)
        Me.Controls.Add(Me.RingtoneReset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.File6)
        Me.Controls.Add(Me.File5)
        Me.Controls.Add(Me.Go)
        Me.Controls.Add(Me.File4)
        Me.Controls.Add(Me.File3)
        Me.Controls.Add(Me.File2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Peek Ringtoner v1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    ' Friend WithEvents File1 As Ringtoner.File
    Friend WithEvents File2 As Ringtoner.File
    Friend WithEvents File3 As Ringtoner.File
    Friend WithEvents File4 As Ringtoner.File
    Friend WithEvents Go As System.Windows.Forms.Button
    Friend WithEvents File5 As Ringtoner.File
    Friend WithEvents File6 As Ringtoner.File
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RingtoneReset As System.Windows.Forms.Button

End Class
