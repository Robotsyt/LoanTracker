// CEIS209 Course Project
// Module 7-8
// Exceptions and File Processing
// Topics: Exceptions and File Processing

using System.Text.Json;
using ConsoleApp1; // Ensure this namespace is included


// Define constants
const string userName = "First Last"; // Replace with your name
const string userCourseNumber = "CEIS209";
const string userSession = "Month Year"; // Replace with the session month and year



// Declare Lists for storing loan information
List<ILoan> loans = new List<ILoan>();


// Call Main Menu function, passing list by reference
MainMenu(ref loans);

// Main Menu Function - receives lists by reference
static void MainMenu(ref List<ILoan> loans)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("\u001b[34m" + userName + " - " + userCourseNumber + " - " + userSession + "\u001b[0m");
        Console.WriteLine(DateTime.Now);
        Console.WriteLine("===| Main Menu |===");
        Console.WriteLine("1. Add Loan");
        Console.WriteLine("2. Delete Loan");
        Console.WriteLine("3. Display Loan Details");
        Console.WriteLine("4. Report");
        Console.WriteLine("5. Save to File");
        Console.WriteLine("6. Load from File");
        Console.WriteLine("7. Exit");
        Console.Write("Select an option: ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                // Add Loan
                LoanAdd(ref loans);
                break;
            case "2":
                // Delete Loan
                LoanDelete(ref loans);
                break;
            case "3":
                // Display loan details
                LoanDetails(ref loans);
                break;
            case "4":
                // Display loan details and amortization schedule
                LoanReport(ref loans);
                break;
            case "5":
                // Save to file
                LoanSave(ref loans);
                break;
            case "6":
                // Load from file
                LoanLoad(ref loans);
                break;
            case "7":
                Console.WriteLine("Exiting ...");
                return;

            default:
                Console.WriteLine("Invalid selection. Please try again.");
                Console.WriteLine("Press Enter to continue ...");
                Console.ReadLine();
                break;
        }
    }
}



static void LoanAdd(ref List<ILoan> loans)
{
    // Declare new loan variable
    ILoan newLoan = null;
    
    // Get Loan Type
    Console.Clear();
    while (true)
    {
        Console.WriteLine("Loan Type ---");
        Console.WriteLine("1. Installment Loan");
        Console.WriteLine("2. Balloon Loan");
        Console.Write("Select a loan type: ");
        string input = Console.ReadLine();
        
        // Declare variable for new loan based on user selection
        if (input == "1")
        {
            // Add Installment Loan
            newLoan = new InstallmentLoan();
            break;
        }
        else if (input == "2")
        {
            // Add Balloon Loan
            newLoan = new BalloonLoan();
            break;
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
    
    
    

    // Get Lender Information
    Console.Clear();
    Console.WriteLine("Lender Information ---");
    Console.Write("Please enter the name of the lender (Example \"ABC Bank\"): ");
    newLoan.Lender.Name = Console.ReadLine();
    Console.Write("Please enter the street address of the lender: ");
    newLoan.Lender.Address = Console.ReadLine();
    Console.Write("Please enter the city of the lender: ");
    newLoan.Lender.City = Console.ReadLine();
    Console.Write("Please enter the state of the lender: ");
    newLoan.Lender.State = Console.ReadLine();
    Console.Write("Please enter the ZIP code of the lender: ");
    newLoan.Lender.Zip = Console.ReadLine();
    Console.Write("Please enter the phone number of the lender: ");
    newLoan.Lender.Phone = Console.ReadLine();
    Console.Write("Please enter the email address of the lender: ");
    newLoan.Lender.Email = Console.ReadLine();


    // Get Loan Information
    Console.Clear();
    Console.WriteLine("Loan Information ---");
    Console.Write("Please enter the purpose of the loan (Example \"Pickup Truck 1\"):");
    newLoan.Purpose = Console.ReadLine();
    Console.Write("Please enter the account number of the loan (Example \"123456\"):");
    newLoan.AccountNumber = Console.ReadLine();
    string currentDate = DateTime.Now.ToString("M/d/yyyy");
    Console.Write("Please enter the initiation date of the loan (Enter for " + currentDate + "):");
    string loanDateInput = Console.ReadLine();
    newLoan.Date = loanDateInput == "" ? DateTime.Now : Convert.ToDateTime(loanDateInput);
    while (true)
    {
        Console.Write("Please enter the loan amount (Example \"75000\"): ");
        newLoan.Amount = Convert.ToDecimal(Console.ReadLine());
        if (newLoan.Amount > 0 && newLoan.Amount <= 250000)
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a value greater than zero and less than or equal to 250,000.");
        }   
        
    }
    
    while (true)
    {
        Console.Write("Please enter the interest rate (Example: 5.25 for 5.25%):");
        newLoan.InterestRate = Convert.ToDecimal(Console.ReadLine());
        if (newLoan.InterestRate > 0 && newLoan.InterestRate <= 25)
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a value greater than zero and less than or equal to 25.");
        }
    }
    
    while (true)
    {
        Console.Write("Please enter the loan term in years:");
        newLoan.Term = Convert.ToInt16(Console.ReadLine());
        if (newLoan.Term > 0 && newLoan.Term <= 30)
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a value greater than zero and less than or equal to 30.");
        }
    }
    
    // Add loan to list
    loans.Add(newLoan);

    Console.WriteLine("Loan added successfully.");
    Console.WriteLine("Press Enter to continue ...");
    Console.ReadLine();

}

// Delete Loan Function
static void LoanDelete(ref List<ILoan> loans)
{
    // List loans for user to select
    for (int i = 0; i < loans.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + loans[i].Lender.Name + " - " + loans[i].Purpose + " - " + loans[i].Amount.ToString("C"));
    }
    // Get user selection
    Console.Write("Select a loan to delete: ");
    int selection = Convert.ToInt16(Console.ReadLine());
    // Remove loan from list
    loans.RemoveAt(selection - 1);
    Console.WriteLine("Loan deleted successfully.");
    Console.WriteLine("Press Enter to continue ...");
    Console.ReadLine();
}

// Display Loan Details Function
static void LoanDetails(ref List<ILoan> loans)
{
    // Display Loan Details for each loan using a loop
    Console.Clear();
    Console.WriteLine("Loan Details ---");
    // Print column headings
    Console.WriteLine("{0,10} {1,15} {2,15} {3,20} {4,15} {5,15} {6,20} {7,20} {8,20}",
        "Loan", "Provider", "Purpose", "Account Number", "Date", "Amount", "Interest Rate", "Term", "Monthly Payment");

    // Print a separator line
    Console.WriteLine(new string('-', 170));

    // Print loan details in columns
    for (int i = 0; i < loans.Count; i++)
    {
        Console.WriteLine("{0,10} {1,15} {2,15} {3,20} {4,15} {5,15} {6,20} {7,20} {8,20}", 
            "Loan " + (i + 1), 
            loans[i].Lender.Name, 
            loans[i].Purpose, 
            loans[i].AccountNumber, 
            loans[i].Date.ToString("M/d/yyyy"),
            loans[i].Amount.ToString("C"),
            loans[i].InterestRate.ToString(),
            loans[i].Term + " years",
            loans[i].Payment.ToString("C"));
    }
    Console.WriteLine();
    Console.WriteLine("Press Enter to continue ...");
    Console.ReadLine();
}

// Display Loan Report Function
static void LoanReport(ref List<ILoan> loans)
{
    Console.Clear();
    // List loans for user to select
    for (int i = 0; i < loans.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + loans[i].Lender.Name + " - " + loans[i].Purpose + " - " + loans[i].Amount.ToString("C"));
    }
    // Get user selection
    Console.Write("Select a loan to display: ");
    int selection = Convert.ToInt16(Console.ReadLine());
    // Display loan details and amortization schedule
    Console.WriteLine("Loan Report ---");
    Console.WriteLine("Loan Details ---");
    Console.WriteLine(loans[selection - 1].ToString());
    Console.WriteLine();
    Console.WriteLine("Amortization Schedule ---");
    Console.WriteLine(loans[selection - 1].Amortize());
    Console.WriteLine();
    Console.WriteLine("Press Enter to continue ...");
    Console.ReadLine();

}

// Save Loan Information to File Function
static void LoanSave(ref List<ILoan> loans)
{
    Console.Clear();
    //Save loan information to file loans.csv
    try
    {
        foreach(ILoan loan in loans)
        {
            // Get loan type
            string loanType = loan.GetType().Name;
            // Save loanType and loan inforamtion to .csv file
            string record = loanType + "," + loan.Lender.Name + "," + loan.Lender.Address + "," + loan.Lender.City + "," + loan.Lender.State + "," + loan.Lender.Zip + "," + loan.Lender.Phone + "," + loan.Lender.Email + "," + loan.Purpose + "," + loan.AccountNumber + "," + loan.Date.ToString("M/d/yyyy") + "," + loan.Amount + "," + loan.InterestRate + "," + loan.Term;
            File.AppendAllText("loans.csv", record + Environment.NewLine);
        }
        Console.WriteLine("Loan information saved to file");
        Console.WriteLine("Press Enter to continue ...");
        Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while saving the file");
        Console.WriteLine("Error: " + ex.Message);
        Console.ReadLine();
    }
}
//Load Loan from file
static void LoanLoad(ref List<ILoan> loans)
{
    Console.Clear();
    try
    {
        string[] records = File.ReadAllLines("loans.csv");
        foreach (string record in records)
        {
            string[] fields = record.Split(',');
            ILoan newLoan = null;
            if (fields[0] == "InstallmentLoan")
            {
                newLoan = new InstallmentLoan();
            }
            else if (fields[0] == "BalloonLoan")
            {
                newLoan = new BalloonLoan();
            }
            newLoan.Lender.Name = fields[1];
            newLoan.Lender.Address = fields[2];
            newLoan.Lender.City = fields[3];
            newLoan.Lender.State = fields[4];
            newLoan.Lender.Zip = fields[5];
            newLoan.Lender.Phone = fields[6];
            newLoan.Lender.Email = fields[7];
            newLoan.Purpose = fields[8];
            newLoan.AccountNumber = fields[9];
            newLoan.Date = Convert.ToDateTime(fields[10]);
            newLoan.Amount = Convert.ToDecimal(fields[11]);
            newLoan.InterestRate = Convert.ToDecimal(fields[12]);
            newLoan.Term = Convert.ToInt16(fields[13]);
            loans.Add(newLoan);
        }
        Console.WriteLine("Loan information loaded from file.");
        Console.WriteLine("Press Enter to continue ...");
        Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while loading the file");
        Console.WriteLine("Error: " + ex.Message);
        Console.WriteLine("Press Enter to Continue ...");
        Console.ReadLine();
    }
}
// End of Program
