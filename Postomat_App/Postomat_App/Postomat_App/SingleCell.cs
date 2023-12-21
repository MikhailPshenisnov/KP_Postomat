using System;
using System.Collections.Generic;

namespace Postomat_App;

// Класс реализующий функционал одиночной ячейки
public class SingleCell : Cell
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

    // Очистка ячейки от заказа
    public override void ClearCell()
    {
        SetContent(null);
    }

    // Установка значений для заказа
    public override void SetContent(Order order, Order extraOrder = null)
    {
        // Проверка на второй заказ
        if (extraOrder is not null) throw new Exception("A single cell cannot accept a second order!");
        
        Content = order;
    }

    // Добавление заказа
    public override void AddOrder(Order order)
    {
        switch (GetOccupancyInformation())
        {
            case 0:
                SetContent(order);
                break;
            case 1:
                throw new Exception("The cells are already filled!");
        }
    }

    // Получение информации о заполненности ячейки
    public override int GetOccupancyInformation()
    {
        return Content == null ? 0 : 1;
    }

    // Получение списка идентификаторов заказов
    // (в первом слоте будет лежать идентификатор заказа, а второй для данного класса всегда null)
    public override List<int?> GetOrderIdentifier()
    {
        if (Convert.ToBoolean(GetOccupancyInformation()))
        {
            return new List<int?> { Content!.Identifier, null };
        }

        throw new Exception("Something went wrong in SingleCell.cs!");
    }
}