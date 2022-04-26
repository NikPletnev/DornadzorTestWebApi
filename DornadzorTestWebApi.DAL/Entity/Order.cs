using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.DAL.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public User User { get; set; }

    }
}

//Order — Id int, Name string, Description string, Price int