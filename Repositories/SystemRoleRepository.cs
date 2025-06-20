using Korrekturmanagementsystem.Data;
using Korrekturmanagementsystem.Data.Entities;
using Korrekturmanagementsystem.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Korrekturmanagementsystem.Repositories;

public class SystemRoleRepository : BaseRepository<SystemRole>, ISystemRoleRepository
{
    public SystemRoleRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Guid?> GetSystemRoleIdByNameAsync(string name) =>
        await context.SystemRoles
            .Where(role => role.Name == name)
            .Select(role => (Guid?)role.Id)
            .FirstOrDefaultAsync();
}
