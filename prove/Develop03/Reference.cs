using System.Text.RegularExpressions;

namespace Memorizer;
public class Reference
{
    // pass a string and corresponding reference to display the concatenation
    public static void DisplayQuote(string quoRef, string quStr2){
        Console.Clear();
        Console.WriteLine($"\n{quoRef}: {quStr2}\n");
        Console.ReadKey();
    }
}