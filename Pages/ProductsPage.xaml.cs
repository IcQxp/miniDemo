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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        class Product
        {
            public string Name;
            public int Price;
            public string Description;
        }

        public ProductsPage()
        {
            InitializeComponent();

            Product[] products = new Product[]
     {
        new Product { Name = "товар 1", Price = 2, Description = "товар под цифрой 1" },
        new Product { Name = "товар 2", Price = 4, Description = "товар под цифрой 2" },
        new Product { Name = "товар 3", Price = 6, Description = "товар под цифрой 3" },
        new Product { Name = "товар 4", Price = 8, Description = "товар под цифрой 4" },
        new Product { Name = "товар 5", Price = 10, Description = "товар под цифрой 5" }
     };

            foreach ( Product product in products )
            {
                StackPanel stackPanel = new StackPanel();
                TextBlock nameTextBlock = new TextBlock();
                TextBlock priceTextBlock = new TextBlock();
                TextBlock descriptionTextBlock = new TextBlock();
                nameTextBlock.Text = product.Name;
                priceTextBlock.Text = product.Price.ToString();
                descriptionTextBlock.Text = product.Description;
                stackPanel.Children.Add( nameTextBlock );
                stackPanel.Children.Add( priceTextBlock );
                stackPanel.Children.Add(descriptionTextBlock);
                stackPanel.Margin = new Thickness(20);
                ProductsStackPanel.Children.Add( stackPanel );

            }
        }
    }
}
