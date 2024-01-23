namespace Week_03_lab_08_Time_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the objects
            List<Time> times = new()
            {
              new Time(9, 35),
              new Time(18, 5),
              new Time(20, 500),
              new Time(10),
              new Time()
            };

            // Display all the objects
            TimeFormat format = TimeFormat.Hour12;
            Console.WriteLine($"\n\nTime format is {format}");
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            // Change the format of the output
            format = TimeFormat.Mil;
            Console.WriteLine($"\n\nSetting time format to {format}");

            // SetFormat(TimeFormat) is a class member, so you need the type to access it
            Time.SetFormat(format);

            // Again display all the objects
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            // Change the format of the output
            format = TimeFormat.Hour24;
            Console.WriteLine($"\n\nSetting time format to {format}");

            // SetFormat(TimeFormat) is a class member, so you need the type to access it
            Time.SetFormat(format);
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
        private int Hour { get; }
        private int Minute { get; }

        public Time(int hour = 0, int minute = 0)
        {
            Hour = (hour >= 0 && hour < 24) ? hour : 0;
            Minute = (minute >= 0 && minute < 60) ? minute : 0;
        }

        public override string ToString()
        {
            switch (TIME_FORMAT)
            {
                case TimeFormat.Mil:
                    return $"{Hour:D2}{Minute:D2}";
                case TimeFormat.Hour24:
                    return $"{Hour:D2}:{Minute:D2}";
                case TimeFormat.Hour12:
                    return $"{((Hour % 12 == 0) ? 12 : Hour % 12):D2}:{Minute:D2} {(Hour < 12 ? "AM" : "PM")}";
                default:
                    return "";
            }
        }

        public static void SetFormat(TimeFormat timeFormat)
        {
            TIME_FORMAT = timeFormat;
        }
    }
}
