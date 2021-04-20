Imports System.Drawing.Drawing2D



Public NotInheritable Class AboutCompuct

    Private Const Caption As String = "Ошибка"
    ReadOnly stringManager As Resources.ResourceManager

    'константа для целочисленного значения ширины прорисовки
    Private Const V As Integer = 3
    'константа для целочисленного значения ширины прорисовки, окончание пирамиды или ее начало.
    Private Const v1 As Integer = V
    'константа логического оператора, дополнительный идентификатор операции для второго таймера.
    Private Const V2 As Boolean = False
    ' Текущая позиция объекта 
    Dim poit As Integer
    ' Нижняя граница формы 
    ReadOnly Zero As Integer = ClientSize.Height
    ' Скорость падения 
    Dim SpeedMovie As Integer
    'Сила притяжения 
    ReadOnly GConst As Integer = 1
    ' Коэффициент затухания 
    ReadOnly slow As Single = 0.9

    ''' <summary>
    ''' прорисовка текста на форме
    ''' </summary>
    Private ReadOnly drawFormat As New StringFormat()
    Private ReadOnly drawFont As New Font("Times New Roman", 10)
    Private ReadOnly drawBrush As New SolidBrush(Color.Red)

    ''' <summary>
    ''' объявление и декларация переменной генератора случайных значений
    ''' </summary>
    Private ReadOnly m_Random As New Random
    ''' <summary>
    ''' создание объекта рисования с аргументом цвета
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly demoPen As New Pen(Color.FromArgb(255, m_Random.Next(255), m_Random.Next(255), m_Random.Next(255)))



    Private Sub AboutCompuct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            ' Установить заголовок формы.
            Dim ApplicationTitle As String
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Text = String.Format("О программе {0}", ApplicationTitle)
            ' Инициализировать текст, отображаемый в окне "О программе".
            ' TODO: настроить сведения о сборке приложения в области "Приложение" диалогового окна 
            '    свойств проекта (в меню "Проект").
            LabelProductName.Text = My.Application.Info.ProductName
            LabelVersion.Text = String.Format("Версия {0}", My.Application.Info.Version.ToString)
            LabelCopyright.Text = My.Application.Info.Copyright
            LabelCompanyName.Text = My.Application.Info.CompanyName
            TextBoxDescription.Text = "Программа выполнена Караваевым В.Г. Copyright © WareZ VK Provider  2019"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub


    ''' <summary>
    ''' прорисовка текста на форме
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutBox1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Using formGraphics As Graphics = CreateGraphics()

                formGraphics.DrawString("КВ", drawFont, drawBrush, 444, 23, drawFormat)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            SpeedMovie += GConst
            poit = Button1.Top + SpeedMovie ' Падение вниз 
            Button1.Top = poit
            If Button1.Height + Button1.Top >= Zero Then
                ' По дочтижении нижней границы формы, 
                ' то отскок вверх, и изменение направления движения 
                ' с замедлением скорости 
                SpeedMovie *= CInt(-1 * slow)
                Button1.Top = Zero - Button1.Height
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub AboutBox1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Try
            Timer1.Enabled = False
            Timer2.Enabled = V2
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    ''' <summary>
    ''' ведущяя процедура прорисовки линий окаймляющих форму
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Canvas1(sender As Object, e As EventArgs) _
        Handles MyBase.Activated
        Try


            ' Set the DashPattern to use if Custom type of Dashed Line is selected
            demoPen.DashPattern = New Single() {0.5, 0.25, 0.75, 1.5}



            demoPen.Color = Color.FromArgb(255, m_Random.Next(255), m_Random.Next(255), m_Random.Next(255))

            ' Set the user defined values for all the pen objects
            ' Width of the Pen is in pixels 
            demoPen.Width = v1
            ' DashStyle determines the look of the line.

            Dim number As Short = CShort(m_Random.Next(5))
            Select Case number
                Case 0
                    demoPen.DashStyle = DashStyle.Dash
                Case 1
                    demoPen.DashStyle = DashStyle.Dot
                Case 2
                    demoPen.DashStyle = DashStyle.DashDot
                Case 3
                    demoPen.DashStyle = DashStyle.DashDotDot
                Case 4
                    demoPen.DashStyle = DashStyle.Custom
            End Select

            '    StartCap determines the cap that should be put on
            ' the start of a line drawn by the pen

            Dim number1 As Short = CShort(m_Random.Next(11))
            Select Case number
                Case 0
                    demoPen.StartCap = LineCap.Flat
                Case 1
                    demoPen.StartCap = LineCap.Square
                Case 2
                    demoPen.StartCap = LineCap.Round
                Case 3
                    demoPen.StartCap = LineCap.Triangle
                Case 4
                    demoPen.StartCap = LineCap.NoAnchor
                Case 5
                    demoPen.StartCap = LineCap.SquareAnchor
                Case 6
                    demoPen.StartCap = LineCap.RoundAnchor
                Case 7
                    demoPen.StartCap = LineCap.DiamondAnchor
                Case 8
                    demoPen.StartCap = LineCap.ArrowAnchor
                Case 9
                    demoPen.StartCap = LineCap.AnchorMask
                Case 10
                    demoPen.StartCap = LineCap.Custom
            End Select
            ' EndCap determines the cap that should be put on
            ' the end of a line drawn by the pen

            Dim number2 As Short = CShort(m_Random.Next(11))
            Select Case number
                Case 0
                    demoPen.EndCap = LineCap.Flat
                Case 1
                    demoPen.EndCap = LineCap.Square
                Case 2
                    demoPen.EndCap = LineCap.Round
                Case 3
                    demoPen.EndCap = LineCap.Triangle
                Case 4
                    demoPen.EndCap = LineCap.NoAnchor
                Case 5
                    demoPen.EndCap = LineCap.SquareAnchor
                Case 6
                    demoPen.EndCap = LineCap.RoundAnchor
                Case 7
                    demoPen.EndCap = LineCap.DiamondAnchor
                Case 8
                    demoPen.EndCap = LineCap.ArrowAnchor
                Case 9
                    demoPen.EndCap = LineCap.AnchorMask
                Case 10
                    demoPen.StartCap = LineCap.Custom
            End Select
            ' DashCap determines the cap that should be put on
            ' both ends of any dashes in a line drawn by the pen

            Dim number3 As Short = CShort(m_Random.Next(3))
            Select Case number
                Case 0
                    demoPen.DashCap = DashCap.Flat
                Case 1
                    demoPen.DashCap = DashCap.Round
                Case 2
                    demoPen.DashCap = DashCap.Triangle
            End Select


            Dim graphic As Graphics = CreateGraphics()
            ' Mode of Graphics
            graphic.SmoothingMode = SmoothingMode.AntiAlias



            graphic.DrawEllipse(demoPen, 440, 14, 30, 30)

            graphic.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            'инструмент прорисовки, присвоение значения исполнения свойств
            demoPen.DashOffset = (demoPen.DashOffset + 0.5F) Mod 30
            ' вызов процедуры, аргументы: форма и событие
            Canvas1(Me, New EventArgs())
        Catch ex As Exception
            MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Timer1.Enabled = True

            Timer2.Interval = 100
            Timer2.Enabled = Not Timer2.Enabled


        Catch ex As Exception

        End Try
    End Sub

    Private Sub AboutBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDoubleClick
        Try
            If e.Button = MouseButtons.Right Then
                Timer1.Enabled = False
                Timer2.Enabled = V2

                Button1.Location = New Point(434, 9)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Close()
    End Sub

End Class
