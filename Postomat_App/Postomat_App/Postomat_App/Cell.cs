using System.Collections.Generic;

namespace Postomat_App;

// Базовый класс для ячейки постамата
public abstract class Cell
{
    protected static int Counter; // Статический счетчик для ID

    public int Identifier { get; protected set; } // ID ячейки
    public SizeEnum Size { get; protected set; } // Размер ячейки

    public Order Content { get; protected set; } // То что лежит в ячейке, может быть null

    public abstract void ClearCell(); // Метод для очистки ячейки

    public abstract void
        SetContent(Order order, Order extraOrder = null); // Метод для строгой установки значения ячейки

    public abstract void AddOrder(Order order); // Метод для добавляния заказа в ячейку (не строгая установка значения)

    public abstract int GetOccupancyInformation(); // Получение информации о заполненности

    public abstract List<int?> GetOrderIdentifier(); // Получение номера заказа в ячейке
}