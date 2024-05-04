using System;
using System.Collections.Generic;
using System.Text;
using Genesis.Attendance.Localization;
using Volo.Abp.Application.Services;

namespace Genesis.Attendance;

/* Inherit your application services from this class.
 */
public abstract class AttendanceAppService : ApplicationService
{
    protected AttendanceAppService()
    {
        LocalizationResource = typeof(AttendanceResource);
    }
}
