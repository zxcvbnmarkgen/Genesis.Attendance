using Genesis.Attendance.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Genesis.Attendance.Permissions;

public class AttendancePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AttendancePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AttendancePermissions.MyPermission1, L("Permission:MyPermission1"));

        var departmentPermission = myGroup.AddPermission(AttendancePermissions.Department.Default, L("Permission:Department"));
        departmentPermission.AddChild(AttendancePermissions.Department.Create, L("Permission:Department.Create"));
        departmentPermission.AddChild(AttendancePermissions.Department.Edit, L("Permission:Department.Edit"));
        departmentPermission.AddChild(AttendancePermissions.Department.Delete, L("Permission:Department.Delete"));

        var coursePermission = myGroup.AddPermission(AttendancePermissions.Course.Default, L("Permission:Course"));
        coursePermission.AddChild(AttendancePermissions.Course.Create, L("Permission:Course.Create"));
        coursePermission.AddChild(AttendancePermissions.Course.Edit, L("Permission:Course.Edit"));
        coursePermission.AddChild(AttendancePermissions.Course.Delete, L("Permission:Course.Delete"));

        var teacherPermission = myGroup.AddPermission(AttendancePermissions.Teacher.Default, L("Permission:Teacher"));
        teacherPermission.AddChild(AttendancePermissions.Teacher.Create, L("Permission:Teacher.Create"));
        teacherPermission.AddChild(AttendancePermissions.Teacher.Edit, L("Permission:Teacher.Edit"));
        teacherPermission.AddChild(AttendancePermissions.Teacher.Delete, L("Permission:Teacher.Delete"));

        var studentPermission = myGroup.AddPermission(AttendancePermissions.Student.Default, L("Permission:Student"));
        studentPermission.AddChild(AttendancePermissions.Student.Create, L("Permission:Student.Create"));
        studentPermission.AddChild(AttendancePermissions.Student.Edit, L("Permission:Student.Edit"));
        studentPermission.AddChild(AttendancePermissions.Student.Delete, L("Permission:Student.Delete"));

        var attendancePermission = myGroup.AddPermission(AttendancePermissions.Attendance.Default, L("Permission:Attendance"));
        attendancePermission.AddChild(AttendancePermissions.Attendance.Create, L("Permission:Attendance.Create"));
        attendancePermission.AddChild(AttendancePermissions.Attendance.Edit, L("Permission:Attendance.Edit"));
        attendancePermission.AddChild(AttendancePermissions.Attendance.Delete, L("Permission:Attendance.Delete"));


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AttendanceResource>(name);
    }
}
