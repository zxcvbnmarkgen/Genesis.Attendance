using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Genesis.Attendance.Attendance.Department;

namespace Genesis.Attendance.Web.Pages.Attendance.Attendance
{
    public class CreateModalModel : AttendancePageModel
    {
        [BindProperty]
        public CreateUpdateDepartmentDto modelDto { get; set; }

        private readonly IDepartmentAppService _appService;

        public CreateModalModel(IDepartmentAppService appService)
        {
            _appService = appService;
        }

        public void OnGet()
        {
            modelDto = new CreateUpdateDepartmentDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _appService.CreateAsync(modelDto);
            return NoContent();
        }
    }
}
