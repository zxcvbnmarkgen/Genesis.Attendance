using Microsoft.AspNetCore.Builder;
using Genesis.Attendance;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AttendanceWebTestModule>();

public partial class Program
{
}
