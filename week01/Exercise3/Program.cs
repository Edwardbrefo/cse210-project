using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNum = random.Next(1, 101);  // 1 to 100
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());
        
        while (guess != magicNum)
        {
            if (guess > magicNum)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine("Too low! Try again.");
            }
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine("Congratulations! You guessed the magic number!");
    }
}