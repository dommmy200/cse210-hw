using System.Text.Json;
using MyWk05Design.Reference1;
using MyWk05Design.Scripture1;

namespace MyWk05Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Scripture Memorizer!\n");

            bool condition = true;
            while (condition)
            {
                Console.WriteLine("Please enter to continue or type 'quit' to finish: ");
                string selected = Console.ReadLine();
                if (selected == "quit"){
                    // Quit the loop and exit the program
                    System.Environment.Exit(0);
                }
            
                string text = File.ReadAllText(@"./scripture.json");
                List<Scripture> scripture = JsonSerializer.Deserialize<List<Scripture>>(text);

                Random random = new Random();
                int index = random.Next(scripture.Count); //Unable to use "scripture.Length" which is not defined
                Scripture referenceAndQuote = scripture[index];

                string scriptureQuote = referenceAndQuote.Quote; 
                string QuoteReference = referenceAndQuote.Reference;

                Console.Clear();
                Console.WriteLine($"{QuoteReference}: {scriptureQuote}");
                Console.ReadKey();

                Reference reference = new Reference();
                reference.WordsGenerator(QuoteReference, scriptureQuote);
            }
        }
    }
}