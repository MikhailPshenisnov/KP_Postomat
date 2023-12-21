using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App;

// Страница для окна посетителя
public partial class ReceiveOrderPage : Page
{
    // Программное окно
    public MainWindow ProgramWindow { get; set; }

    public ReceiveOrderPage()
    {
        InitializeComponent();
    }

    // Кнопка получения заказа по номеру
    private void ReceiveOrderByNumberBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Customer.ReceiveOrderByNumber(int.Parse(OrderNumberTextBox.Text));
            MessageBox.Show($"The cell with your order is open, you can pick up your order!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception)
        {
            MessageBox.Show("Incorrect order number!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        OrderNumberTextBox.Text = "Enter your code...";
    }

    // Кнопка "назад к главному меню"
    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
}