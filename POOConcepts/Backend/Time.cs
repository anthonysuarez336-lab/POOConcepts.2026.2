namespace Backend;

public class Time
{
    //fields
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    //Constructors
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }
    //Properties
    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }
    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }
    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }
    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }


    //Public Methods

    public override string ToString()
    {
        int hour = Hour;
        string tt = "AM";
        if (hour >= 12)
        {
            tt = "PM";
        }
         if (hour > 12)
        {
            hour -= 12;
        }
        return $"{hour:D2}:{Minute:D2}:{Second:D2}.{Millisecond:D3} {tt}";
    }

    public int ToMilliseconds()
    {
        return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
    }

    public int ToMinutes() 
    {
        return (Hour * 60) + Minute;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    public bool IsOtherDay (Time other)
    {
        return ToMilliseconds() + other.ToMilliseconds() >= 86400000;
    }
    
    public Time Add (Time other)
    {
        int millisecond = Millisecond + other.Millisecond;
        int second = Second + other.Second;
        int minute = Minute + other.Minute;
        int hour = Hour + other.Hour;

        if (millisecond > 999)
        {
            second++;
            millisecond -= 1000;
        }
        if (second > 59)
        {
            minute++;
            second -= 60;
        }   
         if (minute > 59)
        {
                hour++;
                minute -= 60;
        }
        if (hour > 23)
        {
            hour -= 24;
        }
        return new Time(hour, minute, second, millisecond);
    }

    //Private Methods   
    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour: {hour}, is not valid.");

        }
        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute} is not valid.");

        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second} is not valid.");

        }
        return second;
    }

    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond: {millisecond} is not valid.");

        }
        return millisecond;
    }
}

   
    


