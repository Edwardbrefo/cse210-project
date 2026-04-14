class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        manager.AddGoal(new SimpleGoal("Run a marathon", "Complete a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read scriptures", "Daily reading", 100));
        manager.AddGoal(new ChecklistGoal("Attend temple", "Go 10 times", 50, 10, 500));

        Console.WriteLine(manager.GetGoalsListText());

        
        manager.RecordGoalEvent(0); 
        manager.RecordGoalEvent(1); 
        manager.RecordGoalEvent(2); 

        Console.WriteLine($"Score: {manager.Score}");
        Console.WriteLine(manager.GetGoalsListText());
    }
}
