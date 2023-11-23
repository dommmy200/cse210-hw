using System;

namespace FinancialPrudence {
    public class Savings {
        private float _emergencyFund;
        private float _cashSavings;
        private float _healthInsure;
        private float _vacation;
        private float _mortgage;
        private float _retirement;
        private TimeManagement _time;
        public float GetEmergencyfund() {
            return _emergencyFund;
        }
        public float GetCashSavings() {
            return _cashSavings;
        }
        public float GetHealthInsure() {
            return _healthInsure;
        }
        public float GetRetirement() {
            return _retirement;
        }
        public float GetMortgage() {
            return _mortgage;
        }
        public float GetVacation() {
            return _vacation;
        }
        public Savings(float eM = 0, float cs = 0, float hI = 0, float vac = 0, float mG = 0, float rT = 0) {
            _cashSavings = cs;
            _emergencyFund = eM;
            _healthInsure = hI;
            _vacation = vac;
            _mortgage = mG;
            _retirement = rT;
        }

    } 
}