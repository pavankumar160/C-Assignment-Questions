using System;

public static class StringSearcher
{
    public static void FindOccurrences(string mainString, string searchString)
    {
        if (string.IsNullOrEmpty(mainString) || string.IsNullOrEmpty(searchString))
        {
            Console.WriteLine("Input strings cannot be null or empty.");
            return;
        }

        // Make both lowercase for case-insensitive comparison
        mainString = mainString.ToLower();
        mainString = mainString.TrimStart();
        searchString = searchString.ToLower();
        searchString = searchString.TrimStart();

        bool found = false;

        for (int i = 0; i <= mainString.Length - searchString.Length; i++)
        {
            int searchIndex = 0;
            bool isMatch = true;

            if (mainString[i] == searchString[searchIndex])
            {
                searchIndex = 1;

                for (int j = i + 1; searchIndex < searchString.Length && j < mainString.Length; j++)
                {
                    if (mainString[j] != searchString[searchIndex])
                    {
                        isMatch = false;
                        break;
                    }
                    searchIndex++;
                }

                if (isMatch && searchIndex == searchString.Length)
                {
                    Console.WriteLine($"The search string \"{searchString}\" found at index {i}");
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine($"The search string \"{searchString}\" was not found in the given string.");
        }
    }
}

public static class StringValidator
{
    public static bool IsAlphabetOnly(string input)
    {
        foreach (char c in input)
        {
            int ascii = (int)c;
            if (ascii != 32 && (ascii < 65 || ascii > 90) && (ascii < 97 || ascii > 122))
            {
                return false;
            }
        }
        return true;
    }
}


class Program
{
    /// <summary>
    /// This program takes two strings — `mainString` and `searchString` — and checks how many times 
    /// `searchString` appears in `mainString`. If found, the program returns the starting index of each occurrence.
    /// </summary>
    
    public static void Main()
    {
        bool continueProgram = true;

        while (continueProgram)
        {
            Console.WriteLine("Enter a valid String1:");
            string mainString = Console.ReadLine();

            if (!StringValidator.IsAlphabetOnly(mainString))
            {
                Console.WriteLine("The string should contain only alphabets; no numeric or special symbols are allowed.");
                goto RepeatPrompt; // Go to end menu
            }

            Console.WriteLine("Enter a valid String2:");
            string searchString = Console.ReadLine();

            if (!StringValidator.IsAlphabetOnly(searchString))
            {
                Console.WriteLine("The string should contain only alphabets; no numeric or special symbols are allowed.");
                goto RepeatPrompt;
            }

            StringSearcher.FindOccurrences(mainString, searchString);

        RepeatPrompt:
            Console.WriteLine("\nPress 1 to continue, Press 0 to exit:");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                continueProgram = false;
                Console.WriteLine("Exiting program. Goodbye!");
            }
            else if (choice != "1")
            {
                Console.WriteLine("Invalid choice. Exiting program.");
                continueProgram = false;
            }

            Console.WriteLine(); // Blank line for readability
        }
    }
}
