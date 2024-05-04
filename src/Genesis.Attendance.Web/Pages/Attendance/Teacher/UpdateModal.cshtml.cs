using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Attendance.Attendance.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using static Genesis.Attendance.Web.Pages.Attendance.Teacher.CreateModalModel;

namespace Genesis.Attendance.Web.Pages.Attendance.Teacher
{
    public class UpdateModalModel : AttendancePageModel
    {

        [BindProperty]
        public EditTeacherViewModel modelDto { get; set; }
        public List<SelectListItem> Departments { get; set; }

        private readonly ITeacherAppService _appService;

        public UpdateModalModel(ITeacherAppService appService)
        {
            _appService = appService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var getModelDto = await _appService.GetAsync(id);
            modelDto = ObjectMapper.Map<TeacherDto, EditTeacherViewModel>(getModelDto);

            var modelLookup = await _appService.GetDepartmentLookupAsync();
            Departments = modelLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _appService.UpdateAsync(
                modelDto.Id,
                ObjectMapper.Map<EditTeacherViewModel, CreateUpdateTeacherDto>(modelDto)
            );

            return NoContent();
        }

        public class EditTeacherViewModel
        {
            [HiddenInput]
            [BindProperty(SupportsGet = true)]
            public Guid Id { get; set; }
            [Required]
            [Display(Name = "Full Name")]
            public string FullName { get; set; } = string.Empty;
            [Required]
            [Display(Name = "Position")]
            public string Position { get; set; } = string.Empty;
            [Required]
            [SelectItems(nameof(Departments))]
            [Display(Name = "Department")]
            public Guid DepartmentId { get; set; }
        }
    }
}
