using AutoMapper;
using DornadzorTestWebApi.BLL.Models;
using DornadzorTestWebApi.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.BLL.Configs
{
    public class BuisnessMapper: Profile
    {
        public BuisnessMapper()
        {
            CreateMap<UserModel, User>();
        }
    }
}
