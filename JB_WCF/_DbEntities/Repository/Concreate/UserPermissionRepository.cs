
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class UserPermissionRepository
    {
        private IRepository<UserPermission> _userpermissionRepository;
        private IUnitOfWork _userUnitofWork;
        private DbContext _dbContext;
        public UserPermissionRepository()
        {
            _dbContext = new JumboBossEntities();
            _userpermissionRepository = new EFRepository<UserPermission>(_dbContext);
            _userUnitofWork = new EFUnitOfWork(_dbContext);
        }

        public UserPermission UserPermission(User User)
        {
            return _userpermissionRepository.Get(x=>x.User.Id==User.Id);
        }
    }
}
