//Define Balloon Loan Class
//For loans that have interest only monthly payments, with a final balloon payment of the remaining principal.

using System;

namespace ConsoleApp1
{
    public class BalloonLoan : ILoan
    {
        //Fields
        private Lender _lender;
        private string _purpose;
        private string _accountNumber;
        private DateTime _date;
        private decimal _amount;
        private decimal _interestRate;
        private int _term;
        


        //Properties
        public Lender Lender
        {
            get { return _lender; }
            set { _lender = value; }
        }
        
        
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public decimal InterestRate
        {
            get { return _interestRate; }
            set { _interestRate = value; }
        }

        public decimal MonthlyInterestRate
        {
            get { return _interestRate / 1200; }
        }

        public int Term
        {
            get { return _term; }
            set { _term = value; }
        }

        public int NumberOfPayments
        {
            get { return _term * 12; }
        }

        public decimal Payment
        {
            get {return _amount * (this.MonthlyInterestRate * (decimal)Math.Pow((double)(1 + this.MonthlyInterestRate), (double)this.NumberOfPayments)) / ((decimal)Math.Pow((double)(1 + this.MonthlyInterestRate), (double)this.NumberOfPayments) - 1);}
        }



        //Constructors
        public BalloonLoan()
        {
            _lender = new Lender();
            _purpose = "";
            _accountNumber = "";
            _date = DateTime.Now;
            _amount = 0;
            _interestRate = 0;
            _term = 0;
        }

        public BalloonLoan(Lender lender, string purpose, string accountNumber, DateTime date, decimal amount, decimal interestRate, int term)
        {
            _lender = lender;
            _purpose = purpose;
            _accountNumber = accountNumber;
            _date = date;
            _amount = amount;
            _interestRate = interestRate;
            _term = term;
        }

        //Methods
        public override string ToString()
        {
            return "Lender: " + _lender.Name + "\n" +
                   "Purpose: " + _purpose + "\n" +
                   "Account Number: " + _accountNumber + "\n" +
                   "Date: " + _date + "\n" +
                   "Amount: " + _amount + "\n" +
                   "Interest Rate: " + _interestRate + "\n" +
                   "Term: " + _term + "\n" +
                   "Monthly Payment: " + Payment.ToString("C");
        }

        

        public string Amortize()
        {
            string amortizationSchedule = "Amortization Schedule for " + _lender.Name + " Loan\n\n";
            amortizationSchedule += "Payment Number\tPayment Amount\tInterest\tPrincipal\tBalance\n";
            
            for (int i = 1; i <= NumberOfPayments; i++)
            {
                amortizationSchedule += i + "\t\t" + Payment.ToString("C") + "\t\t" + Payment.ToString("C") + "\t\t" + "$0.00" + "\t\t" + Amount.ToString("C") + "\n";
            }
            amortizationSchedule += "Balloon Payment: " + Amount.ToString("C");
            return amortizationSchedule;
        }
    }
}