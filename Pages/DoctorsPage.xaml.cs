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
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        class Doctor
        {
            public string LastName;
            public string FirstName;
            public int RoleID;
        }
        public DoctorsPage()
        {
            InitializeComponent();

            string[] Roles = { "Врач", "Интерн" };
            // Массив объектов типа Doctor
            Doctor[] doctors = new Doctor[]
            {
                new Doctor { LastName = "Иванов", FirstName = "Иван", RoleID = 1 },
                new Doctor { LastName = "Петров", FirstName = "Петр", RoleID = 2 },
                new Doctor { LastName = "Сидоров", FirstName = "Сидор", RoleID = 3 },
                new Doctor { LastName = "Алексеев", FirstName = "Алексей", RoleID = 4 },
                new Doctor { LastName = "Козлов", FirstName = "Козима", RoleID = 5 }
            };

            // Проход по каждому доктору в массиве
            foreach (Doctor doctor in doctors)
            {
                if (doctor.RoleID <= Roles.Length)
                {
                    StackPanel stackPanel = new StackPanel();
                    TextBlock nameTextBlock = new TextBlock();
                    TextBlock roleTextBlock = new TextBlock();
                    TextBlock fullNameTextBlock = new TextBlock();

                    // Заполнение текстовых блоков данными
                    fullNameTextBlock.Text = $"{doctor.LastName} {doctor.FirstName}";
                    roleTextBlock.Text = $"Роль ID: {Roles[doctor.RoleID - 1]}";
                    // Добавляем элементы в StackPanel
                    stackPanel.Children.Add(fullNameTextBlock);
                    stackPanel.Children.Add(roleTextBlock);
                    stackPanel.Margin = new Thickness(20);

                    // Добавляем StackPanel на родительский элемент
                    DoctorsStackPanel.Children.Add(stackPanel);
                }
            }
        }
    }
}

