using System;

namespace FinancialPrudence {
    public class TimeManagement {
        private int _totalDays;
        private Savings _savings = new Savings();
        private static string _oldDateFormat = "yyyy-MM-dd";
        public static DateTime GetToday() {
            return DateTime.Today;
        }
        public static string GetTotalDays() {
            DateTime today = GetToday();
            string oldDateStr = Savings.GetOldDate();
            var oldDate = DateTime.ParseExact(oldDateStr, "yyyy-MM-dd", null);
            var difference = oldDate - today;
            return difference.ToString(_oldDateFormat);
        }
        public void SetTotalDays(int elapseDays) {
            _totalDays = elapseDays;
        }
    }
}