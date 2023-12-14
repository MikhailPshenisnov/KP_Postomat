using System.Windows;

namespace Postomat_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private StartPage _startPage = new StartPage();

        private ReceiveOrderPage _receiveOrderPage = new ReceiveOrderPage();

        private DeliveryPage _deliveryPage = new DeliveryPage();
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