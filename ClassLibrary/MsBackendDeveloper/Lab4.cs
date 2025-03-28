using System;

namespace ClassLibrary.MsBackendDeveloper;

public static class Lab4
{
    /*
    - Declare a var to store age
    - Prompt the  user to enter his age
    - Use if..else to check if user 18 or older
    - Write "You are /are not eligible"
    */
    public static void CheckEligibleToVote()
    {
        int age;

        Console.WriteLine("Enter your age: ");

        age = int.Parse(Console.ReadLine() ?? "0");
        if (age >= 18)
            Console.WriteLine("You are eligible");
        else 
            Console.WriteLine("You are not eligible");
    }

    /*
    -Declare a string variable string mode to store the user's travel mode.
    -Prompt the user to select a mode using Console.WriteLine and capture the input using Console.ReadLine().
    - Use a switch statement to determine which message to print:
    - If the user selects "Bus," print "Booking a bus ticket."
    - If the user selects "Train," print "Booking a train ticket."
    - If the user selects "Flight," print "Booking a flight ticket."
    -Include a default case for invalid inputs with the message "Invalid selection. Please choose Bus, Train, or Flight."*/
    public static void DetermineTransportationMode()
    {
        Console.WriteLine("Enter your travel modes: Bus, Train or Flight: ");

        string mode = Console.ReadLine() ?? "";
        switch (mode)
        {
            case "Bus": 
                Console.WriteLine("Booking a bus ticket."); break;
            case "Train": 
                Console.WriteLine("Booking a train ticket."); break;
            case "Flight": 
                Console.WriteLine("Booking a flight ticket."); break;
            default:
                Console.WriteLine("Invalid selection. Please choose Bus, Train, or Flight."); break;
        }

    }

    /*You are developing a bank account management system. The program must manage different 
    types of bank accounts and apply the correct fees or interest rates based on the account type:

    Savings Account: Apply a 2% interest rate.
    Checking Account: Apply a $10 monthly fee.
    Business Account: Apply a 1% interest rate and a $20 monthly fee.
    For all other account types, display an error message.*/
    public static void ApplyFeeOrInterestRate()
    {
        Console.WriteLine("Enter your bank account type: Savings, Checking or Business: ");
        var account = Console.ReadLine();

        switch (account)
        {
            case "Savings":  Console.WriteLine("Apply a 2% interest rate");
            break;
            case "Checking":  Console.WriteLine("Apply a $10 monthly fee");
            break;
            case "Business":  Console.WriteLine("Apply a 1% interest rate and a $20 monthly fee");
            break;
            default: Console.WriteLine("Wrong account type");
            break;
        }
    }

    /// <summary>
    /// Print all numbers from array [1..5]
    /// </summary>
    public static void ForLoop()
    {
        int[] numbers = [1, 2, 3, 4, 5];
        for (var i=0; i < numbers.Length; i++)
            Console.WriteLine(numbers[i]);
    }

    /// <summary>
    /// Input number from user. Check if it is even and in the range [1, 10] then write and exit
    /// </summary>
    public static void DoWhile()
    {
        int input;
        do 
        {
            input = int.Parse(Console.ReadLine() ?? "0");
        }
        while (input < 1 || 10 < input || input % 2 == 1);
        Console.WriteLine("Number is int [1, 10] and is even: " + input);
    } 
}
