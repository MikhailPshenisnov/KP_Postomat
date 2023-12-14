using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App
{
    public partial class ReceiveOrderPage : Page
    {
        public MainWindow ProgramWindow { get; set; }
        
        public ReceiveOrderPage()
        {
            InitializeComponent();
        }

        private void ReceiveOrderByNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer.ReceiveOrderByNumber(int.Parse(OrderNumberTextBox.Text));
                MessageBox.Show($"The cell with your order is open, you can pick up your order!", "Success", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Incorrect order number!", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            OrderNumberTextBox.Text = "Enter your code...";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow.OpenStartPage();
        }
    }
}