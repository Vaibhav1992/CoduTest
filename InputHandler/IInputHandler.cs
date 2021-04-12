using System.Collections.Generic;
using System.Text;

namespace The_Ledger_Co.InputHandler
{
    interface IInputHandler
    {
        public void HandleRequest(string[] request);
    }
}
