using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Postomat_App
{
    public static class CSVTools
    {
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
    }
}