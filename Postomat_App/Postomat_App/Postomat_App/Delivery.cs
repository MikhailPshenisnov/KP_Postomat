using System;

namespace Postomat_App;

// Класс используемый как библиотека для функционала курьера
public static class Delivery
{
    // Используя функции Postomat заполняет пустую ячейку заказом или обрабатывает ошибку
    // (Имитирует доставку заказа в постомат)
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