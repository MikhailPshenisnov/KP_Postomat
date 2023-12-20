using System;
using System.Collections.Generic;

namespace Postomat_App;

public class SingleCell: Cell
{
    public SingleCell(SizeEnum size = SizeEnum.Medium)
    {
        if (Enum.IsDefined(typeof(SizeEnum), size))
        {
            Size = size;
        }
        else
        {
            throw new Exception("Wrong size!");
        }
        
        Identifier = Counter++;

        Content = null;
    }

    public override void ClearCell()
    {
        SetContent(null);
    }

    public override void SetContent(Order? order, Order? extraOrder=null)
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

    public override List<int?> GetOrderIdentifier()
    {
        if (Convert.ToBoolean(GetOccupancyInformation()))
        {
            return new List<int?> {Content!.Identifier, null};
        }

        throw new Exception("Something went wrong in SingleCell.cs!");

    }
}