﻿using System;
using Volo.Abp.Application.Dtos;

namespace Genesis.Attendance.Attendance.Teacher
{
    public class DepartmentLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
