using DotNet_Backend.Models;
using DotNetProject.Models;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<User?> GetUserById(string id);

        Task<User?> GetUserByIdAsync(string userid);
       
        Task<User?> GetUserByEmailId(string emailid);
    }
}
