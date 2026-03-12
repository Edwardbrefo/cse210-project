using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string name = PromptUserName();
        int squareNum = SquareNumber();
        DisplayResult(name, squareNum, squareNum * squareNum);
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}! Nice to meet you.");
        return name;
    }

    static int SquareNumber()
    {
        Console.Write("Please enter a number: ");
        int squareNum = int.Parse(Console.ReadLine());
        int result = squareNum * squareNum;
        Console.WriteLine($"The square of {squareNum} is {result}");
        return squareNum;
    }

    static void DisplayResult(string name, int squareNum, int result)
    {
        Console.WriteLine($"Hi {name}, the square of {squareNum} is {result}");
    }
}