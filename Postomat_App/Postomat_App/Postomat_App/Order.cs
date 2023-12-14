using System;

namespace Postomat_App
{
    // Класс для объекта заказа, объект имеет отличительный номер, размер необходимой ячейки и описание
    public class Order
    {
        public int Identifier { get; private set; }
        public int Size { get; private set; }

        public string Description { get; set; }

        public Order(int identifier, int size = 1, string description = "No description")
        {
            if (identifier < 0) throw new Exception("Less than zero");
            Identifier = identifier;

            if (size < 0)
            {
                size = 0;
            }
            else if (size > 2)
            {
                size = 2;
            }

            Size = size;

            Description = description;
        }
        
        // Для записи в файл с ячейками часто нужна такая запись заказа и так можно представить его в виде строки
        public string GetOrderString()
        {
            return $"{Identifier},{Size},{Description}";
        }
    }
}