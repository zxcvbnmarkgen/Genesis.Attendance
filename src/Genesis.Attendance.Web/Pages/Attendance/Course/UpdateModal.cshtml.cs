using System;
using System.Threading.Tasks;
using Genesis.Attendance.Attendance.Department;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.Attendance.Web.Pages.Attendance.Course
{
    public class UpdateModalModel : AttendancePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateDepartmentDto modelDto { get; set; }

        private readonly IDepartmentAppService _appService;

        public UpdateModalModel(IDepartmentAppService appService)
        {
            _appService = appService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var getModelDto = await _appService.GetAsync(id);
            modelDto = ObjectMapper.Map<DepartmentDto, CreateUpdateDepartmentDto>(getModelDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _appService.UpdateAsync(Id, modelDto);
            return NoContent();
        }
    }
}
