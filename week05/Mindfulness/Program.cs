using System;

Console.WriteLine("Hello World! This is the Mindfulness Project.");
while (true)
{
    Console.WriteLine("Menu Options:");
    Console.WriteLine("1. Start Breathing Activity");
    Console.WriteLine("2. Start Reflection Activity");
    Console.WriteLine("3. Start Listing Activity");
    Console.WriteLine("4. Quit");
    Console.Write("Select a choice from the menu: ");
    string choice = Console.ReadLine();
    if (choice == "1")
    {
        BreathingActivity breathingActivity = new();
        breathingActivity.Run();
    }
    else if (choice == "2")
    {
        ReflectionActivity reflectionActivity = new();
        reflectionActivity.Run();
    }
    else if (choice == "3")
    {
        ListingActivity listingActivity = new();
        listingActivity.Run();
    }
    else if (choice == "4")
    {
        break;
    }
}
