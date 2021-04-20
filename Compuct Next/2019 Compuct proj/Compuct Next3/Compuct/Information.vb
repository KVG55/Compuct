Public Class Information

    Private Const Caption As String = "Ошибка"
    ReadOnly stringManager As Resources.ResourceManager
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Close()

        Catch ex As Exception
             MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            TextBox1.Text = My.Resources.Information
        Catch ex As Exception
             MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Try
            If FontDialog1.ShowDialog() = DialogResult.OK Then
                TextBox1.Font = FontDialog1.Font
                TextBox1.ForeColor = FontDialog1.Color
            End If
        Catch ex As Exception
             MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub
End Class