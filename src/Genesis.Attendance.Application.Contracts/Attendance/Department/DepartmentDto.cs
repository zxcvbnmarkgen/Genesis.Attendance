using System;
using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Department
{
    public class DepartmentDto : EntityDto<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
