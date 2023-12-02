using System.IO;

using MyMainProgram;

namespace MyMainProgram.Choice1
{
    public class Choice
    {
        //Method to Display choices for user selection
        public static void displayChoices()
        {
            List<string> choice = new()
                {
                    "Write",
                    "Display",
                    "Load",
                    "Save",
                    "Quit"
                };
            int count = 0;
            foreach (string ch in choice)
            {
                count++;
                Console.WriteLine($"{count}. {ch}");
            }
        }
    
        // Method to generate random prompts
        public string PromptGenerator()
        {
            Random random = new Random();
            string rnd = randPrompt[random.Next(randPrompt.Count)];
            return rnd;
        }
        // List containing the prompt items for use by the prompt generator
        List<string> randPrompt = new()
            {
                "How do you feel about praying today?",
                "What did you plan to do that you are forgetting?",
                "How did you do your missionary work this week?",
                "What subject are you finding hard to deal with?",
                "What sets of exercises do you do regularly?",
                "How do you feel without your smartphone for a day?",
                "What will happen if you do not pray in a day?",
                "What do you do to avoid being tempted to sin?",
                "Who offended you today?",
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
            };
  

        // Use a Tuple to return multiple string values of DateTime
        public static Tuple<string, string, string> DateTimeString()
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan myTime = DateTime.Now.TimeOfDay;
            string myHour = myTime.Hours.ToString();
            string myMinute = myTime.Minutes.ToString();
            string myDate = dateTime.ToString("dd MMMM yyyy");

            return Tuple.Create(myDate, myHour, myMinute);
        }

        // List to store data while the program runs. Data loaded from files end here
        // for display and saving back to file (if necessary)
        public static List<string> DataList{ get; set;} = new List<string>();
        

    }
}

