using Genesis.Attendance.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Genesis.Attendance.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AttendanceEntityFrameworkCoreModule),
    typeof(AttendanceApplicationContractsModule)
    )]
public class AttendanceDbMigratorModule : AbpModule
{
}
