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
            PostomatCells.AddCell(new Cell(int.Parse(data[i][1])));
                
            // Проверка на пустоту ячейки и обработка null
            if (data[i][2] == "")
            {
                PostomatCells.SetCellContent(i - 1, null);
            }
            else
            {
                var orderData = data[i][2].Split(',');
                PostomatCells.SetCellContent(i - 1, new Order(int.Parse(orderData[0]), "ЗАМЕНИ МЕНЯ", 
                    int.Parse(orderData[1]), orderData[2]));
            }
        }
    }

    // Запись данных из хранилища постомата в CSV файл / Обновление файла при изменении данных
    private static void WriteCellsToCsv()
    {
        CsvTools.WriteToCsv(PostomatCells.GetDataForCsv());
    }

    // Добавление ячейки с соответствующим размером
    public static void AddCell(int cellSize)
    {
        PostomatCells.AddCell(new Cell(cellSize));
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