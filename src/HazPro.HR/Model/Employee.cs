using Ardalis.GuardClauses;

namespace HazPro.HR.Model;

public class Employee
{
    public int EmployeeId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfHire { get; private set; }
    public string Position { get; private set; }
    public string DepartmentName { get; private set; }
    public decimal HourlyWage { get; set; }

    public Employee(int employeeId, string firstName, string lastName, DateTime dateOfHire, string position, string departmentName, decimal hourlyWage)
    {
        EmployeeId = employeeId;
        FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        LastName = lastName;
        DateOfHire = dateOfHire;
        Position = position;
        DepartmentName = departmentName;
        HourlyWage = Guard.Against.OutOfRange<decimal>(hourlyWage, nameof(hourlyWage), 10, 100 );
    }
    
    public void UpdateHourlyWage(decimal newHourlyWage)
    {
        HourlyWage = Guard.Against.OutOfRange<decimal>(newHourlyWage, nameof(newHourlyWage), 10, 100 );
    }
}