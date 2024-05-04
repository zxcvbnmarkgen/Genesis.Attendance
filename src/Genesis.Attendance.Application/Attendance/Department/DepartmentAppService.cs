using AutoMapper.Internal.Mappers;
using Genesis.Attendance.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Genesis.Attendance.Attendance.Department
{
    [Authorize(AttendancePermissions.Department.Default)]
    public class DepartmentAppService : AttendanceAppService, IDepartmentAppService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentAppService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        //...SERVICE METHODS HERE...

        public async Task<DepartmentDto> GetAsync(Guid id)
        {
            var modelDto = await _repository.GetAsync(id);
            return ObjectMapper.Map<Department, DepartmentDto>(modelDto);
        }

        [Authorize(AttendancePermissions.Department.Default)]
        public async Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Department.Name);
            }

            var modelDto = await _repository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(m => m.Name.Contains(input.Filter) || m.ShortName.Contains(input.Filter));

            return new PagedResultDto<DepartmentDto>(totalCount, ObjectMapper.Map<List<Department>, List<DepartmentDto>>(modelDto));
        }

        [Authorize(AttendancePermissions.Department.Create)]
        public async Task<DepartmentDto> CreateAsync(CreateUpdateDepartmentDto input)
        {
            Department modelDto = new Department();
            modelDto.Name = input.Name;
            modelDto.ShortName = input.ShortName;
            modelDto.IsActive = input.IsActive;
            await _repository.InsertAsync(modelDto);

            return ObjectMapper.Map<Department, DepartmentDto>(modelDto);
        }

        [Authorize(AttendancePermissions.Department.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateDepartmentDto input)
        {
            var modelDto = await _repository.GetAsync(id);
            modelDto.Name = input.Name;
            modelDto.ShortName = input.ShortName;
            modelDto.IsActive = input.IsActive;

            await _repository.UpdateAsync(modelDto);
        }

        [Authorize(AttendancePermissions.Department.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }



    }
}
