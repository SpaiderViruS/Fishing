using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ООО_Рыбалка.Models;

namespace ООО_Рыбалка.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        Product Product;

        /// <summary>
        /// Конструктор ProductUserControl
        /// </summary>
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            Product = product;

            LoadLabels();
            LoadImage();
        }

        /// <summary>
        /// Функция для загрузки Label
        /// </summary>
        private void LoadLabels()
        {
            NameProductLabel.Content = $"Наименование: {Product.ProductName}";
            DescriptionProductLabel.Content = $"Описание: {Product.ProductDescription}";
            ManufracturerProductLabel.Content = $"Производитель: {Product.ProductManufacturerNavigation.ManufacturerName}";
            CostProductLabel.Content = $"Цена: {Product.ProductCost}";

            QuantityInStockLabel.Content = $"На складе: {Product.ProductQuantityInStock}";
        }

        /// <summary>
        /// Функция для загрузки изображения
        /// </summary>
        private void LoadImage()
        {
            if (Product.ProductPhoto != null && Product.ProductPhoto.Length > 0)
            {
                Uri resUri = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "Images", Product.ProductPhoto), UriKind.Absolute);
                ProductImage.Source = new BitmapImage(resUri);
            }
            else
            {
                ProductImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/picture.png"));
            }
        }
    }
}

