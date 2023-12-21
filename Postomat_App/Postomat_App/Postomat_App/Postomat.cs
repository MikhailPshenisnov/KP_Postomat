namespace Postomat_App;

// Класс для объекта постомата, с помощью этих функций производятся основные операции над данными в постамате
public static class Postomat
{
    // Пароль для доступа к консоли администратора
    private const string AdminPassword = "SuperUser19738";

    // Хранилище ячеек
    private static CustomСontainer<Cell> PostomatCells { get; } = new();

    // Обновление данных постомата из CSV файла
    public static void ReadCellsFromCsv()
    {
        var data = CsvTools.ReadFromCsv("PostomatCells.csv");
        PostomatCells.ClearCells();

        for (var i = 1; i < data.Count; i++)
        {
            if (!data[i][1].Contains("d"))
            {
                PostomatCells.AddCell(new SingleCell((SizeEnum)int.Parse(data[i][1])));
                var order = data[i][2];
                if (order == "")
                {
                    PostomatCells.SetCellContent(i - 1, null);
                }
                else
                {
                    var orderData = data[i][2].Split(',');
                    PostomatCells.SetCellContent
                    (
                        i - 1, 
                        new Order
                        (
                            int.Parse(orderData[0]),
                            orderData[3], 
                            (SizeEnum)int.Parse(orderData[1]), 
                            orderData[2]
                        )
                    );
                }
            }
            else
            {
                PostomatCells.AddCell(new DoubleCell((SizeEnum)int.Parse(data[i][1].Split('d')[0])));
                var order1 = data[i][2].Split('|')[0];
                var order2 = data[i][2].Split('|')[1];

                Order? orderObj1 = null;
                Order? orderObj2 = null;
                
                if (order1 != "")
                {
                    var order1Data = order1.Split(',');
                    orderObj1 = new Order
                        (
                            int.Parse(order1Data[0]),
                            order1Data[3], 
                            (SizeEnum)int.Parse(order1Data[1]), 
                            order1Data[2]
                        );
                }
                if (order2 != "")
                {
                    var order2Data = order2.Split(',');
                    orderObj2 = new Order
                    (
                        int.Parse(order2Data[0]),
                        order2Data[3], 
                        (SizeEnum)int.Parse(order2Data[1]), 
                        order2Data[2]
                    );
                }

                PostomatCells.SetCellContent(i - 1, orderObj1, orderObj2);
            }
        }
        WriteCellsToCsv();
    }

    // Запись данных из хранилища постомата в CSV файл / Обновление файла при изменении данных
    private static void WriteCellsToCsv()
    {
        CsvTools.WriteToCsv(PostomatCells.GetDataForCsv());
    }

    // Добавление ячейки с соответствующим размером
    public static void AddCell(string cellSize)
    {
        if (!cellSize.Contains("d"))
        {
            PostomatCells.AddCell(new SingleCell((SizeEnum)int.Parse(cellSize)));
        }
        else
        {
            PostomatCells.AddCell(new DoubleCell((SizeEnum)int.Parse(cellSize.Split('d')[0])));
        }
        
        WriteCellsToCsv();
    }

    // Удаление ячейки по идентификатору ячейки
    public static void DeleteCell(int cellIdentifier)
    {
        PostomatCells.DeleteCell(cellIdentifier);
        WriteCellsToCsv();
    }

    // Перебирает ячейки и ищет ячейку с нужным заказом
    public static int FindCellByOrderNumber(int orderNumber)
    {
        return PostomatCells.FindCellByOrderNumber(orderNumber);
    }

    // Очищает ячейку от заказа по индексу
    public static void ClearCellByIdentifier(int identifier)
    {
        PostomatCells.ClearCellByIdentifier(identifier);
        WriteCellsToCsv();
    }

    // Добавляет в ячейку заказ
    public static void AddOrderToCell(int cellIdentifier, Order order)
    {
        PostomatCells.AddOrderToCell(cellIdentifier, order);
        WriteCellsToCsv();
    }
        
    // Проверка пароля администратора
    public static bool CheckAdminPassword(string password)
    {
        return password == AdminPassword;
    }

    public static int FindSuitableCell(Order order)
    {
        return PostomatCells.FindSuitableCell(order);
    }
}