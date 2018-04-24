using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _DataLayer
{
    [DataContract]
   public class CategoryModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        
    }
}
