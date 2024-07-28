using System;
using System.Collections.Generic;
using System.Threading;

// Main program class
class Program
{
    // List to store user input
    private static List<string> myList = new List<string>();

    // Stack to store deleted items for undo functionality
    private static Stack<string> myStack = new Stack<string>();

    // Main entry point
    static void Main()
    {
        GreetingUser();
    }

    // Method to greet the user and explain the program
    static void GreetingUser()
    {
        DisplayMessage("Hello and welcome to my undo and redo message program!");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.Clear();

        DisplayMessage("""
                       In this Program, You will have to write names and when you want to undo the text,
                       Just press 'u'. 'd' to delete Text, press 'q' to quit, 'p' to print, 'a' to add
                       I hope you are going to have fun :)
                       """);
        ShowMenu();
    }

    // Method to display the main menu and handle user input
    static void ShowMenu()
    {
        DisplayMessage("Menu:\na: add\nu: undo\nd: delete\nq: quit\np: print");
        Console.Write("Please Choose an option: ");
        string userChoice = Console.ReadLine();

        // Handle user choice with a switch statement
        switch (userChoice)
        {
            case "a":
                AddText();
                break;
            case "u":
                UndoText();
                break;
            case "p":
                PrintList();
                break;
            case "d":
                DeleteText();
                break;
            case "q":
                DisplayMessage("Thank you for playing!");
                Environment.Exit(0);
                break;
            default:
                DisplayMessage("Invalid choice. Please try again.");
                ShowMenu();
                break;
        }
    }

    // Method to delete the last added text and store it in the stack
    static void DeleteText()
    {
        if (myList.Count == 0)
        {
            DisplayError("Your list is empty. Please add some items and try again.");
        }
        else
        {
            string lastItem = myList[myList.Count - 1];
            myStack.Push(lastItem); // Save the last item for undo
            myList.RemoveAt(myList.Count - 1); // Remove the last item
            DisplayMessage(lastItem + " Deleted successfully.");
        }
        ShowMenu();
    }

    // Method to print the current list
    static void PrintList()
    {
        if (myList.Count == 0)
        {
            DisplayError("There is nothing to print.");
        }
        else
        {
            Console.WriteLine("############################################");
            foreach (string item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("############################################");
        }
        ShowMenu();
    }

    // Method to add text to the list
    static void AddText()
    {
        while (true)
        {
            DisplayMessage("Please add something (or press 'q' to quit):");
            string userInput = Console.ReadLine();
            if (userInput.Equals("q"))
            {
                break; // Exit the loop if the user inputs 'q'
            }

            myList.Add(userInput);
            DisplayMessage($"{userInput}: Added Successfully!");
        }
        ShowMenu();
    }

    // Method to undo the last delete action
    static void UndoText()
    {
        if (myStack.Count == 0)
        {
            DisplayError("There is nothing to undo.");
        }
        else
        {
            string lastDeletedItem = myStack.Pop();
            myList.Add(lastDeletedItem); // Re-add the last deleted item
            
            DisplayMessage(lastDeletedItem + " is now back in your list.");
        }
        ShowMenu();
    }

    // Method to display a formatted message
    static void DisplayMessage(string message)
    {
        Console.WriteLine("*******************************");
        Console.WriteLine(message);
        Console.WriteLine("*******************************");
    }

    // Method to display an error message
    static void DisplayError(string message)
    {
        Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        Console.WriteLine(message);
        Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
    }
}
