using UnityEngine;


public enum TimeOfDay
{
    morning,
    midday,
    afternoon,
};

[System.Serializable]
public class TimeInterval
{
    public TimeOfDay TimeOfDay;
    public int IntervalStart;
    public int IntervalEnd;
}

