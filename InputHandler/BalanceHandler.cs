using System;

namespace The_Ledger_Co.InputHandler
{
    class BalanceHandler : IInputHandler
    {
        public void HandleRequest(string[] commandInput)
        {
            var borrower = BorrowerManager.GetBorrower(commandInput[1], commandInput[2]);
            borrower.CheckBalance(int.Parse(commandInput[3]));
        }
    }
}
