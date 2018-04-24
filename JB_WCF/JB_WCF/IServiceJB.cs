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

    [ServiceContract]
    public interface IServiceJB
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "login?password={password}")]
        bool Login(int password);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetListCategory", RequestFormat = WebMessageFormat.Json)]
        List<CategoryModel> GetListCategory();




    }

}
