using System;

namespace Postomat_App;

// Статический класс используемый как библиотека для функций используемых администратором
public static class Administrator
{
    // Заполнение ячейки заказом, аналог доставки заказа, но для администратора
    public static void FillCell(int identifier, string receiver, int size, string description)
    {
        if (description == "Description...") description = "";
        if (receiver is "" or "Receiver...") throw new Exception("Incorrect receiver!");
        var newOrder = description == ""
            ? new Order(identifier, receiver, (SizeEnum)size)
            : new Order(identifier, receiver, (SizeEnum)size, description);

        Delivery.AddOrderToCell(newOrder);
    }

    // Очистка ячейки от заказа, аналог получения заказа, но для администратора
    public static void ClearCell(int identifier)
    {
        Customer.ReceiveOrderByNumber(identifier);
    }

    // Создание ячейке по размеру
    public static void CreateCell(string identifier)
    {
        Postomat.AddCell(identifier);
    }

    // Удаление ячейки по идентификатору ячейки
    public static void DeleteCell(int identifier)
    {
        Postomat.DeleteCell(identifier);
    }
}