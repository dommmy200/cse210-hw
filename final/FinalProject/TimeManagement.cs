using System;

namespace FinancialPrudence {
    public static class TimeManagement {
        private static int _totalDays;
        private static Savings _savings = new Savings();
        private static string _oldDateFormat = "yyyy-MM-dd";
        public static DateTime GetToday() {
            return DateTime.Today;
        }
        public static string GetTotalDays() {
            DateTime today = GetToday();
            string oldDateStr = _savings.GetOldDate();
            var oldDate = DateTime.ParseExact(oldDateStr, "yyyy-MM-dd", null);
            var difference = oldDate - today;
            return difference.ToString(_oldDateFormat);
        }
        public static void SetTotalDays(int elapseDays) {
            _totalDays = elapseDays;
        }
    }
}