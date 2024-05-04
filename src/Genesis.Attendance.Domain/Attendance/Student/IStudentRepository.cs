using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Genesis.Attendance.Attendance.Student
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        Task<List<Student>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
