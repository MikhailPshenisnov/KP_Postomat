namespace Postomat_App;

public class SingleCell: Cell
{
    // public Order? Content { get; set; } // То что лежит в ячейке, может быть null

    public SingleCell(int size = 1)
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