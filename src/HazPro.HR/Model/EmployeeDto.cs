namespace HazPro.HR.Model;

//public record EmployeeDto(int EmployeeId, string FullName, DateTime DateOfHire, string Position, string Department);
public record EmployeeDto
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfHire { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public decimal HourlyWage { get; set; }

    public EmployeeDto()
    {
        
    }
    
    public EmployeeDto(int employeeId, string FullName, DateTime DateOfHire, string Position, string Department, decimal HourlyWage) : this()
    {
        EmployeeId = employeeId;
        this.FullName = FullName;
        this.DateOfHire = DateOfHire;
        this.Position = Position;
        this.Department = Department;
        this.HourlyWage = HourlyWage;
    }
}