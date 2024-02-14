using API.Entities;

namespace API.Interface
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetAllUserById(int id);
        Task<User> GetAllUserByName(string username);

    }
}
