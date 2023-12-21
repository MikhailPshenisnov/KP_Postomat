using System;
using System.Collections.Generic;

namespace Postomat_App;

// Класс реализующий функционал двойной ячейки
public class DoubleCell : Cell
{
    // Хранилище второго заказа
    public Order ExtraContent { get; private set; }

    public DoubleCell(SizeEnum size = SizeEnum.Medium)
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
        ExtraContent = null;
    }

    // Очистка ячейки от заказов
    public override void ClearCell()
    {
        SetContent(null);
    }

    // Установка значений для 2 заказов
    public override void SetContent(Order order, Order extraOrder = null)
    {
        Content = order;
        ExtraContent = extraOrder;
    }

    // Добавление заказа в подходящий слот заказа
    public override void AddOrder(Order order)
    {
        switch (GetOccupancyInformation())
        {
            case 0: // Свободна
                SetContent(order);
                return;
            case 1: // Только первый заказ заполнен
                SetContent(Content, order);
                return;
            case 2: // Только второй заказ заполнен
                SetContent(order, ExtraContent);
                return;
            case 3: // Все заказы заполнены
                throw new Exception("The cells are already filled!");
        }

        throw new Exception("Something went wrong in DoubleCell.cs!");
    }

    // Получение информации о заполненности ячейки
    public override int GetOccupancyInformation()
    {
        return Content == null ? ExtraContent == null ? 0 : 2 : ExtraContent == null ? 1 : 3;
    }

    // Получение списка идентификаторов заказов
    public override List<int?> GetOrderIdentifier()
    {
        switch (GetOccupancyInformation())
        {
            case 0:
                return new List<int?> { null, null };
            case 1:
                return new List<int?> { Content!.Identifier, null };
            case 2:
                return new List<int?> { null, ExtraContent!.Identifier };
            case 3:
                return new List<int?> { Content!.Identifier, ExtraContent!.Identifier };
        }

        throw new Exception("Something went wrong in DoubleCell.cs!");
    }
}