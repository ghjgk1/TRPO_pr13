using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_pr13.Data;

namespace TRPO_pr13.Service
{
    public class RoleService
    {
        public readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Role> Roles { get; set; } = new();

        public RoleService() 
        {
            GetAll();
        }

        public void Add(Role role)
        {
            var _role = new Role
            {
                Title = role.Title
            };
            _db.Add(_role);
            Commit();      
            Roles.Add(_role);
        }

        public void GetAll()
        {
            var groups = _db.Roles.ToList();
            Roles.Clear();
            foreach (var group in groups)
            {
                Roles.Add(group);
            }
        }

        public void Remove(Role role)
        {
            _db.Remove<Role>(role);
            if(Commit() > 0)
                if (Roles.Contains(role))
                    Roles.Remove(role);
        }

        public void LoadRelation(Role role, string relation)
        {
            if (role == null)
                return; 

            var entry = _db.Entry(role);

            var navigation = entry.Metadata.FindNavigation(relation)
                ??  throw new InvalidOperationException($"{relation} не найден");

            if (navigation.IsCollection)
                entry.Collection(relation).Load();
            else
                entry.Reference(relation).Load();
        }

        public int Commit() => _db.SaveChanges();
    }
}
