
using System;
using ConsoleApp1;

//Create Interface for Loans

namespace ConsoleApp1
{
    public interface ILoan
    {
        Lender Lender { get; set; }
        string Purpose { get; set; }
        string AccountNumber { get; set; }
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        decimal InterestRate { get; set; }
        int Term { get; set; } // Term in months
        decimal Payment { get; }

        string Amortize();
        
    }
}