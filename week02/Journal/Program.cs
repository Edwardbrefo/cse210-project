using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<string> _answers = new List<string>();
    private string _date;

    //this displays the journal entries with the date
    public void DisplayAnswer()
    {
        Console.WriteLine("\nJournal Entries:");
        foreach (string answer in _answers)
        {
            Console.WriteLine($"{_date}: {answer}");
        }
    }

    //this part is used to save to the file.
    public void Save(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (string answer in _answers)
            {
                file.WriteLine($"{_date},{answer}");
            }
        }
    }

    // // this part loads answers from a file
    public void Load(string filename)
    {
        _answers.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2)
            {
                _date = parts[0];
                _answers.Add(parts[1]);
            }
        }
    }

    // Add a new entry with today’s date
    public void AddEntry(string answer)
    {
        DateTime date = DateTime.Now; // Set the date to today's date
        _date = date.ToShortDateString(); // Store the date as a string
        _answers.Add(answer);
    }
}

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What was the best part of your day?",
            "What are you grateful for today?",
            "Describe a challenge you faced and how you overcame it.",
            "What is something new you learned today?",
            "Write about a memorable moment from your day."
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    string response = Console.ReadLine();
                    journal.AddEntry(response);
                    break;

                case "2":
                    journal.DisplayAnswer();
                    break;

                case "3":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine();
                    journal.Save(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();
                    journal.Load(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}