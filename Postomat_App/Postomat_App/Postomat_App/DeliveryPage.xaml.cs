using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App;

public partial class DeliveryPage : Page
{
    public MainWindow ProgramWindow { get; set; }
    public DeliveryPage()
    {
        InitializeComponent();
    }

    // Обработка нажатия на кнопку получения заказа с обработкой данных введенных пользователем
    // Прописан обработчик ошибок
    private void ReceiveOrderByNumberBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            int identifier = int.Parse(IdentidierTextBox.Text);
            int size = int.Parse(SizeTextBox.Text);
            string description = DescriptionTextBox.Text;

            Order newOrder;

            if (description == "Description...") description = "";
            newOrder = description == "" ? new Order(identifier, size) : new Order(identifier, size, description);
            
            Delivery.AddOrderToCell(newOrder);
            
            MessageBox.Show($"The order was successfully delivered!", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Incorrect input data or there are no free suitable cells!", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Возврат в главное меню
    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
}