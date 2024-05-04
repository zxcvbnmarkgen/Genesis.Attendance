using Volo.Abp.Modularity;

namespace Genesis.Attendance;

/* Inherit from this class for your domain layer tests. */
public abstract class AttendanceDomainTestBase<TStartupModule> : AttendanceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
