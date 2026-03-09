using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your Grade Percentage? ");
        string answer = Console.ReadLine();
        int grade = int.Parse(answer);

        if (grade >= 90)
        {
            Console.WriteLine("Congratulations! You got an A!");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("You got a B.");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("You got a C.");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("You got a D.");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }
    }
}