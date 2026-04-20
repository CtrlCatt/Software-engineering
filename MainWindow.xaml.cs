using System.Windows;
using ConsoleApp1.ViewModels;

namespace ConsoleApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}