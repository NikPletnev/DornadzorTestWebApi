using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public RoleModel Role { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
