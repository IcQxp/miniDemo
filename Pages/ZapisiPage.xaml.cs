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
    /// Логика взаимодействия для ZapisiPage.xaml
    /// </summary>
    public partial class ZapisiPage : Page
    {
        class Zapis
        {
            public int zapisID { get; set; }
            public DateTime zapisDate { get; set; }
            public bool IsBooked { get; set; }
            public int? UserID { get; set; } // Если UserID = null, то запись свободна
        }

        private List<Zapis> zapisi = new List<Zapis>
        {
            new Zapis { zapisID = 1, zapisDate = DateTime.Now.AddHours(1), IsBooked = false, UserID = null },
            new Zapis { zapisID = 2, zapisDate = DateTime.Now.AddHours(2), IsBooked = false, UserID = null },
            new Zapis { zapisID = 3, zapisDate = DateTime.Now.AddHours(3), IsBooked = true, UserID = 1 },
            new Zapis { zapisID = 4, zapisDate = DateTime.Now.AddHours(4), IsBooked = false, UserID = null },
        };

        public ZapisiPage()
        {
            InitializeComponent();
            DisplayZapisi();

        }
        private void DisplayZapisi()
        {
            // Очищаем старые элементы
            ZapisiStackPanel.Children.Clear();

            foreach (Zapis zapis in zapisi)
            {
                StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(10) };

                TextBlock zapisText = new TextBlock
                {
                    Text = $"{zapis.zapisDate.ToString("dd/MM/yyyy HH:mm")} - " +
                           (zapis.IsBooked ? "Занято" : "Свободно")
                };

                Button actionButton = new Button
                {
                    Content = zapis.IsBooked ? "Отписаться" : "Записаться",
                    Tag = zapis, // Сохраняем объект записи как тег кнопки
                    Margin = new Thickness(10)
                };

                // Обработчик клика по кнопке
                actionButton.Click += OnActionButtonClick;

                stackPanel.Children.Add(zapisText);
                stackPanel.Children.Add(actionButton);

                // Добавляем StackPanel в UI
                ZapisiStackPanel.Children.Add(stackPanel);
            }


        }
        private void OnActionButtonClick(object sender, RoutedEventArgs e)
        {
            // Получаем объект записи из Tag кнопки
            var button = sender as Button;
            var appointment = button?.Tag as Zapis;

            if (appointment == null) return; // Если запись не найдена, выходим

            // Идентификатор пользователя (например, текущий пользователь)
            int currentUserID = 1; // Это значение должно быть получено из вашей текущей авторизации, здесь для примера

            if (appointment.IsBooked)
            {
                // Если запись занята, проверяем, записан ли текущий пользователь
                if (appointment.UserID == currentUserID)
                {
                    // Пользователь записан, значит, он может отписаться
                    appointment.IsBooked = false;
                    appointment.UserID = null;
                    MessageBox.Show("Вы успешно отписались от записи.");
                }
                else
                {
                    MessageBox.Show("Вы не записаны на эту запись.");
                }
            }
            else
            {
                // Если запись свободна, записываем пользователя
                appointment.IsBooked = true;
                appointment.UserID = currentUserID;
                MessageBox.Show("Вы успешно записались на прием.");
            }

            // Обновляем отображение записей
            DisplayZapisi();
        }
    }
}
