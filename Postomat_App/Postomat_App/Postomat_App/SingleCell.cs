using System;

namespace Postomat_App;

public class SingleCell: Cell
{
    // public Order? Content { get; set; } // То что лежит в ячейке, может быть null

    public SingleCell(int size = 1)
    {
        Identifier = Counter++;
            
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

    public override void ClearCell()
    {
        Content = null;
    }

    public override void SetContent(Order order, Order? extraOrder=null)
    {
        if (extraOrder is not null) throw new Exception("A single cell cannot accept a second order!");
        Content = order;
    }

    public override void AddOrder(Order? order)
    { 
        SetContent(order);
    }

    public override int GetOccupancyInformation()
    {
        return Content == null ? 0 : 1;
    }

    public override int GetOrderIdentifier()
    {
        if (Convert.ToBoolean(GetOccupancyInformation()))
        {
            return Content!.Identifier;
        }

        throw new Exception("There is no any order in the cell!");

    }
}