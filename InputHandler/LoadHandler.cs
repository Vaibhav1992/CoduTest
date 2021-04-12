using The_Ledger_Co.DataAccessLayer.Models;

namespace The_Ledger_Co.InputHandler
{
    class LoadHandler : IInputHandler

    {
        public void HandleRequest(string[] commandInput)
        {
            BorrowerManager.AddBorrower(new Borrower(commandInput[2], commandInput[1], decimal.Parse(commandInput[3]), int.Parse(commandInput[4]), decimal.Parse(commandInput[5])));
        }
    }
}
