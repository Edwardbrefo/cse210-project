using System;

using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lenMinutes;
    public Activity(DateTime date, int lenMinutes)
    {
        _date = date;
        _lenMinutes = lenMinutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLenMinutes()
    {
        return _lenMinutes;
    }
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{GetDate():yyyy-MM-dd} {GetType().Name} ({GetLenMinutes()} min)"
            + $" Distance: {GetDistance():0.00} km,"
            + $"Speed: {GetSpeed():0.00} kph " +
              $"Pace: {GetPace():0.00} min per km";
    }
}

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int lenMinutes, double distanceKm)
        : base(date, lenMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        return (_distanceKm / GetLenMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLenMinutes() / _distanceKm;
    }
}

public class Cycling : Activity
{
    private int _speedKph;

    public Cycling(DateTime date, int lenMinutes, int speedKph)
        : base(date, lenMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph / 60) * GetLenMinutes();
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        return 60.0 / _speedKph;
    }
}

public class Swimming : Activity
{
    private int _laps;
    private double _distancePerLapKm;

    public Swimming(DateTime date, int lenMinutes, int laps, double distancePerLapKm)
        : base(date, lenMinutes)
    {
        _laps = laps;
        _distancePerLapKm = distancePerLapKm;
    }

    public override double GetDistance()
    {
        return _laps * _distancePerLapKm;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLenMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLenMinutes() / GetDistance();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        var activities = new List<Activity>
        {
            new Running(new DateTime(2024, 6, 1), 30, 5),
            new Cycling(new DateTime(2024, 6, 2), 45, 10),
            new Swimming(new DateTime(2024, 6, 3), 60, 20, 0.5)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}