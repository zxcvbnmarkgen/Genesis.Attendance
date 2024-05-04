using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Genesis.Attendance.Attendance.Department
{
    public interface IDepartmentAppService : IApplicationService
    {
        Task<DepartmentDto> GetAsync(Guid id);

        Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input);

        Task<DepartmentDto> CreateAsync(CreateUpdateDepartmentDto input);

        Task UpdateAsync(Guid id, CreateUpdateDepartmentDto input);

        Task DeleteAsync(Guid id);
    }
}
