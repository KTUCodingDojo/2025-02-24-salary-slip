namespace SalarySlipGenerator
{
    public class SalarySlipGenerator
    {
        //NOTE: do not modify signature
        public SalarySlip GenerateFor(Employee employee)
        {
            var salarySlip = new SalarySlip();

            salarySlip.GrossSalary = employee.GrossSalary;

            salarySlip.PSD = salarySlip.GrossSalary * 0.0698M;

            return salarySlip;
        }
    }
}
