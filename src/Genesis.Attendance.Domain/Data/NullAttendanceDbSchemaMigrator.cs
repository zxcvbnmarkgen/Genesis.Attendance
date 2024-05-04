using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Genesis.Attendance.Data;

/* This is used if database provider does't define
 * IAttendanceDbSchemaMigrator implementation.
 */
public class NullAttendanceDbSchemaMigrator : IAttendanceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
