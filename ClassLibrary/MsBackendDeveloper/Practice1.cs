using System;
using System.Reflection.PortableExecutable;

namespace ClassLibrary.MsBackendDeveloper;

public static class Practice1
{
/*
Start
Create variable sum and set it to 0
For each number in the array
    Add number to sum
End For
Display the value of variable sum to user
End */
    public static void CalculateSum()
    {
        int[] array = [1, 2, 3, 4, 5];

        var sum = 0; 
        foreach (var i in array)
            sum += i;

        Console.WriteLine(sum);
    }

/*
Start
Create variable vowelCount and set to 0
For each character in the string
    If character is a vowel
        Add 1 to vowelCount
End For
Print vowelCount
End */
    public static void CalculateVowels()
    {
        var chars = "Laid ioqw diolakdj lkanf bkjas";
        char[] vowels = ['a', 'e', 'i', 'o', 'u'];

        var vowelCount = 0;
        foreach (var x in chars)
            if (chars.Contains(x))
                vowelCount += 1;

        Console.WriteLine(vowelCount);
    }
}
