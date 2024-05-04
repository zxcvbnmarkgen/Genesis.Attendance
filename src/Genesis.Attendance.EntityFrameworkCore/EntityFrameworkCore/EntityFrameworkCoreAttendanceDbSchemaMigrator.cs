using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Genesis.Attendance.Data;
using Volo.Abp.DependencyInjection;

namespace Genesis.Attendance.EntityFrameworkCore;

public class EntityFrameworkCoreAttendanceDbSchemaMigrator
    : IAttendanceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAttendanceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AttendanceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AttendanceDbContext>()
            .Database
            .MigrateAsync();
    }
}
