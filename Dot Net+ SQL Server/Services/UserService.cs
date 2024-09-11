using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetProject.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<User> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailId(string emailID)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email == emailID);
            return user;
        }

        public async Task<User?> GetUserById(string id)
        {
            var user = await db.Users.FindAsync(id);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(string userid)
        {
            return await db.Users
                           .AsNoTracking()
                           .SingleOrDefaultAsync(u => u.Userid == userid);
        }
    }
}




/*using DotNetProject.Models;
using DotNetProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<User> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailId(string emailID)
        {
            var user = await db.Users.FirstOrDefaultAsync(x=>x.Email== emailID);
            return user;
        }

        public async Task<User?> GetUserById(string id)
        {
            var user = await db.Users.FindAsync(id);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(string userid)
        {
            return await db.Users
                                 .AsNoTracking()
                                 .SingleOrDefaultAsync(u => u.Userid == userid);
        }


    }
}
*/