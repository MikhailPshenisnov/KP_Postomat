using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Postomat_App
{
    // Статический класс для работы с хранилищем данных в виде csv файла,
    // используется как библиотека для работы с файлом
    public static class CSVTools
    {
        // Функция считывает данные из файла и создает список с данными
        public static List<List<string>> ReadFromCSV(string filename)
        {
            var result = new List<List<string>>();

            using (var textFieldParser = new TextFieldParser("PostomatCells.csv"))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(";");

                var tmp = new List<string>();

                while (!textFieldParser.EndOfData)
                {
                    string[] fields = textFieldParser.ReadFields();
                    foreach (var i in fields)
                    {
                        tmp.Add(i);
                    }

                    result.Add(tmp);
                    tmp = new List<string>();
                }

                return result;
            }
        }

        // Функция для записи отформатированных данных в csv файл
        public static void WriteToCSV(List<List<string>> data)
        {
            var sw = new StreamWriter("PostomatCells.csv");
            
            sw.WriteLine("cell_id;cell_size;order");
            
            foreach (var line in data)
            {
                sw.WriteLine($"{line[0]};{line[1]};{line[2]}");
            }
            sw.Close();
        }
    }
}