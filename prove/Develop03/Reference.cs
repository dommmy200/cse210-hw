using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using MyWk05Design;
using MyWk05Design.Scripture1;

namespace MyWk05Design.Reference1
{
    public class Reference
    {
        public void WordsGenerator(string quoRef, string quoStr)
        {   
            // var count = 0;
            bool verify = true;
            while (verify)
            {

            var underscore = "___";

            // Random rand = new Random();
            // char [] delim = { ' ',',','.',';',':','\t' };
            // string [] qStr = quoStr.Split(delim);
            
            // int randomWordIndex = rand.Next(qStr.Length);
            // var randomWord = qStr[randomWordIndex];

            // Random rand1 = new Random();
            // int randomWordIndex1 = rand1.Next(qStr.Length);
            // var randomWord1 = qStr[randomWordIndex1];

            // Random rand2 = new Random();
            // int randomWordIndex2 = rand2.Next(qStr.Length);
            // var randomWord2 = qStr[randomWordIndex2];

            var randChild = Scripture.GeneratorLoop(quoStr);

            // string r1 = randChild.Item1;
            // string r2 = randChild.Item2;
            // string r3 = randChild.Item3;



            string check = quoStr.Replace(randChild, underscore);
            // .Replace(r2, underscore).Replace(r3, underscore);

            
            Console.Clear();
            Console.WriteLine($"{quoRef}: {check}");
            Console.ReadKey();

            string [] check2 = check.Split(" ");
            int checkLength = check2.Length;
            int count1 = 0;
            int count = 0;
            for (int i =0; i < checkLength; i++)
            {
                if (underscore.Equals(check2[i])){
                    count1++;
                }
            }
            foreach (Match m in Regex.Matches(check, underscore).Cast<Match>())
            {
                count++;
            }

            // if string replacement is not fully completed recurse "wordsGenerator"
            if (count != checkLength){
                WordsGenerator(quoRef, check);
            } else {
                verify = false;
            }
            // bool x = String.IsNullOrEmpty(check);
            // if (x){
            //     verify = false;
            // } else {
            //     WordsGenerator(quoRef, check);
            // }
            
            // count++;
            }
        }
    }
}