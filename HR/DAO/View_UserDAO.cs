using EFEntity;
using IDAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class View_UserDAO : BaseDao<View_User>, IView_UserDAO
    {
        public int View_UserAdd(View_UserModel s)
        {
            View_User sd = new View_User()
            {
                u_id = s.U_id,
                u_name = s.U_name,
                u_true_name = s.U_true_name,
                u_password = s.U_password,
                u_name1=s.U_name1
            };

            return Add(sd);
        }

        public int View_UserDelete(View_UserModel s)
        {
            View_User sd = new View_User()
            {
                u_id = s.U_id,
                u_name = s.U_name,
                u_true_name = s.U_true_name,
                u_password = s.U_password,
                u_name1 = s.U_name1
            };

            return Add(sd);
        }

        public List<View_UserModel> View_UserSelect()
        {
            List<View_User> list = Select();
            List<View_UserModel> list2 = new List<View_UserModel>();
            foreach (View_User item in list)
            {
                View_UserModel sd = new View_UserModel()
                {
                    U_id = item.u_id,
                    U_name = item.u_name,
                    U_true_name = item.u_true_name,
                    U_password = item.u_password,
                    U_name1 = item.u_name1
                };
                list2.Add(sd);
            }
            return list2; ;
        }

        public List<View_UserModel> SelectView_UserBy(int id)
        {
            MyDbContext db = CreateContext();
            List<View_User> list = db.View_User.AsNoTracking()
                  .Where(e => e.u_id == id)
                  .Select(e => e)
                  .ToList();
            List<View_UserModel> list2 = new List<View_UserModel>();
            foreach (View_User item in list)
            {
                View_UserModel sd = new View_UserModel()
                {
                    U_id = item.u_id,
                    U_name = item.u_name,
                    U_true_name = item.u_true_name,
                    U_password = item.u_password,
                    U_name1 = item.u_name1
                };
                list2.Add(sd);
            }
            return list2; ;
        }

        public int View_UserUpdate(View_UserModel s)
        {
            View_User sd = new View_User()
            {
                u_id = s.U_id,
                u_name = s.U_name,
                u_true_name = s.U_true_name,
                u_password = s.U_password,
                u_name1 = s.U_name1
            };
            return Update(sd);
        }

        public List<View_UserModel> View_UserFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            var list = CreateContext().View_User.AsNoTracking().OrderBy(e => e.u_id).ToList();
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * PageSize)
                 .Take(PageSize)
                 .ToList();
            List<View_UserModel> list2 = new List<View_UserModel>();
            foreach (var item in data)
            {
                View_UserModel sd = new View_UserModel()
                {
                    U_id = item.u_id,
                    U_name = item.u_name,
                    U_true_name = item.u_true_name,
                    U_password = item.u_password,
                    U_name1 = item.u_name1
                };
                list2.Add(sd);
            }
            return list2;
        }
    }
}
