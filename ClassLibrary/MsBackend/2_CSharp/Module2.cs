public class Module2
{
    // Method to calculate the final price after a discount
    public static double ApplyDiscount(double price, double discountPercentage)
    {
        return price * (1 - discountPercentage / 100.0);
    }

    public static int FindMax(int[] numbers)
    {
        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    class Calculator 
    {
        public int number1;
        public int number2;
        public int Add() => number1 + number2;
    }

    class NumberDisplay
    {
        public void DisplayNumbers()
        {
            for (var i=1; i <= 10; i++)
                Console.WriteLine(i);
        }
    }

    class UserInput
    {
        public void GreetUser()
        {
            Console.WriteLine("Enter your name");

            var name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);
        }
    }

    public static void Main()
    {
        double finalPrice = ApplyDiscount(1000, 15);
        Console.WriteLine("The final price is: " + finalPrice);

        int[] myNumbers = { -5, -10, -3, -8, -2 };
        int maxNumber = FindMax(myNumbers);
        Console.WriteLine("The maximum number is: " + maxNumber);

        var calculator = new Calculator();
        calculator.number1 = 10;
        calculator.number2 = 11;
        Console.WriteLine("Calculator.Add result is: " + calculator.Add());

        var display = new NumberDisplay();
        display.DisplayNumbers();

        var input = new UserInput();
        input.GreetUser();
    }
}

