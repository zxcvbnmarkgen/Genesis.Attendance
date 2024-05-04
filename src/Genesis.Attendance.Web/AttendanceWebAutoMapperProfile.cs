using AutoMapper;
using Genesis.Attendance.Attendance.Department;
using Genesis.Attendance.Attendance.Teacher;

namespace Genesis.Attendance.Web;

public class AttendanceWebAutoMapperProfile : Profile
{
    public AttendanceWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<DepartmentDto, CreateUpdateDepartmentDto>();

        CreateMap<Pages.Attendance.Teacher.CreateModalModel.CreateTeacherViewModel, CreateUpdateTeacherDto>();
        CreateMap<TeacherDto, Pages.Attendance.Teacher.UpdateModalModel.EditTeacherViewModel>();
        CreateMap<Pages.Attendance.Teacher.UpdateModalModel.EditTeacherViewModel, CreateUpdateTeacherDto>();
    }
}
