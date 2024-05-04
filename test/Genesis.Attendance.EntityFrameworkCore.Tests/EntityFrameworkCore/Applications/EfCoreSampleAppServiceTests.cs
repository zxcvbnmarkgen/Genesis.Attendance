using Genesis.Attendance.Samples;
using Xunit;

namespace Genesis.Attendance.EntityFrameworkCore.Applications;

[Collection(AttendanceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AttendanceEntityFrameworkCoreTestModule>
{

}
