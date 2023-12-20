namespace Postomat_App;

public static class Administrator
{
    public static void FillCell(int identifier, string receiver, int size, string description)
    {
        if (description == "Description...") description = "";
        var newOrder = description == "" ? 
            new Order(identifier, receiver, (SizeEnum)size) : 
            new Order(identifier, receiver, (SizeEnum)size, description);
            
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