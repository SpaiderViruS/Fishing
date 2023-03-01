using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ООО_Рыбалка.Models;
using ООО_Рыбалка.UserControls;

namespace ООО_Рыбалка.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        public static db_demoexalov7Context DbContext;
        public User User;

        /// <summary>
        /// Конструктор ProductListWindow
        /// </summary>
        /// <param name="user">Авторизовавшейся пользователь</param>
        public ProductList(User user)
        {
            InitializeComponent();
            DbContext = new db_demoexalov7Context();

            if (user != null)
            {
                UserSNP.Content = $"{user.UserName} {user.UserSurname} {user.UserPatronymic}";

                if (user.UserRoleNavigation.RoleId == 2)
                {
                    AddNewProduct.Visibility = Visibility.Visible;
                }
            }

            UpdateListView();
            LoadComboBoxes();

        }

        /// <summary>
        /// Функция вызываемая при изменении TextBox
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        /// <summary>
        /// Функция вызываемая при изменении ComboBox
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void SortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        /// <summary>
        /// Функция вызываемая при изменении ComboBox
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        /// <summary>
        /// Функция для обновления ListView
        /// </summary>
        private void UpdateListView()
        {
            ProductListView.Items.Clear();

            List<Product> displayProduct = new List<Product>();
            displayProduct = DbContext.Product.ToList();

            // Поиск
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text) && SearchTextBox.Text.Length > 0)
            {
                displayProduct = displayProduct.Where(p =>
                   p.ProductName.ToLower().Contains(SearchTextBox.Text.ToLower())
                || p.ProductDescription.ToLower().Contains(SearchTextBox.Text.ToLower())
                || p.ProductManufacturerNavigation.ManufacturerName.ToLower().Contains(SearchTextBox.Text.ToLower())
                || p.ProductCost.ToString().Contains(SearchTextBox.Text.ToLower())).ToList();

                displayProduct = displayProduct.Where(s => s.ProductName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            // Сортировка
            switch (SortingComboBox.SelectedIndex)
            {
                case 1:
                    displayProduct = displayProduct.OrderBy(p => p.ProductCost).ToList();
                    break;

                case 2:
                    displayProduct = displayProduct.OrderByDescending(p => p.ProductCost).ToList();
                    break;
            }

            // Фильтация
            switch (FilterComboBox.SelectedIndex)
            {
                case 1:
                    displayProduct = displayProduct.Where(m => m.ProductManufacturerNavigation.ManufacturerName
                    == "БТК Текстиль").ToList();
                    break;

                case 2:
                    displayProduct = displayProduct.Where(m => m.ProductManufacturerNavigation.ManufacturerName
                    == "Империя ткани").ToList();
                    break;

                case 3:
                    displayProduct = displayProduct.Where(m => m.ProductManufacturerNavigation.ManufacturerName
                    == "Комильфо").ToList();
                    break;

                case 4:
                    displayProduct = displayProduct.Where(m => m.ProductManufacturerNavigation.ManufacturerName
                    == "Май Фабрик").ToList();
                    break;
            }

            foreach (Product product in displayProduct)
            {
                ProductListView.Items.Add(new ProductUserControl(product)
                {
                    Width = GetOptimizedWidth()
                });
            }

            CountListViewLabel.Content = $"Выведено {ProductListView.Items.Count} из {DbContext.Product.Count()}";
        }

        /// <summary>
        /// Функция для получения оптимального размера
        /// </summary>
        /// <returns>Оптимальный размер</returns>
        private double GetOptimizedWidth()
        {
            if (WindowState == WindowState.Maximized)
            {
                return RenderSize.Width - 55;
            }
            else
            {
                return Width - 55;
            }
        }

        /// <summary>
        /// Функция для загрузки ComboBox
        /// </summary>
        private void LoadComboBoxes()
        {
            SortingComboBox.Items.Add("Все");
            SortingComboBox.Items.Add("Стоимость ↑");
            SortingComboBox.Items.Add("Стоимость ↓");

            FilterComboBox.Items.Add("Все производители");
            FilterComboBox.Items.Add("БТК Текстиль");
            FilterComboBox.Items.Add("Империя ткани");
            FilterComboBox.Items.Add("Комильфо");
            FilterComboBox.Items.Add("Май Фабрик");

            SortingComboBox.SelectedIndex = 0;
            FilterComboBox.SelectedIndex = 0;
        }

    }
}
