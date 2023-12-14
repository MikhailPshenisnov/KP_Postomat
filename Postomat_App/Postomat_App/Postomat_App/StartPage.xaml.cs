using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App
{
    // Окно стартового экрана
    public partial class StartPage : Page
    {
        public MainWindow ProgramWindow { get; set; }
        public StartPage()
        {
            InitializeComponent();
        }

        // Переход к странице получения заказа
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
            Console.WriteLine("AdminBtn_Click");
        }
    }
}