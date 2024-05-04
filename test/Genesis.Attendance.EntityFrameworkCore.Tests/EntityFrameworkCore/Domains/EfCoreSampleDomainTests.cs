using Genesis.Attendance.Samples;
using Xunit;

namespace Genesis.Attendance.EntityFrameworkCore.Domains;

[Collection(AttendanceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AttendanceEntityFrameworkCoreTestModule>
{

}
