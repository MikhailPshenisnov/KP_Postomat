using System;

namespace Postomat_App;

// Класс для объекта заказа, объект имеет отличительный номер, размер необходимой ячейки и описание
public class Order
{
    public int Identifier { get; }
    public SizeEnum Size { get; }

    public string Receiver { get; private set; }

    private string Description { get; }

    public Order(int identifier, string receiver, SizeEnum size = SizeEnum.Medium, string description = "No description")
    {
        if (identifier < 0) throw new Exception("Less than zero!");
        Identifier = identifier;

        if (Enum.IsDefined(typeof(SizeEnum), size))
        {
            Size = size;
        }
        else
        {
            throw new Exception("Wrong size!");
        }
        
        Description = description;

        Receiver = receiver;
    }
        
    // Для записи в файл с ячейками часто нужна такая запись заказа и так можно представить его в виде строки
    public string GetOrderString()
    {
        return $"{Identifier},{(int)Size},{Description},{Receiver}";
    }
}