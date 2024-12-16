using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        MainWindow mainWindow;
        public Auth()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow as MainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new Main();

        }
    }
}
