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
    private void DeliverOrderBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var identifier = int.Parse(IdentidierTextBox.Text);
            var size = int.Parse(SizeTextBox.Text);
            var description = DescriptionTextBox.Text;
            var receiver = ReceiverTextBox.Text;

            if (description == "Description...") description = "";
            if (receiver is "" or "Receiver...") throw new Exception("Incorrect receiver!");
            
            var newOrder = description == "" ? 
                new Order(identifier, receiver, (SizeEnum)size) : 
                new Order(identifier, receiver, (SizeEnum)size, description);
            
            Delivery.AddOrderToCell(newOrder);
            
            MessageBox.Show($"The order was successfully delivered!", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Incorrect input data or there are no free suitable cells!\n" +
                            $"{exception.Message}", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        IdentidierTextBox.Text = "Id...";
        SizeTextBox.Text = "Size...";
        DescriptionTextBox.Text = "Description...";
        ReceiverTextBox.Text = "Receiver...";
    }

    // Возврат в главное меню
    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
}