using System.Windows;

namespace Postomat_App
{
    public partial class MainWindow
    {
        private StartPage _startPage = new StartPage(); // Стартовая страница

        private ReceiveOrderPage _receiveOrderPage = new ReceiveOrderPage(); // Страница получения заказа

        private DeliveryPage _deliveryPage = new DeliveryPage(); // Страница доставки

        private LoginAdminPanelPage _loginAdminPanelPage = new LoginAdminPanelPage();

        private AdminPanelPage _adminPanelPage = new AdminPanelPage();
        
        // Функции которые переключают окна и задают базовый текст для некоторых окон
        public void OpenStartPage()
        {
            MainWindowFrame.Content = _startPage;
        }

        public void OpenReceiveOrderPage()
        {
            MainWindowFrame.Content = _receiveOrderPage;
            _receiveOrderPage.OrderNumberTextBox.Text = "Enter your code...";
        }

        public void OpenDeliveryPage()
        {
            MainWindowFrame.Content = _deliveryPage;
            _deliveryPage.IdentidierTextBox.Text = "Id...";
            _deliveryPage.SizeTextBox.Text = "Size...";
            _deliveryPage.DescriptionTextBox.Text = "Description...";
        }
        
        public void OpenLoginAdminPanelPage()
        {
            MainWindowFrame.Content = _loginAdminPanelPage;
            _loginAdminPanelPage.PasswordTextBox.Text = "Password...";
            
        }

        public void OpenAdminPanelPage()
        {
            MainWindowFrame.Content = _adminPanelPage;
            
            _adminPanelPage.UpdateBtn_Click(new object(), new RoutedEventArgs());
            
            _adminPanelPage.IdentifierTextBox.Text = "Id...";
            _adminPanelPage.SizeTextBox.Text = "Size...";
            _adminPanelPage.DescriptionTextBox.Text = "Description...";
            _adminPanelPage.OrderIdTextBox.Text = "Id...";
            _adminPanelPage.CellSizeTextBox.Text = "Size...";
            _adminPanelPage.CellIdTextBox.Text = "Id...";
            
        }
        
        // Инициализация окна
        public MainWindow()
        {
            InitializeComponent();
            Postomat.ReadCellsFromCsv(); // Подгрузка данных из файла
            
            // Передача объекта окна страницам для корректного взаимодействия
            _startPage.ProgramWindow = this;
            _receiveOrderPage.ProgramWindow = this;
            _deliveryPage.ProgramWindow = this;
            _loginAdminPanelPage.ProgramWindow = this;
            _adminPanelPage.ProgramWindow = this;
            
            OpenStartPage(); // Открытие стартового окна
            
        }
    }
}