using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.DAL.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}


//User — Id int, Name string, Age int, связь на роль (один User имеет только одну роль), связь на заказ