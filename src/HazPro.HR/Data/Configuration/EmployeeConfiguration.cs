using HazPro.HR.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HazPro.HR.Data.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(employee => employee.EmployeeId);
        //builder.Property(employee => employee.EmployeeId).HasColumnName("EmployeeId").ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .IsRequired().HasMaxLength(100);
        builder.Property(e => e.LastName)
            .IsRequired().HasMaxLength(100);

        builder.Property(e => e.DateOfHire)
            .IsRequired();

        builder.Property(e => e.Position)
            .HasMaxLength(100);

        builder.Property(e => e.DepartmentName)
            .IsRequired();
        
        builder.Property(e => e.HourlyWage)
            .HasColumnType("decimal(18,2)");
        
        //Generate sample data
        builder.HasData(
            new List<Employee>()
            {
                new Employee(1, "John", "Doe", new DateTime(2020,1,15), "Software Engineer", "IT", 30.00m),
                new Employee(2, "Jane", "Doe", new DateTime(2019,3,10), "Project Manager", "Management", 40.00m),
            }
        );
    }
}