using System.ComponentModel;
using System.Dynamic;
using System.Text.RegularExpressions;
using MyWk05Design;

namespace MyWk05Design.Scripture1
{
    public class Scripture
    {
        public string Reference { get; set;}
        public string Quote { get; set;}

        // static public Tuple<string,string,string> generatorLoop(string quStr){
        static public string GeneratorLoop(string quStr){
            // var underscore = "___";
            // int count = 2;

            char [] delimiterChars = { ' ',',','.',';',':','\t' };
            string [] qStr = quStr.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            
            // List<string> rings = new();
            
            // foreach (Match m in Regex.Matches(quStr, underscore).Cast<Match>())
            // {
            //     count++;
            // }

            // int x = qStr.Length - count;

            // for (int i = 0; i < count; i++){
                // var rd = "";
                // bool condition = true;
                // while (condition){
                Random rand = new Random();
                int randomWordIndex = rand.Next(qStr.Length);
                var randomWord = qStr[randomWordIndex];
                // if (randomWord == underscore){
                //     continue;
                // } 
                // break;
                // else {
                //     return rd;

                // }
                
                // else if (randomWord != underscore && x == 2){
                //     rings[1] = underscore;
                //     rings[2] = underscore;
                // } else if (randomWord != underscore && x == 1){
                //     rings[2] = underscore;
                // }    
                // }
                return randomWord;
            // return Tuple.Create(rings[0],rings[1],rings[2]);
            
        }
            
    }
}
