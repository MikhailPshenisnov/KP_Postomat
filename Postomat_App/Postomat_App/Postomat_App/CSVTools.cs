using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Postomat_App;

// Статический класс для работы с хранилищем данных в виде csv файла,
// используется как библиотека для работы с файлом
public static class CsvTools
{
    // Функция считывает данные из файла и создает список с данными
    public static List<List<string>> ReadFromCsv(string filename)
    {
        var result = new List<List<string>>();

        using (var textFieldParser = new TextFieldParser(filename))
        {
            textFieldParser.TextFieldType = FieldType.Delimited;
            textFieldParser.SetDelimiters(";");

            var tmp = new List<string>();

            while (!textFieldParser.EndOfData)
            {
                string[] fields = textFieldParser.ReadFields();
                if (fields != null)
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

    // Вывод неформатированныз данных из csv файла
    public static List<string> ReadBareData(string filename)
    {
        var result = new List<string>();
        try
        {
            var sr = new StreamReader(filename);
            var line = sr.ReadLine();
            while (line != null)
            {
                result.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return result;
        }
        catch(Exception exception)
        {
            throw new Exception($"Something went wrong! {exception.Message}");
        }
    }

    // Функция для записи отформатированных данных в csv файл
    public static void WriteToCsv(List<List<string>> data)
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