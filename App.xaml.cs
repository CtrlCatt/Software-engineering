using System;
using System.Linq;
using System.Windows;
using ConsoleApp1.Tests;

namespace ConsoleApp1
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Contains("--test"))
            {
                try
                {
                    ManualTests.RunAll();

                    MessageBox.Show(
                        "Все тесты успешно пройдены.",
                        "Результат тестирования",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    Shutdown(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка тестирования",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

                    Shutdown(1);
                }

                return;
            }

            base.OnStartup(e);

            var window = new MainWindow();
            window.Show();
        }
    }
}