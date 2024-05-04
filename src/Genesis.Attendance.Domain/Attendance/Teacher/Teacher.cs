using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Genesis.Attendance.Attendance.Teacher
{
    public class Teacher : FullAuditedAggregateRoot<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
    }
}
