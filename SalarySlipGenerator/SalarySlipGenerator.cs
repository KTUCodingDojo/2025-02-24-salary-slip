
namespace SalarySlipGenerator
{
    public class SalarySlipGenerator
    {
        const decimal PSDRate = 6.98M;
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
    }
}
