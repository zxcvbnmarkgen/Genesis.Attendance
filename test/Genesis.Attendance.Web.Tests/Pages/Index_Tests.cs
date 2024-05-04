using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Genesis.Attendance.Pages;

public class Index_Tests : AttendanceWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
