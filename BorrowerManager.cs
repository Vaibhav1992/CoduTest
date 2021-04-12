using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using The_Ledger_Co.DataAccessLayer.Models;

namespace The_Ledger_Co
{
    public class BorrowerManager
    {
        private static List<Borrower> Borrowers { get; set; } = new List<Borrower>();

        public static void AddBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        public static Borrower GetBorrower(string bankName, string borrowerName)
        {
            return Borrowers.First(x => string.Equals(x.Name, borrowerName, StringComparison.OrdinalIgnoreCase) && string.Equals(x.BankName, bankName, StringComparison.OrdinalIgnoreCase));

        }
    }
}
