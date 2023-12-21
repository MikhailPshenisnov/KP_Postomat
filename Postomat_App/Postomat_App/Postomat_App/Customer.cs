using System;

namespace Postomat_App;

// Статический класс используемый как библиотека для функций используемых посетителем
public static class Customer
{
    // Получение заказа по номеру
    public static void ReceiveOrderByNumber(int number)
    {
        if (number < 0) throw new Exception("Less than zero");
        var cellIdentifier = Postomat.FindCellByOrderNumber(number);
        Postomat.ClearCellByIdentifier(cellIdentifier);
    }
}