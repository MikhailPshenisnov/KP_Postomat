using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Collections.Generic;

namespace Postomat_App
{
    // Класс для объекта постомата, с помощью этих функций производятся основные операции над данными в постамате
    public static class Postomat
    {
        // Пароль для доступа к консоли администратора
        private static string _adminPassword = "SuperUser19738";
        
        // Хранилище ячеек
        public static List<Cell> PostomatCells { get; set; } = new List<Cell>();

        // Обновление данных постомата из CSV файла
        public static void ReadCellsFromCsv()
        {
            var data = CSVTools.ReadFromCSV("PostomatCells.csv");
            PostomatCells = new List<Cell>();

            for (var i = 1; i < data.Count; i++)
            {
                PostomatCells.Add(new Cell(int.Parse(data[i][1])));
                
                // Проверка на пустоту ячейки и обработка null
                if (data[i][2] == "")
                {
                    PostomatCells[i - 1].Content = null;
                }
                else
                {
                    var orderData = data[i][2].Split(',');
                    PostomatCells[i - 1].Content = new Order(int.Parse(orderData[0]), 
                        int.Parse(orderData[1]), orderData[2]);
                }
            }
        }

        // Запись данных из хранилища постомата в CSV файл / Обновление файла при изменении данных
        public static void WriteCellsToCSV()
        {
            var data = new List<List<string>>();
            var orderString = "";
            
            foreach (var cell in PostomatCells)
            {
                orderString = cell.Content is null ? "" : cell.Content.GetOrderString();
                data.Add(new List<string>()
                { 
                    cell.Identifier.ToString(), cell.Size.ToString(), orderString
                });
            }
            CSVTools.WriteToCSV(data);
        }

        public static void AddCell(int cellSize)
        {
            PostomatCells.Add(new Cell(cellSize));
            WriteCellsToCSV();
        }

        public static void DeleteCell(int cellIdentifier)
        {
            for (var i = 0; i < PostomatCells.Count; i++)
            {
                if (PostomatCells[i].Identifier == cellIdentifier)
                {
                    PostomatCells.Remove(PostomatCells[i]);
                    WriteCellsToCSV();
                    return;
                }
            }
            throw new Exception("Wrong Index!");
        }

        // Перебирает ячейки и ищет ячейку с нужным заказом
        public static int FindCellByOrderNumber(int orderNumber)
        {
            foreach (var cell in PostomatCells)
            {
                if (!(cell.Content is null))
                {
                    if (cell.Content.Identifier == orderNumber)
                    {
                        return cell.Identifier;
                    }
                }
            }
            throw new Exception("Wrong order number");
        }

        // Очищает ячейку от заказа по индексу
        public static void ClearCellByIdentifier(int identifier)
        {
            foreach (var cell in PostomatCells)
            {
                if (cell.Identifier == identifier)
                {
                    cell.Content = null;
                }
            }
            WriteCellsToCSV();
        }

        // Добавляет в ячейку заказ
        public static void AddOrderToCell(int cellIdentifier, Order order)
        {
            foreach (var cell in PostomatCells)
            {
                if (cell.Identifier == cellIdentifier)
                {
                    cell.Content = order;
                }
            }
            WriteCellsToCSV();
        }
        
        // Проверка пароля администратора
        public static bool CheckAdminPassword(string password)
        {
            return password == _adminPassword;
        }
    }
}