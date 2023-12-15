using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Postomat_App;

public partial class AdminPanelPage : Page
{
    public MainWindow ProgramWindow { get; set; }
    
    public AdminPanelPage()
    {
        InitializeComponent();
    }

    public void UpdateBtn_Click(object sender, RoutedEventArgs e)
    {
        DataListBox.Items.Clear();
        var data = CSVTools.ReadBareData("PostomatCells.csv");
        foreach (var d in data)
        {
            DataListBox.Items.Add(d);
        }
    }

    private void FillBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            int identifier = int.Parse(IdentifierTextBox.Text);
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
        IdentifierTextBox.Text = "Id...";
        SizeTextBox.Text = "Size...";
        DescriptionTextBox.Text = "Description...";
        
        
        // _adminPanelPage.CellSizeTextBox.Text = "Size...";
        // _adminPanelPage.CellIdTextBox.Text = "Id...";
    }

    private void ClearBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Customer.ReceiveOrderByNumber(int.Parse(OrderIdTextBox.Text));
            MessageBox.Show($"The cell with your order is open, you can pick up your order!", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Incorrect order number!", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        OrderIdTextBox.Text = "Id...";
    }

    private void CreateBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Postomat.AddCell(int.Parse(CellSizeTextBox.Text));
            MessageBox.Show($"The cell was created!", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Incorrect cell size!", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        CellSizeTextBox.Text = "Size...";
    }

    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Postomat.DeleteCell(int.Parse(CellIdTextBox.Text));
            MessageBox.Show($"The cell was deleted!", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Incorrect cell id!", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        CellIdTextBox.Text = "Id...";
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
    
    private class DataExample
    {
        public int id;
        public int size;
        public string? order;

        public DataExample(int id, int size, string? order)
        {
            this.id = id;
            this.size = size;
            this.order = order;
        }
    }
}