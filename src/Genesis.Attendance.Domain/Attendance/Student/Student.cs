using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Genesis.Attendance.Attendance.Student
{
    public class Student : FullAuditedAggregateRoot<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string CompleteAddress { get; set; } = string.Empty;
        public string GradeLevel { get; set; } = string.Empty;
        public string GardianName { get; set; } = string.Empty;
        public string GardianEmail { get; set; } = string.Empty;
        public string GardianContactNo { get; set; } = string.Empty;
        public Guid TeacherId { get; set; }
        public Guid? UserId { get; set; }
    }
}
