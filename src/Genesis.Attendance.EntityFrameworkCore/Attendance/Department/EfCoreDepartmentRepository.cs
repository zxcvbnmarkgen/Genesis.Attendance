using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Genesis.Attendance.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Genesis.Attendance.Attendance.Department
{
    public class EfCoreDepartmentRepository : EfCoreRepository<AttendanceDbContext, Department, Guid>, IDepartmentRepository
    {
        public EfCoreDepartmentRepository(IDbContextProvider<AttendanceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<List<Department>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), m =>
                   m.Name.Contains(filter) ||
                   m.ShortName.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
