namespace Week_01_lab_02_Cars_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the Time objects
            List<Time> times = new List<Time>()
        {
            new Time(9, 35),
            new Time(18, 5),
            new Time(20, 500),
            new Time(10),
            new Time()
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

    // Time class definition
    public class Time
    {
        // Private static field for the default time format
        private static TimeFormat TIME_FORMAT = TimeFormat.Hour12;

        // Public properties with private setters for Hour and Minute
        public int Hour { get; private set; }
        public int Minute { get; private set; }

        // Public constructor with default values for hours and minutes
        public Time(int hours = 0, int minutes = 0)
        {
            // Validate and set Hour property
            if (hours >= 0 && hours <= 24)
                Hour = hours;
            else
                Hour = 0;

            // Validate and set Minute property
            if (minutes >= 0 && minutes < 60)
                Minute = minutes;
            else
                Minute = 0;
        }

        // Public method to override ToString() and display time based on TIME_FORMAT
        public override string ToString()
        {
            switch (TIME_FORMAT)
            {
                case TimeFormat.Mil:
                    return $"{Hour:D2}{Minute:D2}";

                case TimeFormat.Hour12:
                    return $"{(Hour % 12 == 0 ? 12 : Hour % 12):D2}:{Minute:D2} {(Hour < 12 ? "AM" : "PM")}";

                case TimeFormat.Hour24:
                    return $"{Hour:D2}:{Minute:D2}";

                default:
                    throw new InvalidOperationException("Invalid time format");
            }
        }

        // Public static method to set the default time format
        public static void SetTimeFormat(TimeFormat timeFormat)
        {
            TIME_FORMAT = timeFormat;
        }
    }
}
