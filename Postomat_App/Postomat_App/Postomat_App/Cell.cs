namespace Postomat_App
{
    public class Cell
    {
        private static int _counter = 0;

        public int Identifier { get; private set; }
        public int Size { get; private set; }
        
        public Order? Content { get; set; }

        public Cell(int size = 1)
        {
            Identifier = _counter++;
            
            if (size < 0)
            {
                size = 0;
            }
            else if (size > 2)
            {
                size = 2;
            }

            Size = size;

            Content = null;
        }
    }
}