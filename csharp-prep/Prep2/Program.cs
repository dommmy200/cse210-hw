// This is Prep2 core and stretch assignments combined.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please, enter your grade. ");
        string gradeInString = Console.ReadLine();
        float grade = float.Parse(gradeInString);

        if (grade >= 90)
        {
            Console.Write("You scored an A ");
        }
        
        else if (grade >= 80 && grade < 90)
        {
            float gradeRemainder = grade - 80;
            if (gradeRemainder >= 7)
            {
                Console.Write("You scored a B+ ");
            }
            else if (gradeRemainder < 3)
            {
                Console.Write("You scored a B- ");
            }
            else {Console.Write("You scored a B ");}
        }
        else if (grade >= 70 && grade < 80)
        {
             float gradeRemainder = grade - 70;
            if (gradeRemainder >= 7)
            {
                Console.Write("You scored a C+ ");
            }
            else if (gradeRemainder < 3)
            {
                Console.Write("You scored a C- ");
            }
            else {Console.Write("You scored a C ");}
        }
        else if (grade >= 60 && grade < 70)
        {
             float gradeRemainder = grade - 60;
            if (gradeRemainder >= 7)
            {
                Console.Write("You scored a D+ ");
            }
            else if (gradeRemainder < 3)
            {
                Console.Write("You scored a D- ");
            }
            else {Console.Write("You scored a D ");}
        }
        else if (grade < 60)
        {
            Console.Write("You scored an F ");
        }
    }
}