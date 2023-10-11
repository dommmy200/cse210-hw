using System;
using Program1.Fraction1;

namespace Program {
    class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction(7, 2);
        Fraction f2 = new Fraction(3);
        
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
    }
    
}
}