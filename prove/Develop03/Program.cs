// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Text.Json;
using Memorizer;

Console.WriteLine("Welcome to Scripture Memorizer!\n");

    bool condition = true;
    while (condition)
    {
        Random random = new Random();
        
        Console.WriteLine("Please enter to continue or type 'quit' to finish: ");

        string? selected = Console.ReadLine(); //(?) annotate types that are known to be nullable with ?
        if (selected == "quit"){
            // Quit the loop and exit the program
            System.Environment.Exit(0);
        }
            string filePath = "./scripture.json";

            string json = File.ReadAllText(filePath);
            // Get the JSON file and convert to object list
            List<Scriptures>? scripture = JsonSerializer.Deserialize<List<Scriptures>>(json);
        
            
            Reference reference = new Reference();
    
            int index = random.Next(scripture.Count); //Unable to use "scripture.Length" which is not defined
            Scriptures referenceAndQuote = scripture[index];
           
            
            string scriptureQuote = referenceAndQuote.Quote; 
            string quoteReference = referenceAndQuote.Reference;

            // Display the unmodified quote
            reference.DisplayQuote(quoteReference, scriptureQuote);
            // Call the WordsGenerator() to modify the quote
            Scriptures.WordsGenerator(quoteReference, scriptureQuote);
            continue;
    }
