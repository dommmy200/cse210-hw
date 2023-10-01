using System.IO;

using MyMainProgram;

namespace MyMainProgram.Choice1
{
    public class Choice
    {
 
        public string _date;
        public string _prompt;
        public string _response;


        public void DatePromptResp(string str)
        {
            List<string> datePromptResp = new()
            {
                str
            };
        }
    

        public string PromptGenerator()
        {
            Random random = new Random();
            string rnd = _choice[random.Next(_choice.Count)];
            return rnd;
        }
        List<string> _choice = new()
            {
                "How do you feel about praying today?",
                "What did you plan to do that you are forgetting?",
                "How did you do your missionary work this week?",
                "What subject are you finding hard to deal with?",
                "What sets of exercises do you do regularly?",
                "How do you feel without your smartphone for a day?",
                "What will happen if you do not pray in a day?",
                "What do you do to avoid being tempted to sin?",
                "Who offended you today?"
            };
        public string DateString()
        {
            DateTime dateTime = DateTime.Now;
            string dToday = dateTime.ToString("dd MMMM yyyy");
            
            return dToday;
        }

        public static void Journal(List<string> choices)
        {
            
            string fileName = "journal.txt";
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (string filing in choices)
                {
                    
                    outputFile.WriteLine($"{filing}");
                };
            }
        }

    }
}

