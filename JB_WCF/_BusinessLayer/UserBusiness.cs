using _DbEntities.Repository.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class UserBusiness
    {
        UserRepository _ur = new UserRepository();

        public bool Login(int password) {
            if (_ur.Login(password) != null) return true;
            else return false;
        }
        
        


    }
}
