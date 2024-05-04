using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Genesis.Attendance.Attendance.Teacher
{
    public interface ITeacherRepository : IRepository<Teacher, Guid>
    {
        Task<List<Teacher>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
