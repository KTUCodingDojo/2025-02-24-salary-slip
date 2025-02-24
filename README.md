# KTU Coding Dojo – February 2025 - Salary Slip

Welcome to the **KTU Coding Dojo**! This event is a collaborative coding session where participants solve a small programming challenge (called a **kata**) to practice, learn, and improve their skills in a fun and relaxed environment.

## Event Details

📅 **Date**: February 24, 2025  
📍 **Location**: Studentų g. 50, 512
🔗 [Facebook Event](https://www.facebook.com/events/1591054518178775/)

## Kata for This Session

Inspired by [this kata](https://github.com/sandromancuso/salaryslipkata)

### Problem Description
We need to generate a monthly salary slip for each employee. A typical Lithuanian salary slip includes:

- **Employee Details:**
    - Darbuotojo ID
    - Vardas Pavardė

- **Monthly Salary Details:**
    - **Priskaičiuota:** Monthly Gross Salary
    - **Pritaikytas NPD:** Non-taxable Income (Neapmokestinamų pajamų dydis)
    - **GPM:** Gyventojų pajamų mokestis (Income Tax)
    - **PSD:** Privalomas sveikatos draudimas (Health Insurance)
    - **VSD:** Valstybinis socialinis draudimas (Social Insurance)
    - **Išskaičiuota:** Total Deductions
    - **Išmokėti:** Net Pay

```text
Darbuotojo ID: E001
Vardas Pavardė: Jonas Jonaitis
Priskaičiuota: 1038.00
Pritaikytas NPD: 747.00
GPM: 58.20
PSD: 72.45
VSD: 129.96
Išskaičiuota: 260.61
Išmokėti: 777.39
```

The entry point is defined as:

```csharp
public class SalarySlipGenerator
{
    public SalarySlip GenerateFor(Employee employee);
}
```

### Acceptance Criteria

- **Input Requirements:**  
  The salary slip generator shall accept an employee with the following details:
    - **Employee ID** (Darbuotojo ID)
    - **Employee Name** (Vardas Pavardė)
    - **Annual Gross Salary**
    - **Extra Pension Saving Flag** (indicates if the employee opts for additional pension saving)

### Calculation Logic Rules

#### Definitions and Constants
- **DU**: Darbo užmokestis (Monthly Salary)
- **VDU**: Vidutinis darbo užmokestis (Average Monthly Wage) - 2108.88
- **MMA**: Minimal mėnesio alga (Minimum Monthly Wage) - 1038 
- **GPM Rate**: Gyventojų pajamų mokestis (Income Tax Rate) - 20%
- **NPD**: Neapmokestinamų pajamų dydis (Non-Taxable Income) - 747

#### Applied NPD (Pritaikytas NPD)

##### 1. Žemų pajamų NPD (For Low Incomes)
- **Condition:** When **DU ≤ MMA** (i.e. DU ≤ 1038)
- **Applied NPD:** 747

##### 2. Vidutinių pajamų NPD (For Moderate Incomes)
- **Condition:** When **DU > MMA** and **DU ≤ 2387.29**
- **Formula:**  747 - 0.49 * (DU - 1038)

##### 3. Aukštesnių pajamų NPD (For Higher Incomes)
- **Condition:** When **DU > 2387.29**
- **Formula:**  400 - 0.18 * (DU - 642)
- **Note:** If the calculated NPD is negative, it is set to 0.

#### GPM 
- **Taxable Income:** max(0, DU - Pritaikytas NPD)
- **GPM:** Taxable Income * 0.2

##### VSD
- **Standard Rate:** 12.52% of DU
- **With Extra Pension Saving (VSD su PK):** 15.52% of DU
- **Cap:** Contributions are calculated on the lesser of DU and (5 * VDU).

##### PSD
- **Rate:** 6.98% of DU

### References
- https://www.sodra.lt/lt/skaiciuokles/darbo_vietos_skaiciuokle
- https://e-seimas.lrs.lt/portal/legalAct/lt/TAD/c6c72291b3b011efbb3fe9794b4a33e2?jfwid=-38uu7i4uz
- https://www.sodra.lt/uploads/documents/files/Imoku%20tarifai%20draudejams%20turintiems%20samdomu%20darbuotoju(2).pdf

  
