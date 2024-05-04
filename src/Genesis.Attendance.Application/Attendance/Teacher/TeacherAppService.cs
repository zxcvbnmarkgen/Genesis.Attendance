using AutoMapper.Internal.Mappers;
using System.Linq;
using System.Linq.Dynamic.Core;
using Genesis.Attendance.Attendance.Department;
using Genesis.Attendance.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Genesis.Attendance.Attendance.Teacher
{
    [Authorize(AttendancePermissions.Teacher.Default)]
    public class TeacherAppService :
    CrudAppService<
        Teacher, //The Book entity
        TeacherDto, //Used to show books
        Guid, //Primary key of the book entity
        GetTeacherListDto, //Used for paging/sorting
        CreateUpdateTeacherDto>, //Used to create/update a book
    ITeacherAppService //implement the IBookAppService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public TeacherAppService(IRepository<Teacher, Guid> repository, IDepartmentRepository departmentRepository)
            : base(repository)
        {
            _departmentRepository = departmentRepository;
        }

        public override async Task<TeacherDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from teacher in queryable
                        join department in await _departmentRepository.GetQueryableAsync() on teacher.DepartmentId equals department.Id
                        where teacher.Id == id
                        select new { teacher, department };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Teacher), id);
            }

            var modelDto = ObjectMapper.Map<Teacher, TeacherDto>(queryResult.teacher);
            modelDto.Department = queryResult.department.Name;
            return modelDto;
        }


        public override async Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from teacher in queryable
                        join department in await _departmentRepository.GetQueryableAsync() on teacher.DepartmentId equals department.Id
                        select new { teacher, department };

            //Paging
            query = query
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), m =>
                   m.teacher.FullName.Contains(input.Filter) ||
                   m.teacher.Position.Contains(input.Filter)
                    )
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var modelDtos = queryResult.Select(x =>
            {
                var modelDto = ObjectMapper.Map<Teacher, TeacherDto>(x.teacher);
                modelDto.Department = x.department.Name;
                return modelDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<TeacherDto>(totalCount, modelDtos);
        }


        public async Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync()
        {
            var modelDto = await _departmentRepository.GetListAsync();

            return new ListResultDto<DepartmentLookupDto>(ObjectMapper.Map<List<Department.Department>, List<DepartmentLookupDto>>(modelDto));
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"teacher.{nameof(Teacher.FullName)}";
            }

            if (sorting.Contains("department", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "department",
                    "department.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"teacher.{sorting}";
        }
    }

    //public class TeacherAppService : AttendanceAppService, ITeacherAppService
    //{
    //    private readonly ITeacherRepository _repository;
    //    private readonly IDepartmentRepository _departmentRepository;

    //    public TeacherAppService(ITeacherRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    //...SERVICE METHODS HERE...

    //    public async Task<TeacherDto> GetAsync(Guid id)
    //    {
    //        var modelDto = await _repository.GetAsync(id);
    //        return ObjectMapper.Map<Teacher, TeacherDto>(modelDto);
    //    }

    //    [Authorize(AttendancePermissions.Teacher.Default)]
    //    public async Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input)
    //    {
    //        if (input.Sorting.IsNullOrWhiteSpace())
    //        {
    //            input.Sorting = nameof(Teacher.FullName);
    //        }

    //        var queryable = await _repository.GetQueryableAsync();

    //        //Prepare a query to join books and authors
    //        var query = from teacher in queryable
    //                    join department in await _departmentRepository.GetQueryableAsync() on teacher.DepartmentId equals department.Id
    //                    select new { teacher, department };

    //        //Paging
    //        query = query
    //            .OrderBy(NormalizeSorting(input.Sorting))
    //            .Skip(input.SkipCount)
    //            .Take(input.MaxResultCount);

    //        //Execute the query and get a list
    //        var queryResult = await AsyncExecuter.ToListAsync(query);

    //        //Convert the query result to a list of BookDto objects
    //        var teacherDtos = queryResult.Select(x =>
    //        {
    //            var teacherDto = ObjectMapper.Map<Teacher, TeacherDto>(x.teacher);
    //            teacherDto.Department = x.department.Name;
    //            return teacherDto;
    //        }).ToList();



    //        var modelDto = await _repository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

    //        var totalCount = input.Filter == null
    //            ? await _repository.CountAsync()
    //            : await _repository.CountAsync(m => m.FullName.Contains(input.Filter) || m.Position.Contains(input.Filter));

    //        return new PagedResultDto<TeacherDto>(totalCount, ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(modelDto));
    //    }

    //    private static string NormalizeSorting(string sorting)
    //    {
    //        if (sorting.IsNullOrEmpty())
    //        {
    //            return $"Teacher.{nameof(Department.Name)}";
    //        }

    //        if (sorting.Contains("departmentName", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return sorting.Replace(
    //                "departmentName",
    //                "department.Name",
    //                StringComparison.OrdinalIgnoreCase
    //            );
    //        }

    //        return $"Teacher.{sorting}";
    //    }

    //    [Authorize(AttendancePermissions.Teacher.Create)]
    //    public async Task<TeacherDto> CreateAsync(CreateUpdateTeacherDto input)
    //    {
    //        Teacher modelDto = new Teacher();
    //        modelDto.FullName = input.FullName;
    //        modelDto.Position = input.Position;
    //        modelDto.DepartmentId = input.DepartmentId;
    //        await _repository.InsertAsync(modelDto);

    //        return ObjectMapper.Map<Teacher, TeacherDto>(modelDto);
    //    }

    //    [Authorize(AttendancePermissions.Department.Edit)]
    //    public async Task UpdateAsync(Guid id, CreateUpdateTeacherDto input)
    //    {
    //        var modelDto = await _repository.GetAsync(id);
    //        modelDto.FullName = input.FullName;
    //        modelDto.Position = input.Position;
    //        modelDto.DepartmentId = input.DepartmentId;

    //        await _repository.UpdateAsync(modelDto);
    //    }

    //    [Authorize(AttendancePermissions.Department.Delete)]
    //    public async Task DeleteAsync(Guid id)
    //    {
    //        await _repository.DeleteAsync(id);
    //    }

    //    public async Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync()
    //    {
    //        var modelDto = await _departmentRepository.GetListAsync();

    //        return new ListResultDto<DepartmentLookupDto>(ObjectMapper.Map<List<Department>, List<DepartmentLookupDto>>(modelDto)
    //        );
    //    }

    //}


}
