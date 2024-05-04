using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Genesis.Attendance.Web;

[Dependency(ReplaceServices = true)]
public class AttendanceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Attendance";
}
