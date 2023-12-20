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
        Container[index].SetContent(order);
    }

    public void AddOrderToCell(int cellIdentifier, Order order)
    {
        foreach (var cell in Container)
        {
            if (cell.Identifier == cellIdentifier)
            {
                cell.AddOrder(order);
            }
        }
    }
    
    public int FindCellByOrderNumber(int orderNumber)
    {
        foreach (var cell in Container)
        {
            if (Convert.ToBoolean(cell.GetOccupancyInformation()))
            {
                if (cell.GetOrderIdentifier()[0] == orderNumber)
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
                cell.ClearCell();
            }
        }
    }

    public List<List<string>> GetDataForCsv()
    {
        var data = new List<List<string>>();

        foreach (var cell in Container)
        {
            var orderString = Convert.ToBoolean(cell.GetOccupancyInformation()) ? 
                cell.Content!.GetOrderString() : 
                "";
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
            if (!Convert.ToBoolean(cell.GetOccupancyInformation()) && (int)cell.Size >= (int)order.Size)
            {
                return cell.Identifier;
            }
        }

        throw new Exception("There is no any suitable cell!");
    }
}