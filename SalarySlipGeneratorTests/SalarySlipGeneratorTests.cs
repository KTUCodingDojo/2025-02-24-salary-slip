using System.Text;
using Xunit;
using Assert = Xunit.Assert;


namespace SalarySlipGenerator.Tests
{
    public class SalarySlipGeneratorTests
    {
        private readonly SalarySlipGenerator _generator;

        public SalarySlipGeneratorTests()
        {
            _generator = new SalarySlipGenerator();
        }

        [Fact]
        public void GenerateFor_WithValidEmployee_ReturnsNonNullSalarySlip()
        {
            // Arrange
            var employee = new Employee("E001", "Jonas Jonaitis", 1038m, false);

            // Act
            var salarySlip = _generator.GenerateFor(employee);

            // Assert
            Assert.NotNull(salarySlip);
        }

        [Theory]
        [InlineData("E001", "Jonas Jonaitis", 1038, false)]
        public void GenerateFor_WithEmployeeParameters_ReturnsNonNullSalarySlip(
            string id,
            string fullName,
            decimal grossSalary,
            bool isSavingForPension)
        {
            // Arrange
            var employee = new Employee(id, fullName, grossSalary, isSavingForPension);

            // Act
            var salarySlip = _generator.GenerateFor(employee);

            // Assert
            Assert.NotNull(salarySlip);
        }

        [Theory]
        [InlineData("E001", "Jonas Jonaitis", 1000, false, 69.8)]
        [InlineData("E001", "Jonas Jonaitis", 2000, false, 139.6)]
        public void CalculatePSD_WithEmployeeParameters_ReturnsCorrectPSD(
            string id,
            string fullName,
            decimal grossSalary,
            bool isSavingForPension,
            decimal expectedPSD)
        {
            // Arrange
            var employee = new Employee(id, fullName, grossSalary, isSavingForPension);

            // Act
            decimal ActualPSD = _generator.CalculatePSD(employee);

            // Asserts
            ActualPSD.Should().Be(expectedPSD);
        }
    }
}