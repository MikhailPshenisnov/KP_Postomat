using System;

namespace Postomat_App;

public static class Delivery
{
    public static void AddOrderToCell(Order order)
    {
        foreach (var cell in Postomat.PostomatCells)
        {
            if (cell.Content is null && cell.Size >= order.Size)
            {
                Postomat.AddOrderToCell(cell.Identifier, order);
                return;
            }
        }

        throw new Exception("There are no free suitable cells!");
    }
}