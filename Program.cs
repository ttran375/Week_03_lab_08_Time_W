﻿namespace Week_3_lab_08_Time_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the Time objects
            List<Time> times = new List<Time>()
            {
                new(9, 35),
                new(18, 5),
                new(20, 500),
                new(10),
                new()
            };

            // Display all the objects with the initial time format (Hour12)
            TimeFormat format = TimeFormat.Hour12;
            Console.WriteLine($"\nTime format is {format}");
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            // Change the format to Mil and display all the objects
            format = TimeFormat.Mil;
            Console.WriteLine($"\nSetting time format to {format}");
            Time.SetTimeFormat(format);
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            // Change the format to Hour24 and display all the objects
            format = TimeFormat.Hour24;
            Console.WriteLine($"\nSetting time format to {format}");
            Time.SetTimeFormat(format);
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }
        }
    }


    public enum TimeFormat
    {
        Mil,
        Hour12,
        Hour24
    }


    public class Time
    {
        private static TimeFormat TIME_FORMAT = TimeFormat.Hour12;
        public int Hour { get; private set; }
        public int Minute { get; private set; }

        public Time(int hours = 0, int minutes = 0)
        {
            if (hours >= 0 && hours <= 24)
                Hour = hours;
            else
                Hour = 0;

            if (minutes >= 0 && minutes < 60)
                Minute = minutes;
            else
                Minute = 0;
        }

        public override string ToString()
        {
            return TIME_FORMAT switch
            {
                TimeFormat.Mil => $"{Hour:D2}{Minute:D2}",
                TimeFormat.Hour12 => $"{(Hour % 12 == 0 ? 12 : Hour % 12):D2}:{Minute:D2} {(Hour < 12 ? "AM" : "PM")}",
                TimeFormat.Hour24 => $"{Hour:D2}:{Minute:D2}",
                _ => throw new InvalidOperationException("Invalid time format"),
            };
        }

        public static void SetTimeFormat(TimeFormat timeFormat)
        {
            TIME_FORMAT = timeFormat;
        }
    }
}
