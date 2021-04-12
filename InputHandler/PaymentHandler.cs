using System;

namespace The_Ledger_Co.InputHandler
{
    class PaymentHandler : IInputHandler

    {
        public void HandleRequest(string[] commandInput)
        {
            var borrower = BorrowerManager.GetBorrower(commandInput[1], commandInput[2]);
            borrower.Payment(decimal.Parse(commandInput[3]), int.Parse(commandInput[4]));
        }
    }
}
