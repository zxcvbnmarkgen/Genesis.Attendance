using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Genesis.Attendance.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Genesis.Attendance.Attendance.Teacher
{
    public class EfCoreTeacherRepository : EfCoreRepository<AttendanceDbContext, Teacher, Guid>, ITeacherRepository
    {
        public EfCoreTeacherRepository(IDbContextProvider<AttendanceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<List<Teacher>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), m =>
                   m.FullName.Contains(filter) ||
                   m.Position.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
