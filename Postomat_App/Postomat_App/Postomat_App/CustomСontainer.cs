using System;
using System.Collections.Generic;

namespace Postomat_App;

public class CustomСontainer<T> where T: Cell
{
    private List<T> Container { get; set; } = new();

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

    public void SetCellContent(int index, Order? order)
    {
        Container[index].Content = order;
    }

    public void AddOrderToCell(int cellIdentifier, Order order)
    {
        foreach (var cell in Container)
        {
            if (cell.Identifier == cellIdentifier)
            {
                cell.Content = order;
            }
        }
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
    
    public void ClearCellByIdentifier(int identifier)
    {
        foreach (var cell in Container)
        {
            if (cell.Identifier == identifier)
            {
                cell.Content = null;
            }
        }
    }

    public List<List<string>> GetDataForCsv()
    {
        var data = new List<List<string>>();

        foreach (var cell in Container)
        {
            var orderString = cell.Content is null ? "" : cell.Content.GetOrderString();
            data.Add(new List<string>
            { 
                cell.Identifier.ToString(),
                ((int)cell.Size).ToString(), 
                orderString
            });
        }

        return data;
    }

    public int FindSuitableCell(Order order)
    {
        foreach (var cell in Container)
        {
            if (cell.Content is null && cell.Size >= (int)order.Size)
            {
                return cell.Identifier;
            }
        }

        throw new Exception("There is no any suitable cell!");
    }
}