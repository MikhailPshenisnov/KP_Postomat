using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App
{
    public partial class StartPage : Page
    {
        public MainWindow ProgramWindow { get; set; }
        public StartPage()
        {
            InitializeComponent();
        }

        private void ReceiveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow.OpenReceiveOrderPage();
            
        }

        private void DeliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DeliveryBtn_Click");
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("AdminBtn_Click");
        }
    }
}