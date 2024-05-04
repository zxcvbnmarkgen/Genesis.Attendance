using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Genesis.Attendance.Attendance.Teacher
{
    //public interface ITeacherAppService : IApplicationService
    //{
    //    Task<TeacherDto> GetAsync(Guid id);

    //    Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input);

    //    Task<TeacherDto> CreateAsync(CreateUpdateTeacherDto input);

    //    Task UpdateAsync(Guid id, CreateUpdateTeacherDto input);

    //    Task DeleteAsync(Guid id);

    //    Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();
    //}

    public interface ITeacherAppService :
    ICrudAppService< //Defines CRUD methods
        TeacherDto, //Used to show books
        Guid, //Primary key of the book entity
        GetTeacherListDto, //Used for paging/sorting
        CreateUpdateTeacherDto> //Used to create/update a book
    {
        Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();
    }
}
