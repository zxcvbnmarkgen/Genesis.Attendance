using Xunit;

namespace Genesis.Attendance.EntityFrameworkCore;

[CollectionDefinition(AttendanceTestConsts.CollectionDefinitionName)]
public class AttendanceEntityFrameworkCoreCollection : ICollectionFixture<AttendanceEntityFrameworkCoreFixture>
{

}
