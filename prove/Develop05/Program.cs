using System;
using System.Collections.Generic;

namespace EternalGoal {
    class Program {
        static void Main(string[] args) {

            HelperClass helper = new HelperClass();
            List<string> strings = new List<string>(6) {
                "Create New Goal",
                "List Goals",
                "Load Goals",
                "Record Events",
                "Save Goal",
                "Quit"
            };
            bool Quit = true;
            while (Quit) {
                int tPoint = helper.GetTotalPoints();

                Console.WriteLine($"\nYou have {tPoint} points.\n\nMenu Options:");
                for (int i = 0; i < strings.Count; i++) {
                    Console.WriteLine($"  {i+1}. {strings[i]}");
                }
                Console.Write("Select a choice from the menu: ");
                int opt = int.Parse(Console.ReadLine());
                
                if (strings.IndexOf(strings[0])+1 == opt) {
                    GetGoalType(helper);
                } else if (strings.IndexOf(strings[1])+1 == opt) {
                    Console.WriteLine("List Goals");
                    ShowList(helper);
                } else if (strings.IndexOf(strings[2])+1 == opt) {
                    Console.WriteLine("Load Goals 3");
                    helper.RecreateAndLoadGoals();
                } else if (strings.IndexOf(strings[3])+1 == opt) {
                    Console.WriteLine("Record Events 4");
                    helper.RewardGoalAchieved();
                } else if (strings.IndexOf(strings[4])+1 == opt) {
                    helper.SaveGoalToFile();
                    Console.WriteLine("Save Goals 5");
                } else if (strings.IndexOf(strings[5])+1 == opt) {
                Console.WriteLine("Quit");
                    Quit = false;
                }
            }
                    
            static void GetGoalType(HelperClass helper) {
                List<string> goals = new List<string>(3) {
                    "Simple Goal",
                    "Eternal Goal",
                    "Checklist Goal"
                };
                Console.WriteLine("The types of Goals are: ");
                for (int i = 0; i < goals.Count; i++) {
                    Console.WriteLine($"  {i+1}. {goals[i]}");
                }
                Console.Write("Which type of goal would you like to create? ");
                int x = int.Parse(Console.ReadLine());
                switch (x){
                    case 1:
                        Console.WriteLine("case 1");
                        int quest = 1;
                        GetGoalQuestions(quest, helper);
                        break;
                    case 2:
                        Console.WriteLine("case 2");
                        quest = 2;
                        GetGoalQuestions(quest, helper);
                        break;
                    case 3:
                        Console.WriteLine("case 3");
                        quest = 3;
                        GetGoalQuestions(quest, helper);
                        break;
                }
            }
            static void GetGoalQuestions(int x, HelperClass help) {
                switch (x) {
                    case 1 :
                        SimpleAndEternalQuestions(1, help);
                        break;
                    case 2 :
                        SimpleAndEternalQuestions(2, help);
                        break;
                    case 3 :
                        ChecklistQuestions(help);
                        break;
                }     
            }

            static void SimpleAndEternalQuestions(int x, HelperClass help) {
                Console.Write("What is the name of your goal? ");
                string? name = Console.ReadLine();

                Console.Write("What is a short description of it? ");
                string? description = Console.ReadLine();
                if (description != null)
                
                Console.Write("What is the amount of points associated with this goal? ");
                string? pnt = Console.ReadLine();
                int point = int.Parse(pnt);
                // These goal types are differentiated by x=1 & 2
                if (x == 1) {
                    SimpleGoal goal1 = new SimpleGoal("",name, description, point);
                    help.AddGoalToList(goal1);
                } else {
                    EternalGoal goal2 = new EternalGoal("",name, description, point);
                    help.AddGoalToList(goal2);
                }
            }

            static void ChecklistQuestions(HelperClass help) {
                
                Console.Write("What is the name of your goal? ");
                string? name = Console.ReadLine();
                    if (name is not null)

                Console.Write("What is a short description of it? ");
                string? description = Console.ReadLine();

                Console.Write("What is the amount of points associated with this goal? ");
                string? pnt = Console.ReadLine();
                int point = int.Parse(pnt);

                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string? maxCount = Console.ReadLine();
                int maximumCount = int.Parse(maxCount);

                Console.Write("What is the bonus for accomplishing it that many times? ");
                string? bonus = Console.ReadLine();
                int bonuses = int.Parse(bonus);
                
                ChecklistGoal goal2 = new ChecklistGoal("",name, description, point, bonuses, maximumCount);
                help.AddGoalToList(goal2);
            }
            static void ShowList(HelperClass help) {
                List<Goal> goalList = help.GetGoalsList();
                Console.Clear();
                Console.WriteLine("The goals are:");
                for (int i = 0; i < goalList.Count; i++) {
                    goalList[i].DisplaySubclassObjects(i + 1); // goalList[i] is a goal object
                }
            }
        }
    }
}