namespace MyLearning02.MyJobs
{

    public class Job
    {
        public string _jobTitle;
        public string _company;
        public int _startYear;
        public int _endYear;

        public void DisplayJobDetails()
        {
            Console.WriteLine($"Job Title:{_jobTitle}, Company:{_company}, Period:{_startYear}-{_endYear}");
        }
    }

}