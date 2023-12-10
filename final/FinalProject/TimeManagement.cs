using System;

namespace FinancialPrudence {
    public class TimeManagement {
        private int _totalDays;
        public static string GetToday() {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }
        public void SetTotalDays(int elapseDays) {
            _totalDays = elapseDays;
        }
    }
}