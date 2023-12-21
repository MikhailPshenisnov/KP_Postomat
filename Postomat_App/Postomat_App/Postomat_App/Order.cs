using System;

namespace Postomat_App;

// Класс для заказа
public class Order
{
    public int Identifier { get; } // Идентификатор
    public SizeEnum Size { get; } // Размер

    public string Receiver { get; } // Получатель

    private string Description { get; } // Описание

    public Order(int identifier, string receiver, SizeEnum size = SizeEnum.Medium,
        string description = "No description")
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