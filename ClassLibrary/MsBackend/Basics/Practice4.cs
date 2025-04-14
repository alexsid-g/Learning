namespace ClassLibrary.MsBackend.Basics;

public static class Practice4
{
/*
Define an array named scores containing the integers 85, 90, 78, 92, and 88.
Use a for loop to iterate over each element in the array and calculate the total score.
Print the total score using Console.WriteLine(). */
    public static void For()
    {
        int[] array = [85, 90, 78, 92,  88];

        var sum = 0; 
        for (var i=0; i < array.Length; i++)
            sum += array[i];

        Console.WriteLine(sum);
    }

    /// <summary>
    /// Create a program that calculates the factorial of a given number using a while loop. 
    // The program should ask the user for an integer and then calculate its factorial.
    /// </summary>
    public static void While()
    {
        Console.WriteLine("Enter number for factorial:");

        var number = int.Parse(Console.ReadLine() ?? "-1");

        var result = 1;
        while (number > 0)
        {
            result *= number;
            number--;
        }

        Console.WriteLine($"Factorial is: {result}");
    }

    /// <summary>
    /// Write a program that uses a for loop with an if-else structure to check 
    // if each student's score meets the passing criteria. 
    // A student passes if their score is 50 or above..
    /// </summary>
    public static void ForWithIf()
    {
        int[] studentScores = [45, 60, 72, 38, 55];

        for (var i=0; i < studentScores.Length; i++)
            if (studentScores[i] >= 50)
                Console.WriteLine(studentScores[i] + " - Pass");
            else 
                Console.WriteLine(studentScores[i] + " - Fail");
    }

    /// <summary>
    /// Write a program that uses a for loop with an if-else structure to check 
    // if each student's score meets the passing criteria. 
    // A student passes if their score is 50 or above..
    /// </summary>
    public static void ForWithSwitch()
    {
        string[] weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];

        for (var i=0; i < weekDays.Length; i++)
            switch (weekDays[i])
            {
                case "Monday": Console.WriteLine("Team Meeting."); break;
                case "Tuesday": Console.WriteLine("Code Review."); break;
                case "Wednesday": Console.WriteLine("Development."); break;
                case "Thursday": Console.WriteLine("Testing."); break;
                case "Friday": Console.WriteLine("Deployment."); break;
            }
    }

}
