''' <summary>
''' Used for displaying a shape preview
''' </summary>
Public Class ShapePreview
    Inherits DataGridView

    'constants used for ignoring DGV focussing
    Const WM_LBUTTONDOWN As Integer = &H201
    Const WM_LBUTTONDBLCLK As Integer = &H203
    Const WM_KEYDOWN As Integer = &H100

    Private Const Caption As String = "Ошибка"
    ReadOnly stringManager As Resources.ResourceManager
    'avoids focussing
    Protected Overrides Sub OnRowPrePaint(e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        Try
            e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
            MyBase.OnRowPrePaint(e)
        Catch ex As Exception
             MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'ignores focussing
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            If m.Msg = WM_LBUTTONDBLCLK OrElse m.Msg = WM_LBUTTONDOWN OrElse m.Msg = WM_KEYDOWN Then

                Return
            End If
            MyBase.WndProc(m)
        Catch ex As Exception
             MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

End Class

