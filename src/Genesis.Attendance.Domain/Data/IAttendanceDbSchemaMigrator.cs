using System.Threading.Tasks;

namespace Genesis.Attendance.Data;

public interface IAttendanceDbSchemaMigrator
{
    Task MigrateAsync();
}
