﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Postomat_App;

// Класс для панели администратора
public partial class AdminPanelPage : Page
{
    public MainWindow ProgramWindow { get; set; }
    
    public AdminPanelPage()
    {
        InitializeComponent();
    }

    // Кнопка обновления отображения таблицы
    public void UpdateBtn_Click(object sender, RoutedEventArgs e)
    {
        DataListBox.Items.Clear();
        var data = CSVTools.ReadBareData("PostomatCells.csv");
        foreach (var d in data)
        {
            DataListBox.Items.Add(d);
        }
    }

    // Добавление в ячейку заказа (заполнение), аналог доставки у курьера
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
    }

    // Удаление из ячейки заказа (очистка), аналог получения заказа у посетителя
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

    // Создание пустой ячейки с заданным размером
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

    // Удаление ячейки по id ячейки
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

    // Возврат на главный экран
    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
}