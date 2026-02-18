using AutoMapper;
using HazPro.HR.Model;

namespace HazPro.HR.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        //From Entity to DTO
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dto =>
                dto.FullName, opt => opt.MapFrom<FullNameResolver>())
            .ForMember(dto =>
                dto.Department, opt => opt.MapFrom(src => src.DepartmentName));
        
        //From DTO to Entity
        CreateMap<EmployeeDto, Employee>()
            .ForMember(entity =>
                entity.FirstName, opt => opt.MapFrom<FirstNameResolver>())
            .ForMember(entity =>
                entity.LastName, opt => opt.MapFrom<LastNameResolver>())
            .ForMember(entity =>
                entity.DepartmentName, opt => opt.MapFrom(src => src.Department));
    }
    
    private class LastNameResolver : IValueResolver<EmployeeDto, Employee, string>
    {
        public string Resolve(EmployeeDto source, Employee destination, string destMember, ResolutionContext context)
        {
            return source.FullName.Split(" ").Skip(1).FirstOrDefault() ?? string.Empty;
        }
    }

    private class FirstNameResolver : IValueResolver<EmployeeDto, Employee, string>
    {
        public string Resolve(EmployeeDto source, Employee destination, string destMember, ResolutionContext context)
        {
            return source.FullName.Split(" ").FirstOrDefault() ?? string.Empty;
        }
    }

    private class FullNameResolver : IValueResolver<Employee, EmployeeDto, string>
    {
        public string Resolve(Employee source, EmployeeDto destination, string destMember, ResolutionContext context)
        {
            return source.FirstName + " " + source.LastName;
        }
    }
}

