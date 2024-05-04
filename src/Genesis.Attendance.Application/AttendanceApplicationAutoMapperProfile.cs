using AutoMapper;
using Genesis.Attendance.Attendance.Department;
using Genesis.Attendance.Attendance.Teacher;

namespace Genesis.Attendance;

public class AttendanceApplicationAutoMapperProfile : Profile
{
    public AttendanceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Department, DepartmentDto>();
        CreateMap<CreateUpdateDepartmentDto, Department>();

        CreateMap<Teacher, TeacherDto>();
        CreateMap<CreateUpdateTeacherDto, Teacher>();
        CreateMap<Department, DepartmentLookupDto>();
    }
}
