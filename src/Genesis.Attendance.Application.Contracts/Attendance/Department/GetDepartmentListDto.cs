using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Department
{
    public class GetDepartmentListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
