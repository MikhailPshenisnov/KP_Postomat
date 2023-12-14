using System;

namespace Postomat_App
{
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
        
        public string GetOrderString()
        {
            return $"{Identifier},{Size},{Description}";
        }
    }
}