using System.IO;

using MyMainProgram;

namespace MyMainProgram.Choice1
{
    public class Choice
    {

        // private string _prompt;
        // private string _response;
        // private DateTime _journalDate;

        public void displayChoices() //Method to Display choices for user selection
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
    

        public string PromptGenerator()
        {
            Random random = new Random();
            string rnd = randPrompt[random.Next(randPrompt.Count)];
            return rnd;
        }
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
        public string DateToString()
        {
            DateTime dateTime = DateTime.Now;
            string dToday = dateTime.ToString("dd MMMM yyyy");
            
            return dToday;
        }

        public static List<string> DataList{ get; set;} = new List<string>();
        

    }
}

