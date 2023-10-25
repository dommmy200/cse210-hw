using System;
using System.ComponentModel;
using PrepareAssignment;

class Program
{
    static void Main(string[] args)
    {   
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        string s = assignment.GetSummary();
        Console.WriteLine(s);

        MathsAssignment maths = new MathsAssignment("Samuel Bennett", "Multiplication", "The big fat hen");
        string m = maths.GetTopic();
        Console.WriteLine(m);

        WritingAssignment writing = new WritingAssignment("Men Boys", "Biology", "caterpillar", "1-2 3-4");
        string w = writing.GetProblems();
        Console.WriteLine(w);
    }
}