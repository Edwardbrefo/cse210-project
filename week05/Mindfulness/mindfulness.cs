using System;
using System.Collections.Generic;
using System.Threading;
class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }
    public void DisplayStartMessage()
    {
        Console.WriteLine($"Starting {_name} for {_duration} seconds.");
        Console.WriteLine(_description);
    }
    public void DisplayEndMessage()
    {
        Console.WriteLine($"Finished {_name}.");
    }
    public void PromptForDuration()
    {
        Console.Write("Enter duration in seconds: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int seconds) && seconds > 0)
        {
            _duration = seconds;
        }
        else
        {
            Console.WriteLine($"Invalid input. Using default duration: {_duration} seconds.");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string s = i.ToString();
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write('\r');
            Console.Write(new string(' ', s.Length));
            Console.Write('\r');
        }
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 60)
    {
    }

    public void Run()
    {
        DisplayStartMessage();
        PromptForDuration();
        ShowSpinner(3);

        int total = GetDuration();
        int elapsed = 0;

        while (elapsed < total)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            elapsed += 4;
            if (elapsed >= total) break;

            Console.WriteLine("Breathe out...");
            ShowCountdown(6);
            elapsed += 6;
        }

        DisplayEndMessage();
    }
}

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you overcame a challenge.",
        "Recall a moment when you felt truly happy.",
        "Reflect on a time when you helped someone in need.",
        "Consider a recent accomplishment you're proud of."
    };
    private Random _random = new Random();

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 60)
    {
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    
    public string GetRandomQuestion()
    {
        return GetRandomPrompt();
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
        ShowSpinner(3);
    }

    
    public void DisplayQuestions()
    {
        string prompt = GetRandomQuestion();
        DisplayPrompt(prompt);
    }

    public void Run()
    {
        DisplayStartMessage();
        PromptForDuration();
        ShowSpinner(3);

        int total = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(total);

        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
        }

        DisplayEndMessage();
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List as many things as you can that you are grateful for.",
        "List as many personal strengths as you can.",
        "List as many people as you can who have positively impacted your life.",
        "List as many things as you can that bring you joy."
    };
    public ListingActivity() : base("Listing Activity",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 60)
    {
    }
    public void Run()
    {
        DisplayStartMessage();
        PromptForDuration();
        ShowSpinner(3);

        int total = GetDuration();

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[index]);
        ShowSpinner(3);
        Console.WriteLine("Start listing...");
        ShowCountdown(total);
        DisplayEndMessage();
    }
}




