using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using The_Ledger_Co.DataAccessLayer.Models;
using The_Ledger_Co.InputHandler;

namespace The_Ledger_Co
{
    public class TextInputProcessor
    {
        static Dictionary<string, IInputHandler> handlers = new Dictionary<string, IInputHandler>()
        {
            { "LOAN",new LoadHandler() },
            { "PAYMENT",new PaymentHandler() },
            { "BALANCE",new BalanceHandler() }
        };

        public void Process(string inputFilePath)
        {
            var inputs = File.ReadAllLines(inputFilePath);
            foreach (var input in inputs)
            {
                var commandInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                handlers[commandInput[0]].HandleRequest(commandInput);
            }
        }

    }
}
