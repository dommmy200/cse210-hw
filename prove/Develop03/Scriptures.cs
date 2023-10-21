namespace Memorizer;
public class Scriptures
{
    private string _reference; 
    private string _quote;
    public string Reference { get{return _reference;} set{_reference = value;}}
    public string Quote { get{return _quote;} set{_quote = value;}}

    public Scriptures(string reference, string quote)
    {
        this._reference = reference;
        this._quote = quote;
    }
    // WordsGenerator() is defined here
    public static void WordsGenerator(string quoRef, string quoStr)
    {   
       
        bool verify = true;
        while (verify)
        {   
            // ReplaceRandomWords() is a helper method to do the actual replacement
            string strings1 = Scriptures.ReplaceRandomWords(quoStr);

            Reference reference = new Reference();

            reference.DisplayQuote(quoRef, strings1);


            // if string replacement is not fully completed recurse "wordsGenerator"
            if (Words.IsReplacementComplete(strings1)){

                WordsGenerator(quoRef, strings1);
            }
            verify = false;
        }
    }

    // ReplaceRandomWords() is defined here
    static string ReplaceRandomWords(string sentence)
    {
        
        string replacement = "___";
        string [] words = sentence.Split(" ");
        int totalWords = words.Length;
        int wordReplace = 0;

        while (wordReplace < totalWords)
        {
            // GetRandomWords() is a helper method defined
            string [] randomWords = GetRandomWords(words);
            for (int i = 0; i < words.Length; i++)
            {
                if (randomWords.Contains(words[i]))
                {
                    words[i] = replacement;
                    wordReplace++;
                }
            }
        }
        return string.Join(" ", words); 
    }
    // Random words are generated in triple here
    static string [] GetRandomWords(string [] words)
    {     
        
        int count =3;
        Random random = new Random();
        
        //prevent end of array exception when array length is less than 3
        if (words.Length == 2 || words.Length == 1)
        {
            count = words.Length;
        } 
        string [] randomWords = new string[count];
        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(0, words.Length);
            randomWords[i] = words[randomIndex];
        }
        return randomWords;
    }
}