namespace Genesis.Attendance.Permissions;

public static class AttendancePermissions
{
    public const string GroupName = "Attendance";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Department
    {
        public const string Default = GroupName + ".Department";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Course
    {
        public const string Default = GroupName + ".Course";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Teacher
    {
        public const string Default = GroupName + ".Teacher";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Student
    {
        public const string Default = GroupName + ".Student";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Attendance
    {
        public const string Default = GroupName + ".Attendance";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
