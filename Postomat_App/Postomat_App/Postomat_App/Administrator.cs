namespace Postomat_App;

public static class Administrator
{
    public static void FillCell(int identifier, int size, string description)
    {
        Order newOrder;
        if (description == "Description...") description = "";
        newOrder = description == "" ? new Order(identifier, size) : new Order(identifier, size, description);
            
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