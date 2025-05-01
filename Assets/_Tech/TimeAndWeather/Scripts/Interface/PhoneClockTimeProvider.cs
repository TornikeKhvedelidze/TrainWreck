using System;
using UnityEngine;

public class PhoneClockTimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime()
    {
        return System.DateTime.Now;
    }
}
