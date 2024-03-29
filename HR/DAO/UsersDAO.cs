﻿using EFEntity;
using IDAO;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsersDAO: BaseDao<Users>, IUsersDAO
    {
        public int UsersAdd(UsersModel s)
        {
            Users sd = new Users()
            {
                u_id =s.U_id,
                u_name=s.U_name,
                u_true_name=s.U_true_name,
                u_password=s.U_password,
                u_oid=s.U_oid
            };

            return Add(sd);
        }

        public int UsersDelete(UsersModel s)
        {
            Users sd = new Users()
            {
                u_id = s.U_id,
                u_name = s.U_name,
                u_true_name = s.U_true_name,
                u_password = s.U_password,
                u_oid = s.U_oid
            };

            return Delete(sd);
        }

        public List<UsersModel> UsersSelect()
        {
            List<Users> list = Select();
            List<UsersModel> list2 = new List<UsersModel>();
            foreach (Users item in list)
            {
                UsersModel sd = new UsersModel()
                {
                    U_id=item.u_id,
                    U_name=item.u_name,
                    U_true_name=item.u_true_name,
                    U_password=item.u_password,
                    U_oid=item.u_oid
                };
                list2.Add(sd);
            }
            return list2; ;
        }

        public List<UsersModel> SelectUsersBy(int id)
        {
            MyDbContext db = CreateContext();
            List<Users> list = db.Users.AsNoTracking()
                  .Where(e => e.u_id == id)
                  .Select(e => e)
                  .ToList();
            List<UsersModel> list2 = new List<UsersModel>();
            foreach (Users item in list)
            {
                UsersModel sd = new UsersModel()
                {
                    U_id = item.u_id,
                    U_name = item.u_name,
                    U_true_name = item.u_true_name,
                    U_password = item.u_password,
                    U_oid = item.u_oid
                };
                list2.Add(sd);
            }
            return list2;
        }

        public int UsersUpdate(UsersModel s)
        {
            Users sd = new Users()
            {
                u_id = s.U_id,
                u_name = s.U_name,
                u_true_name = s.U_true_name,
                u_password = s.U_password,
                u_oid = s.U_oid
            };
            return Update(sd);
        }

        public List<UsersModel> UsersFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }
        public UsersModel Dl(string uid,string pid)
        {
            //string sql = string.Format(@"select * from Users where u_name='{0}' and u_password='{1}'", uid, pid);
            //object obj = DBHelper.SelecSinger(sql);
            //return obj;
            Users s = CreateContext().Users.Where(e => e.u_name == uid && e.u_password == pid).SingleOrDefault();
            UsersModel sd = null;
            if (s!=null)
            {
                 sd = new UsersModel()
                {
                    U_id = s.u_id,
                    U_name = s.u_name,
                    U_true_name = s.u_true_name,
                    U_password = s.u_password,
                    U_oid = s.u_oid
                };
            }
            return sd;
        }
    }

}
