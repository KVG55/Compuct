Public NotInheritable Class Compuct1


    Private Const Caption As String = "Ошибка"
    ReadOnly stringManager As Resources.ResourceManager

    Private Sub Compuct1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            'Установить текст диалога во время выполнения в соответствии с информацией о сборке приложения.  

            'TODO: настроить сведения о сборке приложения в области "Приложение" диалогового окна 
            '  свойств проекта (в меню "Проект").

            'Заголовок приложения
            If My.Application.Info.Title <> "Compuct" Then
                ApplicationTitle.Text = My.Application.Info.Title
            Else
                'Если у приложения нет заголовка, использовать имя приложения без расширения
                ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If

            'Отформатировать информацию о версии с использованием в качестве строки формата текста,
            '  установленного для контроля версий во время разработки.  При необходимости это может использоваться для эффективной локализации.
            '  Информация о сборке и редакции может быть включена на основе следующего кода с заменой 
            '  текста, установленного для контроля версий во время разработки, на строку типа "Версия {0}.{1:00}.{2}.{3}".  Подробнее см.
            '  справку по String.Format().
            '
            '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

            Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.ToString, Nothing)

            'Информация об авторских правах
            Copyright.Text = My.Application.Info.Copyright & "Все права защищены"

        Catch ex As Exception
             MessageBox.Show(ex.Message, stringManager.GetString(Caption, Globalization.CultureInfo.CurrentUICulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
      End Sub

End Class
