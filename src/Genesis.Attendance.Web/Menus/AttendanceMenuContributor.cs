using System.Threading.Tasks;
using Genesis.Attendance.Localization;
using Genesis.Attendance.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Genesis.Attendance.Web.Menus;

public class AttendanceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AttendanceResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AttendanceMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(new ApplicationMenuItem("Attendance.Department",l["Menu:Department"], icon: "fa fa-building-o", url: "/Attendance/Department"));
        context.Menu.AddItem(new ApplicationMenuItem("Attendance.Course", l["Menu:Course"], icon: "fa fa-book", url: "/Attendance/Course"));
        context.Menu.AddItem(new ApplicationMenuItem("Attendance.Teacher", l["Menu:Teacher"], icon: "fa fa-user", url: "/Attendance/Teacher"));
        context.Menu.AddItem(new ApplicationMenuItem("Attendance.Student", l["Menu:Student"], icon: "fa fa-users", url: "/Attendance/Student"));
        context.Menu.AddItem(new ApplicationMenuItem("Attendance.Attendance", l["Menu:Attendance"], icon: "fa fa-address-card-o", url: "/Attendance/Attendance"));

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
