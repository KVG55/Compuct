

Public Class Form1

    Private score As Integer = 0

    Private Const Caption As String = "Ошибка"
    ReadOnly stringManager As Resources.ResourceManager





    'sets up DGVs
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Button2.Enabled = False

            StopGameToolStripMenuItem.Enabled = False


            For x As Integer = 1 To 20
                game.Columns.Add(New DataGridViewTextBoxColumn())
                game.Columns(x - 1).Width = 15
                If x < 7 Then
                    ShapePreview1.Columns.Add(New DataGridViewTextBoxColumn())
                    ShapePreview1.Columns(x - 1).Width = 15
                End If
            Next
            ShapePreview1.Rows.Add(6)
            game.Rows.Add(30)
            For x As Integer = 1 To 30
                game.Rows(x - 1).Height = 15
                If x < 7 Then
                    ShapePreview1.Rows(x - 1).Height = 15
                End If
            Next


            RichTextBox1.Text = CStr(My.Computer.Clock.LocalTime)

            RichTextBox4.Text() = "000100"

            RichTextBox1.Enabled = False
            RichTextBox2.Enabled = False
            RichTextBox3.Enabled = False
            RichTextBox5.Enabled = False


        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    'removes focus from DGVs
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try
            ShapePreview1.CurrentCell = Nothing
            ShapePreview1.ShowCellToolTips = False
            game.CurrentCell = Nothing
            game.ShowCellToolTips = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'renders game form
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Try
            Dim points() As Point = {game.Location, New Point(game.Left, game.Bottom), New Point(game.Right, game.Bottom), New Point(game.Right, game.Top)}
            Dim silverPen As New Pen(Color.Silver, 2)
            e.Graphics.DrawLines(silverPen, points)
            e.Graphics.DrawLine(silverPen, game.Right + 2, game.Bottom - 212, game.Right + 2, game.Bottom + 1) 'left
            e.Graphics.DrawLine(silverPen, game.Right + 1, game.Bottom - 213, game.Right + 126, game.Bottom - 213) 'top
            e.Graphics.DrawLine(silverPen, game.Right + 2, game.Bottom, game.Right + 125, game.Bottom) 'bottom
            e.Graphics.DrawLine(silverPen, game.Right + 125, game.Bottom - 212, game.Right + 125, game.Bottom + 1) 'right
            Dim xPosition As Integer = game.Right + 4
            Dim yPosition As Integer = game.Bottom - 16
            Dim cellLines() As Integer = {1, 2, 9, 10, 13, 14}
            For y As Integer = 1 To 14
                If cellLines.Contains(y) Then
                    For x As Integer = 0 To 7
                        e.Graphics.FillRectangle(Brushes.Silver, New Rectangle(xPosition + (x * 15), yPosition, 14, 14))
                    Next
                Else
                    e.Graphics.FillRectangle(Brushes.Silver, New Rectangle(xPosition, yPosition, 14, 14))
                    e.Graphics.FillRectangle(Brushes.Silver, New Rectangle(xPosition + (7 * 15), yPosition, 14, 14))
                End If
                yPosition -= 15
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'initiates new game
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, NewGameToolStripMenuItem.Click

        Try
            Dim b As String = "000025"

            If [String].IsNullOrEmpty(RichTextBox4.Text) = True Or RichTextBox4.Text = "0" Or RichTextBox4.Text.Trim.Length < 6 Or (CInt(RichTextBox4.Text) < CInt(b)) Then
                MsgBox("Введите числовое значение знаковых баллов, состоящее из не более шести знаков,и не менее 25, и не более: 999900, в указанном формате. СМ. ""Information"". ")
                game.StopGame()
                Exit Sub

            Else



                Dim a As Integer = 999900

                If (RichTextBox4.Text.Trim.Length > 6) Then Exit Sub
                If (RichTextBox4.Text.Trim.Length < 6) Then Exit Sub
                If (CInt(RichTextBox4.Text) > a) Then Exit Sub
                If (CInt(RichTextBox4.Text) < CInt(b)) Then Exit Sub

                InformationToolStripMenuItem.Enabled = False
                AboutCompuctToolStripMenuItem.Enabled = False



                RichTextBox4.Enabled = False


                Button2.Enabled = True

                    StopGameToolStripMenuItem.Enabled = True


                    Button2.BackColor = Color.White


                    RichTextBox3.Text() = ""
                    RichTextBox5.Text() = ""

                    score = 0
                lblScore.Text = score.ToString("000000")
                game.NewGame()

                    Timer1.Enabled = True

                    RichTextBox1.Text = CStr(My.Computer.Clock.LocalTime)
                End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'increases score and updates score display
    Private Sub Game_IncrementScore(newPoints As Integer) Handles game.IncrementScore
        Try
            score += newPoints
            lblScore.Text = score.ToString("000000")
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'updates shape preview
    Private Sub Game_ShapeChanged(shapePoints() As Point, shapeColor As String) Handles game.ShapeChanged
        Try
            Dim pts() As Point = DirectCast(shapePoints.Clone, Point())
            For y As Integer = 0 To 5
                For x As Integer = 0 To 5
                    ShapePreview1.Rows(y).Cells(x).Style.BackColor = Color.Black
                Next
            Next
            Dim minX As Integer = pts.Min(Function(p) p.X)
            Dim minY As Integer = pts.Min(Function(p) p.Y)
            For x As Integer = 0 To pts.GetUpperBound(0)
                pts(x).Offset(-minX, -minY)
            Next
            Dim w As Integer = pts.Max(Function(p) p.X) - pts.Min(Function(p) p.X)
            Dim h As Integer = pts.Max(Function(p) p.Y) - pts.Min(Function(p) p.Y)
            Dim offSetX As Integer = CInt(Math.Floor((6 - w) / 2))
            Dim offSetY As Integer = CInt(Math.Floor((6 - h) / 2))
            Dim colors As New Dictionary(Of String, Color) From {{"R", Color.Red}, {"G", Color.Green}, {"B", Color.Blue}, {"Y", Color.Yellow}}
            For x As Integer = 0 To pts.GetUpperBound(0)
                pts(x).Offset(offSetX, offSetY)
                ShapePreview1.Rows(pts(x).Y).Cells(pts(x).X).Style.BackColor = colors(shapeColor)
            Next
            game.Focus()
            game.CurrentCell = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub StopGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopGameToolStripMenuItem.Click, Button2.Click
        Try
            InformationToolStripMenuItem.Enabled = True
            AboutCompuctToolStripMenuItem.Enabled = True


            Button2.BackColor = Color.Red


            game.StopGame()
            Timer1.Enabled = False

            Duration()


            Dim a As Double = CDbl(RichTextBox3.Text) / 60
            RichTextBox5.Text() = CStr(a)

            RichTextBox4.Enabled = True

            MsgBox("Прежде чем начать новую игру, введите числовое значение выигрышных баллов,в указанном, в ""Information"" формате, если этому предшествовало удаление или изменение этого значения.")


        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            RichTextBox2.Text = CStr(My.Computer.Clock.LocalTime)

        Catch ex As Exception

            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub



    Private Sub LblScore_TextChanged(sender As Object, e As EventArgs) Handles lblScore.TextChanged
        Try
            If Not (RichTextBox4.Text = String.Empty) Then


                If lblScore.Text() >= RichTextBox4.Text() Then
                    game.StopGame()
                    Timer1.Enabled = False
                    Duration()

                    Dim a As Double = CDbl(RichTextBox3.Text) / 60
                    RichTextBox5.Text() = CStr(a)


                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Duration()

        Try
            Dim oldTime As Date = CDate(RichTextBox1.Text)
            Dim newTime As Date = CDate(RichTextBox2.Text)


            Dim difference As TimeSpan = newTime - oldTime
            Dim differenceInSeconds As Double = difference.TotalSeconds
            RichTextBox3.Text = CType(differenceInSeconds, String)
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub


    Private Sub InformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformationToolStripMenuItem.Click
        Try
            Dim Intn As New Information
            Intn.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    Private Sub AboutCompuctToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutCompuctToolStripMenuItem.Click
        Try
            Dim Ab As New AboutCompuct
            Ab.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            game.StopGame()
            Timer1.Enabled = False
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    Private Sub RichTextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox4.KeyPress
        Try

            'ограничение на вхождение не цифровых знаков
            If Char.IsDigit(e.KeyChar) = True Then Exit Sub
            If e.KeyChar = Convert.ToChar(Keys.Back) Then RichTextBox4.Text = "0"

            ' Ограничение на вхождения иных символьных знаков:
            e.Handled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox1.KeyPress, RichTextBox2.KeyPress, RichTextBox3.KeyPress, RichTextBox5.KeyPress

        Try
            ' Вхождение десятичных знаков и Backspace:
            If Char.IsDigit(e.KeyChar) = True Then Exit Sub ' или Return
            If e.KeyChar = Convert.ToChar(Keys.Back) Then Return ' или Exit Sub
            ' Ограничение на ввод иных символических знаков:

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try


    End Sub

    Private Sub RichTextBox4_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox4.TextChanged
        Try
            If (RichTextBox4.Text.Trim.Length > 6) Then RichTextBox4.Text = "0"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub
End Class
