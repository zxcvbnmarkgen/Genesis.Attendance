using Genesis.Attendance.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Genesis.Attendance.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AttendancePageModel : AbpPageModel
{
    protected AttendancePageModel()
    {
        LocalizationResourceType = typeof(AttendanceResource);
    }
}
