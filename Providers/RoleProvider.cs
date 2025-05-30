﻿using Korrekturmanagementsystem.Data.Entities;
using Korrekturmanagementsystem.Dtos;
using Korrekturmanagementsystem.Repositories.Interfaces;
using Korrekturmanagementsystem.Services.Interfaces;

namespace Korrekturmanagementsystem.Services;

public class RoleProvider : IRoleProvider
{
    private readonly IBaseRepository<StakeholderRole> _roleRepository;
    private readonly ISystemRoleRepository _systemRoleRepository;
    public RoleProvider(IBaseRepository<StakeholderRole> repository, ISystemRoleRepository systemRoleRepository)
    {
        _roleRepository = repository;
        _systemRoleRepository = systemRoleRepository;
    }

    public async Task<Guid?> GetSystemRoleIdByNameAsync(string name) =>
        await _systemRoleRepository.GetSystemRoleIdByNameAsync(name);

    public async Task<IEnumerable<RoleDto>> GetStakeholderRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();

        return roles.Select(role => new RoleDto
        {
            Id = role.Id,
            Name = role.Name
        });
    }
}
