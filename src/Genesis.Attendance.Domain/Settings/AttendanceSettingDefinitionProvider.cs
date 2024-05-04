using Volo.Abp.Settings;

namespace Genesis.Attendance.Settings;

public class AttendanceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AttendanceSettings.MySetting1));
    }
}
