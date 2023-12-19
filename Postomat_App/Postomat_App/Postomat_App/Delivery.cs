namespace Postomat_App;

// Класс используемый как библиотека для функционала курьера
public static class Delivery
{
    // Используя функции Postomat заполняет пустую ячейку заказом или обрабатывает ошибку
    // (Имитирует доставку заказа в постомат)
    public static void AddOrderToCell(Order order)
    {
        var identifier = Postomat.FindSuitableCell(order);
        Postomat.AddOrderToCell(identifier, order);
    }
}