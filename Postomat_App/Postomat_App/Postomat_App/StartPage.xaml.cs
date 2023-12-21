using System.Windows;
using System.Windows.Controls;

namespace Postomat_App
{
    // Стартовая страница
    public partial class StartPage : Page
    {
        // Программное окно
        public MainWindow ProgramWindow { get; set; }

        public StartPage()
        {
            InitializeComponent();
        }

        // Переход к странице посетителя
        private void ReceiveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow.OpenReceiveOrderPage();
        }

        // Переход к странице доставки
        private void DeliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow.OpenDeliveryPage();
        }

        // Переход ко входу в панель администратора
        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow.OpenLoginAdminPanelPage();
        }
    }
}