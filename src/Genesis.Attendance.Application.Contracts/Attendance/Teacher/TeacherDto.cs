using System;
using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Teacher
{
    public class TeacherDto : EntityDto<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}
