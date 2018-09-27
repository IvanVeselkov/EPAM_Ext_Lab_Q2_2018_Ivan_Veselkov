using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Models;
using ADO.NET.Repositories;
using System.Data.SqlClient;

namespace ADO.NET.Services
{
    public class UserService : BaseService<UserModel>
    {
        private UserRepository userRepo;

        public UserService(UserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public override bool Delete(int id)
        {
            if(userRepo.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override UserModel Get(int id)
        {
            UserModel us = userRepo.Get(id);
            return us;
        }



        public override List<UserModel> GetAll()
        {
            List<UserModel> listUs = userRepo.GetAll();
            return listUs;
        }

        public override bool Save(UserModel entity)
        {
            if(userRepo.Save(entity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
