namespace PrepareAssignment
{
    public class MathsAssignment : Assignment
    {
        private string _title;

        public void SetTitle(string title)
        {
            _title = title;
        }
        public string GetTitle()
        {
            return _title;
        }

        public MathsAssignment(string studentName, string topic, string title) : base (studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            return $"{_title}";
        }
    }
}