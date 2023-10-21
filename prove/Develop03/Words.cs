namespace Memorizer;
public class Words
{
    // The static method to remove punctuation marks from strings
    static string RemovePunctuationMarks(string str)
    {   
        string [] strings = str.Split(" ");
        string[] result = new string[strings.Length];

        for (int i = 0; i < strings.Length; i++)
        {
            result[i] = strings[i].Replace(",", " ").Replace(".", " ").Replace(";", " ").Replace(":"," ").Replace("?"," ");
            
        }
        string res = string.Join(" ", result);
        return res;
    }

     // If this method returns false, the passed string has not fully been replaced
    public static bool IsReplacementComplete(string quoteString2)
    {   
        Reference reference = new Reference();
        string strings = Words.RemovePunctuationMarks(quoteString2);
        string[] strings1 = strings.Split(" ");

        if (strings1.Length == 0)
        {
            return true; // Empty array means all items in the strings are same.
        }
        string firstWord = strings1[0];
        for(int i = 1; i < strings1.Length; i++){
            if (strings1[i] != firstWord)
            {
                return true; //Items in the string are dissimilar
            }
        }
        return false; //Items in the string are similar
    }
}
