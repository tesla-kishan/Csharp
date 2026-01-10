class InsuranceService
    {
        public double ApplyCoverage(string percent)
        {
            if (double.TryParse(percent, out double p))
                return p / 100;

            return 0;
        }
    }