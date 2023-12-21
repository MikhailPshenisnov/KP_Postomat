namespace Postomat_App;

// Класс используемый как библиотека для функционала курьера
public static class Delivery
{
    // Доставка заказа в ячейку
    public static void AddOrderToCell(Order order)
    {
        var identifier = Postomat.FindSuitableCell(order);
        Postomat.AddOrderToCell(identifier, order);
    }
}