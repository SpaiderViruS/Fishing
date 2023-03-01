using System.Linq;
using System.Threading;
using System.Windows;
using ООО_Рыбалка.Models;
using ООО_Рыбалка.Windows;

namespace ООО_Рыбалка
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        db_demoexalov7Context DbContext;
        int _ErrorCount = 0;

        /// <summary>
        /// Конструктор MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DbContext = new db_demoexalov7Context();
        }

        /// <summary>
        /// Функция вызываемая, при нажатии кнопки
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text)
               && !string.IsNullOrWhiteSpace(PasswordPasswordBox.Password))
            {
                User user = DbContext.User.Where(u => u.UserLogin == LoginTextBox.Text
                && u.UserPassword == PasswordPasswordBox.Password).FirstOrDefault();

                if (user != null)
                {
                    MessageBox.Show($"Вы авторизовались, как {user.UserRoleNavigation.RoleName}" +
                        $" {user.UserName} {user.UserSurname} {user.UserPatronymic}", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ProductList productListWindow = new ProductList(user);
                    productListWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    _ErrorCount++;

                    if (_ErrorCount >= 2)
                    {
                        Thread.Sleep(10000);

                        MessageBox.Show("Слишком много неудачных попыток входа система заблокирована на 10 секунд",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        /// <summary>
        /// Функция вызываемая, при нажатии кнопки
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void AuthorizationAsGuestButton_Click(object sender, RoutedEventArgs e)
        {
            ProductList productList = new ProductList(null);
            productList.Show();
            Close();
        }
    }
}
