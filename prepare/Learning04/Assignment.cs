using System.Diagnostics.Contracts;

namespace PrepareAssignment
{
    public class Assignment
    {
        protected string _studentName;
        protected string  _topic;

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetStudentName()
        {
            return _studentName;
        }
        public string GetTopic()
        {
            return _topic;
        }
        // public void SetStudentName(string studentName)
        // {
        //     _studentName = studentName;
        // }
        // public void SetTopic(string topic)
        // {
        //     _topic = topic;
        // }
        
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }
}
