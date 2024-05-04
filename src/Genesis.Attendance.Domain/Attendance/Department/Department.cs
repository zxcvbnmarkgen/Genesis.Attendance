using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Genesis.Attendance.Attendance.Department
{
    public class Department : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
