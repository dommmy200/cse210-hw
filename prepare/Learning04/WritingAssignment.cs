namespace PrepareAssignment
{
    public class WritingAssignment : Assignment
    {
        private string _textbookSection;
        private string _problems;

        public void SetTextbookSection(string textbookSection)
        {
            _textbookSection = textbookSection;
        }
        public void SetProblems(string problems)
        {
            _problems = problems;
        }

        public string GetTextbookSection()
        {
            return _textbookSection;
        }
         public string GetProblems()
        {
            return _problems;
        }

        public WritingAssignment(string studentName, string topic, string textbookSection, string problems) : base (studentName, topic)
        {
            _textbookSection = textbookSection;
            _problems = problems;
        }
        public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problem {_problems}";
        }
    }
}
