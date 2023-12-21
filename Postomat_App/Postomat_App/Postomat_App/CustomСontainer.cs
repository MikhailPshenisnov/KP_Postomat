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
            if (cell.GetType() == typeof(SingleCell))
            {
                if (Convert.ToBoolean(cell.GetOccupancyInformation()))
                {
                    if (cell.GetOrderIdentifier()[0] == orderNumber)
                    {
                        return cell.Identifier;
                    }
                }
            }
            else if (cell.GetType() == typeof(DoubleCell))
            {
                if (cell.GetOccupancyInformation() > 0 && cell.GetOrderIdentifier().Contains(orderNumber))
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
        var orderString = "";

        foreach (var cell in Container)
        {
            if (cell.GetType() == typeof(SingleCell))
            {
                orderString = Convert.ToBoolean(cell.GetOccupancyInformation()) ? 
                    cell.Content!.GetOrderString() : 
                    "";
                data.Add(new List<string>
                { 
                    cell.Identifier.ToString(),
                    ((int)cell.Size).ToString(), 
                    orderString
                });
            }
            else if (cell.GetType() == typeof(DoubleCell))
            {
                switch (cell.GetOccupancyInformation())
                {
                    case 0:
                        orderString = "|";
                        break;
                    case 1:
                        orderString = $"{cell.Content!.GetOrderString()}|";
                        break;
                    case 2:
                        orderString = $"|{(cell as DoubleCell)!.ExtraContent!.GetOrderString()}";
                        break;
                    case 3:
                        orderString = $"{cell.Content!.GetOrderString()}|" +
                                      $"{(cell as DoubleCell)!.ExtraContent!.GetOrderString()}";
                        break;
                }
                data.Add(new List<string>
                { 
                    cell.Identifier.ToString(),
                    (int)cell.Size + "d", 
                    orderString
                });
            }
            else
            {
                throw new Exception("Something went wrong with CustomContainer GetDataForCsv()!");
            }
        }
        
        return data;
    }

    public int FindSuitableCell(Order order)
    {
        foreach (var cell in Container)
        {
            if (cell.GetType() != typeof(DoubleCell)) continue;
            if (cell.Size < order.Size) continue;
            if (cell.GetOccupancyInformation() > 0 && cell.GetOccupancyInformation() < 3)
            {
                switch (cell.GetOccupancyInformation())
                {
                    case 1:
                        if (cell.Content!.Receiver == order.Receiver) 
                            return cell.Identifier;
                        break;
                    case 2:
                        if ((cell as DoubleCell)!.ExtraContent!.Receiver == order.Receiver) 
                            return cell.Identifier;
                        break;
                }
            }
        }
        
        foreach (var cell in Container)
        {
            if (!Convert.ToBoolean(cell.GetOccupancyInformation()) && cell.Size >= order.Size)
            {
                return cell.Identifier;
            }
        }

        throw new Exception("There is no any suitable cell!");
    }
}