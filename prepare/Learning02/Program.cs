using MyLearning02.MyJobs;
using MyLearning02.MyResume;

namespace MyLearning02
{
    class Program
    {

        static void Main(string[] args)
        {
            Job job1 = new()
            {
                _jobTitle = "Software Engineer",
                _company = "Microsoft",
                _startYear = 2009,
                _endYear = 2021
            };

            Job job2 = new()
            {
                _jobTitle = "Web Designer",
                _company = "Apple",
                _startYear = 2011,
                _endYear = 2023
            };

            Resume myResume = new()
            {
                _name = "John Doe"
            };

            myResume._jobs.Add(job1);
            myResume._jobs.Add(job2);

            myResume.Display();


        }
    }
}
