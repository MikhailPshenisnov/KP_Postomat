using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Collections.Generic;

namespace Postomat_App
{
    public static class Postomat
    {
        public static List<Cell> PostomatCells { get; set; } = new List<Cell>();

        public static void ReadCellsFromCsv()
        {
            var data = CSVTools.ReadFromCSV("PostomatCells.csv");
            PostomatCells = new List<Cell>();

            for (var i = 1; i < data.Count; i++)
            {
                PostomatCells.Add(new Cell(int.Parse(data[i][1])));
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
            
            var sw = new StreamWriter("PostomatCells.csv");
            
            sw.WriteLine("cell_id;cell_size;order");
            
            foreach (var line in data)
            {
                sw.WriteLine($"{line[0]};{line[1]};{line[2]}");
            }
            sw.Close();
        }

        public static void AddCell(int cellSize)
        {
            PostomatCells.Add(new Cell(cellSize));
        }

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
    }
}