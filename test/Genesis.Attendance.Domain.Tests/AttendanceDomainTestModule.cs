using Volo.Abp.Modularity;

namespace Genesis.Attendance;

[DependsOn(
    typeof(AttendanceDomainModule),
    typeof(AttendanceTestBaseModule)
)]
public class AttendanceDomainTestModule : AbpModule
{

}
