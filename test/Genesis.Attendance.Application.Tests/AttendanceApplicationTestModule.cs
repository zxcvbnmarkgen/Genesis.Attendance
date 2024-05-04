using Volo.Abp.Modularity;

namespace Genesis.Attendance;

[DependsOn(
    typeof(AttendanceApplicationModule),
    typeof(AttendanceDomainTestModule)
)]
public class AttendanceApplicationTestModule : AbpModule
{

}
