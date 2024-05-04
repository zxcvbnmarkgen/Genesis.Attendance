using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Department
{
    public class CreateUpdateDepartmentDto
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; } = string.Empty;
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
