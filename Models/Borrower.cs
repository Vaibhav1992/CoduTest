using System;
using System.Collections.Generic;
using System.Text;

namespace The_Ledger_Co.DataAccessLayer.Models
{
    public class Borrower
    {
        public string Name { get; }
        public string BankName { get; }
        public decimal LoanAmount { get; }
        public decimal TotalAmount { get; }

        decimal _emiAmount;
        int _noOfEmis;
        int _years;
        decimal _interestRate;
        List<Balance> BalanceSheet { get; set; }
        public int NoOfEMIs { private set; private get; }

        public Borrower(string name, string bankName, decimal loanAmount, int years, decimal interestRate)
        {
            Name = name;
            BankName = bankName;
            LoanAmount = loanAmount;
            _years = years;
            _interestRate = interestRate;
            TotalAmount = Math.Ceiling((loanAmount + (loanAmount * years * interestRate / 100)));
            _emiAmount = Math.Ceiling(TotalAmount / (years * 12));
            NoOfEMIs = years * 12;
            BalanceSheet = new List<Balance>();
            for (int i = 0; i < NoOfEMIs; i++)
            {
                BalanceSheet.Add(new Balance() { AmountPaid = i * _emiAmount, EMIRemaning = NoOfEMIs - i });
            }
        }

        public void Payment(decimal amount, int afterEmi)
        {
            BalanceSheet[afterEmi].AmountPaid = BalanceSheet[afterEmi].AmountPaid + amount;
            int emis_left = (int)Math.Ceiling((TotalAmount - BalanceSheet[afterEmi].AmountPaid) / _emiAmount);
            BalanceSheet[afterEmi].EMIRemaning = emis_left;
            for (int i = afterEmi + 1, j = 1; i < afterEmi + 1 + emis_left; i++, j++)
            {
                if (BalanceSheet[i - 1].AmountPaid + _emiAmount < LoanAmount)
                    BalanceSheet[i] = new Balance() { AmountPaid = BalanceSheet[i - 1].AmountPaid + _emiAmount, EMIRemaning = emis_left - j };
                else
                {
                    BalanceSheet[i] = new Balance() { AmountPaid = LoanAmount, EMIRemaning = 0 };
                }
            }
        }

        public void CheckBalance(int afterEmi)
        {
            Console.WriteLine($"{BankName} {Name} {Math.Ceiling(BalanceSheet[afterEmi].AmountPaid)} {BalanceSheet[afterEmi].EMIRemaning}");
        }

    }

    class Balance
    {
        public int EMIRemaning { get; set; }
        public decimal AmountPaid { get; set; }
    }


}
