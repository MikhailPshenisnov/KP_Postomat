using System;

namespace Postomat_App
{
    public static class Customer
    {
        public static void ReceiveOrderByNumber(int number)
        {
            if (number < 0) throw new Exception("Less than zero");
            var cellIdentidier = Postomat.FindCellByOrderNumber(number);
            Postomat.ClearCellByIdentifier(cellIdentidier);
        }
    }
}