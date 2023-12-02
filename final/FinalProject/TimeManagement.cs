using System;

namespace FinancialPrudence {
    public static class TimeManagement {
        private static int _totalDays;
        public static DateTime GetToday() {
            return DateTime.Today;
        }
        public static int GetTotalDays() {
            return _totalDays;
        }
        public static void SetTotalDays(int elapseDays) {
            _totalDays = elapseDays;
        }
    }
}