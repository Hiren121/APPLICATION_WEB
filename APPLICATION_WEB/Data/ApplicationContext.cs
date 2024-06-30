using APPLICATION_WEB.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APPLICATION_WEB.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }


        public async Task AddUser(User user)
        {
            await Database.ExecuteSqlInterpolatedAsync($"EXEC AddUser {user.Name}, {user.Email}, {user.Phone}, {user.Address}, {user.State}, {user.City}");
        }

        public async Task EditUser(User user)
        {
            await Database.ExecuteSqlInterpolatedAsync($"EXEC EditUser {user.Id}, {user.Name}, {user.Email}, {user.Phone}, {user.Address}, {user.State}, {user.City}");
        }

        public async Task DeleteUser(int id)
        {
            await Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteUser {id}");
        }
    }

}
