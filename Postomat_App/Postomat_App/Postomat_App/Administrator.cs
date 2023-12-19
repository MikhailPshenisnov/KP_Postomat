namespace Postomat_App;

public static class Administrator
{
    public static void FillCell(int identifier, int size, string description)
    {
        if (description == "Description...") description = "";
        var newOrder = description == "" ? new Order(identifier, "ЗАМЕНИ МЕНЯ", size) : new Order(identifier, "ЗАМЕНИ МЕНЯ", size, description);
            
        Delivery.AddOrderToCell(newOrder);
    }

    public static void ClearCell(int identifier)
    {
        Customer.ReceiveOrderByNumber(identifier);
    }
    
    public static void CreateCell(int identifier)
    {
        Postomat.AddCell(identifier);
    }

    public static void DeleteCell(int identifier)
    {
        Postomat.DeleteCell(identifier);
    }
}