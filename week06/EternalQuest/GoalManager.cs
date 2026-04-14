public class GoalManager
{
    public List<Goal> Goals { get; } = new List<Goal>();
    public int Score { get; private set; } = 0;

    public void AddGoal(Goal goal) => Goals.Add(goal);

    public string RecordGoalEvent(int index)
    {
        int points = Goals[index].RecordEvent();
        Score += points;
        return $"You earned {points} points!";
    }

    public string GetGoalsListText()
    {
        string text = "";
        for (int i = 0; i < Goals.Count; i++)
        {
            text += $"{i + 1}. {Goals[i].GetDisplayText()}\n";
        }
        return text;
    }
}
