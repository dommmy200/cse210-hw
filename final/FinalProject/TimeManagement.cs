using System;

namespace FinancialPrudence {
    public class TimeManagement {
        private DateTime _timeStamp = DateTime.Now;
        private Dictionary<string, int> _monthlyList = new Dictionary<string, int>(5) {
            {"One Month", 30},
            {"One Quarter", 90},
            {"Second Quarter", 180},
            {"Third Quarter", 270},
            {"One Year", 360}
        };
        public int GetTimestamp() {
            var day = _timeStamp.Day;
            return day;
        }
        public int ElapsedTimestamp(int month = 30) {
            var oldTimestamp = GetTimestamp();
            var newTimestamp = oldTimestamp + month;
            return newTimestamp;
        }
    }
}