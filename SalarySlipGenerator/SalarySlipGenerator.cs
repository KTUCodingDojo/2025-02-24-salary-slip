


namespace SalarySlipGenerator
{
    public class SalarySlipGenerator
    {
        const decimal PSDRate = 6.98M;
        const decimal VSDRate = 12.52M;
        const decimal VSDPensionRate = 3M;
        const decimal MMA = 1038M;
        const decimal NPD = 747M;
        const decimal NPDMiddleBound = 2387.89M;
        const decimal VDU = 2108.88M;

        //NOTE: do not modify signature
        public SalarySlip GenerateFor(Employee employee)
        {
            var salarySlip = new SalarySlip();

            salarySlip.GrossSalary = employee.GrossSalary;

            salarySlip.PSD = CalculatePSD(employee);

            return salarySlip;
        }

        public decimal CalculatePSD(Employee employee)
        {
            return employee.GrossSalary * PSDRate / 100;
        }

        public decimal CalculateVSD(Employee employee)
        {
            decimal effectiveSalary = Math.Min(employee.GrossSalary, 5*VDU);
            if (employee.IsSavingForPension)
            {
                return Math.Round(effectiveSalary * (VSDRate + VSDPensionRate) / 100, 2);
            }

            return Math.Round(effectiveSalary * VSDRate / 100, 2);
        }

        public decimal CalculateNPD(Employee employee)
        {
            if (employee.GrossSalary < MMA)
            {
                return NPD;
            }
            else if (employee.GrossSalary < NPDMiddleBound)
            {
                return Math.Round(NPD - 0.49M * (employee.GrossSalary - MMA), 2);
            }

            return Math.Max(0, Math.Round(400 - 0.18M * (employee.GrossSalary - 642), 2));
        }

        public decimal CalculateGPM(Employee employee)
        {
            return Math.Max(0, Math.Round( (employee.GrossSalary - CalculateNPD(employee)) * 0.2M , 2));
        }
    }
}
