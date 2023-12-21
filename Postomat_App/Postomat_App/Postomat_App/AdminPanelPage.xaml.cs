using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App;

// Страница для панели администратора
public partial class AdminPanelPage : Page
{
    // Программное окно
    public MainWindow ProgramWindow { get; set; }

    public AdminPanelPage()
    {
        InitializeComponent();
    }

    // Кнопка обновления отображения таблицы
    public void UpdateBtn_Click(object sender, RoutedEventArgs e)
    {
        DataListBox.Items.Clear();
        var data = CsvTools.ReadBareData("PostomatCells.csv");
        foreach (var d in data)
        {
            DataListBox.Items.Add(d);
        }
    }

    // Заполнение ячейки заказом, аналог доставки у курьера
    private void FillBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Administrator.FillCell(
                int.Parse(IdentifierTextBox.Text),
                ReceiverTextBox.Text,
                int.Parse(SizeTextBox.Text),
                DescriptionTextBox.Text);

            MessageBox.Show($"The order was successfully delivered!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception)
        {
            MessageBox.Show($"Incorrect input data or there are no free suitable cells!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        IdentifierTextBox.Text = "Id...";
        SizeTextBox.Text = "Size...";
        DescriptionTextBox.Text = "Description...";
        ReceiverTextBox.Text = "Receiver...";
    }

    // Очистка ячейки от заказа, аналог получения заказа у посетителя
    private void ClearBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Administrator.ClearCell(int.Parse(OrderIdTextBox.Text));
            MessageBox.Show($"The cell with your order is open, you can pick up your order!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception)
        {
            MessageBox.Show("Incorrect order number!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        OrderIdTextBox.Text = "Id...";
    }

    // Создание ячейки по размеру
    private void CreateBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Administrator.CreateCell(CellSizeTextBox.Text);
            MessageBox.Show($"The cell was created!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception)
        {
            MessageBox.Show("Incorrect cell size!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        CellSizeTextBox.Text = "Size...";
    }

    // Удаление ячейки по идентификатору ячейки ячейки
    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Administrator.DeleteCell(int.Parse(CellIdTextBox.Text));
            MessageBox.Show($"The cell was deleted!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception)
        {
            MessageBox.Show("Incorrect cell id!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        CellIdTextBox.Text = "Id...";
    }

    // Возврат на главный экран
    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
}