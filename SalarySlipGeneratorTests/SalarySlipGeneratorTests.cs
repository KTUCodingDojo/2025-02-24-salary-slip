﻿using System.Text;
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
            decimal actualVSD = _generator.CalculatePSD(employee);

            // Asserts
            actualVSD.Should().Be(expectedPSD);
        }

        [Theory]
        [InlineData("E001", "Jonas Jonaitis", 1000, false, 125.20)]
        [InlineData("E001", "Jonas Jonaitis", 2000, false, 250.40)]
        [InlineData("E001", "Jonas Jonaitis", 1000, true, 155.20)]
        [InlineData("E001", "Jonas Jonaitis", 10544.4, false, 1320.16)]
        [InlineData("E001", "Jonas Jonaitis", 11000, false, 1320.16)]
        [InlineData("E001", "Jonas Jonaitis", 11000, true, 1636.49)]
        public void CalculateVSD_WithEmployeeParameters_ReturnsCorrectVSD(
            string id,
            string fullName,
            decimal grossSalary,
            bool isSavingForPension,
            decimal expectedVSD)
        {
            // Arrange
            var employee = new Employee(id, fullName, grossSalary, isSavingForPension);

            // Act
            decimal actualVSD = _generator.CalculateVSD(employee);

            // Asserts
            actualVSD.Should().Be(expectedVSD);
        }

        [Theory]
        [InlineData("E001", "Jonas Jonaitis", 500, false, 747)]
        [InlineData("E001", "Jonas Jonaitis", 747, false, 747)]
        [InlineData("E001", "Jonas Jonaitis", 1000, false, 747)]
        [InlineData("E001", "Jonas Jonaitis", 1038, false, 747)]
        [InlineData("E001", "Jonas Jonaitis", 1100, false, 716.62)]        
        [InlineData("E001", "Jonas Jonaitis", 1200, false, 667.62)]
        [InlineData("E001", "Jonas Jonaitis", 2300, false, 128.62)]
        [InlineData("E001", "Jonas Jonaitis", 2387.29, false, 85.85)]
        [InlineData("E001", "Jonas Jonaitis", 2400, false, 83.56)]
        [InlineData("E001", "Jonas Jonaitis", 2800, false, 11.56)]
        [InlineData("E001", "Jonas Jonaitis", 2864.22, false, 0)]
        [InlineData("E001", "Jonas Jonaitis", 4000, false, 0)]

        public void CalculateNPD_WithEmployeeParameters_ReturnsCorrectNPD(
            string id,
            string fullName,
            decimal grossSalary,
            bool isSavingForPension,
            decimal expectedNPD)
        {
            // Arrange
            var employee = new Employee(id, fullName, grossSalary, isSavingForPension);

            // Act
            decimal actualNPD = _generator.CalculateNPD(employee);

            // Asserts
            actualNPD.Should().Be(expectedNPD);
        }

        [Theory]
        [InlineData("E001", "Jonas Jonaitis", 500, true, 0)]
        [InlineData("E001", "Jonas Jonaitis", 747, true, 0)]
        [InlineData("E001", "Jonas Jonaitis", 1000, false, 50.60)]
        [InlineData("E001", "Jonas Jonaitis", 2000, false, 344.88)]
        [InlineData("E001", "Jonas Jonaitis", 3000, false, 600)]
        public void CalculateGPM_WithEmployeeParameters_ReturnsCorrectVSD(
            string id,
            string fullName,
            decimal grossSalary,
            bool isSavingForPension,
            decimal expectedGPM)
        {
            // Arrange
            var employee = new Employee(id, fullName, grossSalary, isSavingForPension);

            // Act
            decimal actualGPM = _generator.CalculateGPM(employee);

            // Asserts
            actualGPM.Should().Be(expectedGPM);
        }
    }
}