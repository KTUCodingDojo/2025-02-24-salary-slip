

namespace SalarySlipGenerator
{
    public class SalarySlipGenerator
    {
        const decimal PSDRate = 6.98M;
        const decimal VSDRate = 12.52M;
        const decimal VSDPensionRate = 3M;


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
            if(employee.IsSavingForPension)
            {
                return employee.GrossSalary * (VSDRate + VSDPensionRate) / 100;
            }

            return employee.GrossSalary * VSDRate / 100;
        }
    }
}
