using System;
using System.Collections.Generic;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        // Person p1 = new()
        // {
        //     _firstName = "Mary",
        //     _lastName = "McKay",
        //     _age = 25
        // };

        // Person p2 = new()
        // {
        //     _firstName = "Simon",
        //     _lastName = "Ogwuche",
        //     _age = 30

        // };

        // List<Person> people = new List<Person>();       
        //     people.Add(p1);
        //     people.Add(p2);
        
        // foreach (Person p in people)
        // {
        //     Console.WriteLine(p._lastName);
        // }
        
        // SaveToFile(people);
        List<Person> newPeople = ReadFromFile();
        foreach (Person p in newPeople)
        {
            Console.WriteLine(p._firstName);
        }
    }
    public static void SaveToFile(List<Person> people)
    {
        Console.WriteLine("Saving To File...");

        string fileName = "people.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Person person in people)
            {
                outputFile.WriteLine($"{person._firstName}, {person._lastName}, {person._age}");
            }
        }

    }

    public static List<Person> ReadFromFile()
    {
        Console.WriteLine("Reading List From File...");

        List<Person> people = new List<Person>();
        string fileName = "people.txt";
        
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            // Console.WriteLine(line);
            string[] parts = line.Split(",");

            Person newPerson = new Person();
            newPerson._firstName = parts[0];
            newPerson._lastName = parts[1];
            newPerson._age = int.Parse(parts[2]);

            people.Add(newPerson);
        }

        return people;
    }
}