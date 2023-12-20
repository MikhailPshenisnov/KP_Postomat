using System.Collections.Generic;

namespace Postomat_App;

// Класс для ячейки постамата
public abstract class Cell
{
    protected static int Counter; // Статический счетчик для ID

    public int Identifier { get; protected set; } // ID ячейки
    public SizeEnum Size { get; protected set; } // Размер ячейки
        
    /*  Существует 3 размера ячейки маленький (0), средний (1) и крупный (2)
        По умолчанию создается средняя ячейка
        для икслючения ошибок значения меньше 1 приравниваются к маленьким ячейкам,
        а больше 2 к крупным.
     */
        
    public Order? Content { get; protected set; } // То что лежит в ячейке, может быть null

    public abstract void ClearCell();
    
    public abstract void SetContent(Order? order, Order? extraOrder = null);

    public abstract void AddOrder(Order? order);

    public abstract int GetOccupancyInformation();

    public abstract List<int?> GetOrderIdentifier();
}