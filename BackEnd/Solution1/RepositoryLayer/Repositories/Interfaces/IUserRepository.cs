using DomainLayer.Entities;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllAsync();
        Task<IList<string>> GetRoleAsync(string email);
        Task ChangeRole(string id);
    }
}
