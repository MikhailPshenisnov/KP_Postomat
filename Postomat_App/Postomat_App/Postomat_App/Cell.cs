namespace Postomat_App;

// Класс для ячейки постамата
public class Cell
{
    protected static int _counter; // Статический счетчик для ID

    public int Identifier { get; protected set; } // ID ячейки
    public int Size { get; protected set; } // Размер ячейки
        
    /*  Существует 3 размера ячейки маленький (0), средний (1) и крупный (2)
        По умолчанию создается средняя ячейка
        для икслючения ошибок значения меньше 1 приравниваются к маленьким ячейкам,
        а больше 2 к крупным.
     */
        
    public Order? Content { get; set; } // То что лежит в ячейке, может быть null

    public Cell(int size = 1)
    {
        Identifier = _counter++;
            
        if (size < 0)
        {
            size = 0;
        }
        else if (size > 2)
        {
            size = 2;
        }

        Size = size;

        Content = null;
    }
}