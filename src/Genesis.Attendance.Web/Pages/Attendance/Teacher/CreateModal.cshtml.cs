using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Genesis.Attendance.Attendance.Teacher;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Genesis.Attendance.Web.Pages.Attendance.Teacher
{
    public class CreateModalModel : AttendancePageModel
    {
        [BindProperty]
        public CreateTeacherViewModel modelDto { get; set; }
        public List<SelectListItem> Departments { get; set; }

        private readonly ITeacherAppService _appService;

        public CreateModalModel(ITeacherAppService appService)
        {
            _appService = appService;
        }

        public async Task OnGetAsync()
        {
            modelDto = new CreateTeacherViewModel();

            var modelLookup = await _appService.GetDepartmentLookupAsync();
            Departments = modelLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _appService.CreateAsync(ObjectMapper.Map<CreateTeacherViewModel, CreateUpdateTeacherDto>(modelDto));
            return NoContent();
        }

        public class CreateTeacherViewModel
        {
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
