using Volo.Abp.Modularity;

namespace Genesis.Attendance;

public abstract class AttendanceApplicationTestBase<TStartupModule> : AttendanceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
