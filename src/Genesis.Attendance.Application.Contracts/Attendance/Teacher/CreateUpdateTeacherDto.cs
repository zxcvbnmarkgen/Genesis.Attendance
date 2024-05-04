using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Teacher
{
    public class CreateUpdateTeacherDto
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }
    }
}
