using System;
using The_Ledger_Co.DataAccessLayer.Models;

namespace The_Ledger_Co
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new TextInputProcessor();
            inputHandler.Process(args[0]);
        }
    }
}
