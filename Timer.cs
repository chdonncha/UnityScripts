using UnityEngine;
using System.Collections;

public class Timer
{
    private float _currentTime;
    private bool _isStopped = false;
    public float TickTime { get; set; }

    public bool IsStopped
    {
        get { return _isStopped; }
        set { _isStopped = value; }
    }

    public bool CanTick
    {
        get
        {
            if (IsStopped)
                return false;
            if (Time.time - _currentTime >= TickTime)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Check to see if the timer has triggered a tick.
    /// If it can tick it will return true and reset the timer
    /// </summary>
    public bool CanTickAndReset()
    {
        if (Time.time - _currentTime >= TickTime)
        {
            _currentTime = Time.time;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _currentTime = Time.time;
    }

    public void ForceTickTime()
    {
        _currentTime -= TickTime;
    }

    public Timer(float tickTime)
    {
        _currentTime = Time.time;
        TickTime = tickTime;

    }

    public override string ToString()
    {
        return "(" + TickTime + " : " + (Time.time - _currentTime) + ")";
    }

}