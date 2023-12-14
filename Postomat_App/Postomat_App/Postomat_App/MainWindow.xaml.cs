using System.Windows;

namespace Postomat_App
{
    public partial class MainWindow
    {
        private StartPage _startPage = new StartPage(); // Стартовая страница

        private ReceiveOrderPage _receiveOrderPage = new ReceiveOrderPage(); // Страница получения заказа

        private DeliveryPage _deliveryPage = new DeliveryPage(); // Страница доставки
        
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
        
        // Инициализация окна
        public MainWindow()
        {
            InitializeComponent();
            Postomat.ReadCellsFromCsv();
            _startPage.ProgramWindow = this;
            _receiveOrderPage.ProgramWindow = this;
            _deliveryPage.ProgramWindow = this;
            
            OpenStartPage();
            
        }
    }
}