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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mainWindow;
        public Main()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow as MainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new ProductsPage();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            mainWindow.MainFrame.Content = new DoctorsPage();
        }
    }
}
