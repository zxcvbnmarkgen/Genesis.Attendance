using Genesis.Attendance.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Genesis.Attendance.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AttendanceController : AbpControllerBase
{
    protected AttendanceController()
    {
        LocalizationResource = typeof(AttendanceResource);
    }
}
