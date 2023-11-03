using System.Globalization;

namespace Mindfulness {
    public class Activity {
        protected int _duration = 4;
        protected string _className;
        protected string _description = "";
        public string Description {
            get { return _description; }
            set { _description = value; }
        }
        public string ClassName {
            get { return _className; }
            set { _className = value; }
        }
        public int Duration {
            get { return _duration; }
            set { _duration = value; }
        }
        public Activity(string className, string description) {
            _className = className;
            _description = description;
        }
        // Method to format options statement to obtain the class names
        public string FormatClassName (string subString) {
            string formatted = subString.Substring(6);
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(formatted);
            return titleCase;
        }
        // Method to display "Get ready"
        public void GetReadyForExercise() {
            Console.WriteLine("Get ready...");
            RotateSlashAnimation(6);
        }
        // Method to animate countdown
        public void CountdownAnimation(int count) {
            for (int i = count; i >= 0; i--) {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
        // Method to animate colored flip-flop dashes before every game
        public void DrawDashAnimation(int i) {
            var count = 0;
            while (count <= i) {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-");
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.Write("\b\b");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("_");
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.Write("\b\b");
                count++;
            }
        }
        // Method to animate rotating slashes at the prompt
        public void RotateSlashAnimation(int secs) {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(secs);

            string [] strings = {
                "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-"
            };
            
            int i = 0;
            while (DateTime.Now < endTime) {
                Console.Write(strings[i]);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                if ( i >= strings.Length)
                    i = 0;
                i++;
            }
            Console.WriteLine();
        }
        // Method to display "Welcome message"
        public void DisplayStartMessage(string className) {
            Console.Clear();
            Console.WriteLine($"Welcome to the {className}\n");
        }
        // Method to accept game duration from user
        public int GetUserDuration() {
            Console.Write("\nHow long, in seconds, would you like for your session? ");
            string response = Console.ReadLine();
            return response != null ? Convert.ToInt32(response) : 0;
        }
        public void DisplayWellDoneMessage() {
            Console.WriteLine("Well done!!");
            RotateSlashAnimation(5);
        }
        // Method to display "End messages"
        public void DisplayEndMessage(int duration, string className) {
            Console.WriteLine($"\nYou have completed another {duration} seconds of the {className}.");
            RotateSlashAnimation(5);
        }
    }
}