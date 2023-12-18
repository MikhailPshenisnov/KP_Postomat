using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Postomat_App;

public class CustomСontainer<T> where T: Cell
{
    public List<T> Container { get; set; } = new List<T>();

    public void ClearCells()
    {
        Container = new List<T>();
    }

    public void AddCell(T cell)
    {
        Container.Add(cell);
    }

    public void DeleteCell(int cellIdentifier)
    {
        for (var i = 0; i < Container.Count; i++)
        {
            if (Container[i].Identifier == cellIdentifier)
            {
                Container.Remove(Container[i]);
                return;
            }
        }
        throw new Exception("Wrong Index!");
    }
    
    public int FindCellByOrderNumber(int orderNumber)
    {
        foreach (var cell in Container)
        {
            if (cell.Content is not null)
            {
                if (cell.Content.Identifier == orderNumber)
                {
                    return cell.Identifier;
                }
            }
        }
        throw new Exception("Wrong order number");
    }
}