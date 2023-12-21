using System;
using System.Collections.Generic;

namespace Postomat_App;

// Обобщенный класс для хранения ячеек
public class CustomСontainer<T> where T : Cell
{
    private List<T> Container { get; set; } = new(); // Список для хранения ячеек

    // Очистка информации о ячейках
    public void ClearCells()
    {
        Container = new List<T>();
    }

    // Добавление ячейки в список
    public void AddCell(T cell)
    {
        Container.Add(cell);
    }

    // Улаоение ячейки по идентификатору ячейки
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

    // Установка значения ячейки по индексу ячейки в списке ячеек
    public void SetCellContent(int index, Order order, Order extraOrder = null)
    {
        Container[index].SetContent(order, extraOrder);
    }

    // Добавление значения в ячейку по идентификатору ячейки
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

    // Поиск идентификатора ячейки с нужным заказом по номеру заказа
    public int FindCellByOrderNumber(int orderNumber)
    {
        foreach (var cell in Container)
        {
            if (cell.GetType() == typeof(SingleCell))
            {
                if (Convert.ToBoolean(cell.GetOccupancyInformation()) && cell.GetOrderIdentifier()[0] == orderNumber)
                {
                    return cell.Identifier;
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

    // Очистка ячейки по идентификатору ячейки
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

    // Создание форматированных данных для последующей их записи в файл
    public List<List<string>> GetDataForCsv()
    {
        var data = new List<List<string>>();
        var orderString = "";

        foreach (var cell in Container)
        {
            if (cell.GetType() == typeof(SingleCell)) // Обработка для одиночных ячеек
            {
                orderString = Convert.ToBoolean(cell.GetOccupancyInformation()) ? cell.Content!.GetOrderString() : "";
                data.Add(new List<string>
                {
                    cell.Identifier.ToString(),
                    ((int)cell.Size).ToString(),
                    orderString
                });
            }
            else if (cell.GetType() == typeof(DoubleCell)) // Обработка для двойных ячеек
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

    // Поиск подходящей для заказа ячейки
    public int FindSuitableCell(Order order)
    {
        // Сначала идет перебор по двойным ячейкам, где лежит 1 заказ, проверяется на соответствие получателя и
        // в случае успеха заказы объединяются
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

        // Потом идет перебор по всем пустым ячейкам и подбирается подходящая по размеру
        foreach (var cell in Container)
        {
            if (!Convert.ToBoolean(cell.GetOccupancyInformation()) && cell.Size >= order.Size)
            {
                return cell.Identifier;
            }
        }

        // Если ячеек не нашлось возникнет ошибка
        throw new Exception("There is no any suitable cell!");
    }
}