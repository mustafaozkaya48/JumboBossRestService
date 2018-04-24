using _BusinessLayer;
using _DataLayer;
using _DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Protocols;

namespace JB_WCF
{
    public class ServiceJB : IServiceJB
    {
        public Identity identity=new Identity { UserName="J",Password="0"};

        public List<CategoryModel> GetListCategory()
        {
            CategoryBusiness cb = new CategoryBusiness();
            return cb.GetListCategory();
        }

        [SoapHeader("identity")]
        public bool Login(int password)
        {
            if (identity.UserName=="J"&&identity.Password=="0")
            {
                UserBusiness ub = new UserBusiness();
                return ub.Login(password);
            }
            return false;
           
        }

       
    }
}
