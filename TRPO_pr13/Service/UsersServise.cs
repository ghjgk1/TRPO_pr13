using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TRPO_pr13.Data;

namespace TRPO_pr13.Service
{
    public class UsersServise
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; set; } = new();

        public UsersServise()
        {
            GetAll();
        }

        public void Add(User? user)
        {
            var _user = new User
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                Profile = user.Profile,
                Role = user.Role,
                RoleId = user.RoleId,
            };
            _db.Add(_user);
            Commit();
            Users.Add(_user);
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .ToList();
            Users.Clear();
            foreach(var user in users)
            {
                Users.Add(user);
            }
        }

        public void Remove(User user)
        {
            _db.Remove<User>(user);
            if (Commit() > 0)
                if (Users.Contains(user))
                    Users.Remove(user);
        }
    }
}
