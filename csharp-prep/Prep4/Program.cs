using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;

class Program
{
    static void Main(string[] args)
    {   
        float sum = 0; 
        // float average = 0; 
        // float largestNumber = 0;

        List<float> numbersList = new List<float>();
        List<float> naturalNumbers = new List<float>();
        float listContentNumber = -1;

        Console.WriteLine("Enter a list of Numbers, type 0 when finished.");
        while (listContentNumber != 0)
        {
            Console.Write("Enter number: ");
            string listContentString = Console.ReadLine();
            listContentNumber = float.Parse(listContentString);
            numbersList.Add(listContentNumber);
            if (listContentNumber == 0)
            {
                listContentNumber = 0;
            }
        }
        int numberCount = numbersList.Count;
        foreach (float numb in numbersList)
        {
            sum += numb;
            if (numb > 0)
            {
                naturalNumbers.Add(numb);
            }
        }
        numbersList.Sort();
        naturalNumbers.Sort();
        float smallPositiveNumb = naturalNumbers[0];
        float largestNumber = numbersList[numberCount - 1];
        float average = sum / numberCount;

        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + largestNumber);
        Console.WriteLine("The smallest positive number is: " + smallPositiveNumb);
        foreach (float sortedNumber in numbersList)
        {
            Console.WriteLine(sortedNumber);

        }
    }
}