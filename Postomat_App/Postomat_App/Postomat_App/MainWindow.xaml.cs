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
        public void OpenStartPage()
        {
            MainWindowFrame.Content = _startPage;
        }

        public void OpenReceiveOrderPage()
        {
            MainWindowFrame.Content = _receiveOrderPage;
            _receiveOrderPage.OrderNumberTextBox.Text = "Enter your code...";
        }
        public MainWindow()
        {
            InitializeComponent();
            Postomat.ReadCellsFromCsv();
            var tmp_check = Postomat.PostomatCells;
            _startPage.ProgramWindow = this;
            _receiveOrderPage.ProgramWindow = this;
            
            OpenStartPage();
            
        }
    }
}