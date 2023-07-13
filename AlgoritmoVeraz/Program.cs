using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Activity("a", 1, 4),
            new Activity("b", 0, 6),
            new Activity("c", 5, 7),
            new Activity("d", 3, 9),
            new Activity("e", 6, 10),
            new Activity("f", 8, 11),
            new Activity("g", 8, 12),
            new Activity("h", 12, 16)
        };

        List<Activity> selectedActivities = SelectActivities(activities);

        Console.WriteLine("Selected Activities:");
        foreach (var activity in selectedActivities)
        {
            Console.WriteLine(activity.Name);
        }
        Console.ReadLine();

    }

    static List<Activity> SelectActivities(List<Activity> activities)
    {
        // Ordenar las actividades por tiempo de finalización ascendente
        activities.Sort((a, b) => a.FinishTime.CompareTo(b.FinishTime));

        List<Activity> selectedActivities = new List<Activity>();
        selectedActivities.Add(activities[0]);  // Seleccionar la primera actividad

        int lastFinishTime = activities[0].FinishTime;
        for (int i = 1; i < activities.Count; i++)
        {
            if (activities[i].StartTime >= lastFinishTime)
            {
                selectedActivities.Add(activities[i]);
                lastFinishTime = activities[i].FinishTime;
            }
        }

        return selectedActivities;
    }
}

class Activity
{
    public string Name { get; set; }
    public int StartTime { get; set; }
    public int FinishTime { get; set; }

    public Activity(string name, int startTime, int finishTime)
    {
        Name = name;
        StartTime = startTime;
        FinishTime = finishTime;
    }
}

