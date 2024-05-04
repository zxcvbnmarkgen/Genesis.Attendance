using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Teacher
{
    public class GetTeacherListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
