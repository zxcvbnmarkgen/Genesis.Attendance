using System.Threading.Tasks;
using Genesis.Attendance.Attendance.Department;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.Attendance.Web.Pages.Attendance.Student
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
