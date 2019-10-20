using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using EFEntity;
using Model;

namespace DAO
{
    public class UsersmanDAO : BaseDao<Usersman>, IUsersmanDAO
    {
        public int UsersmanAdd(UsersmanModel p)
        {
            Usersman pc = new Usersman()
            {
                u_oid=p.U_oid,
                u_name1=p.U_name1,
                u_sm=p.U_sm,
                u_sf=p.U_sf
            };

            return Add(pc);
        }

        public int UsersmanDelete(UsersmanModel p)
        {
            Usersman pc = new Usersman()
            {
                u_oid = p.U_oid,
                u_name1 = p.U_name1,
                u_sm = p.U_sm,
                u_sf = p.U_sf

            };

            return Delete(pc);
        }

        public List<UsersmanModel> UsersmanSelect()
        {
            List<Usersman> list = Select();
            List<UsersmanModel> list2 = new List<UsersmanModel>();
            foreach (Usersman item in list)
            {
                UsersmanModel sm = new UsersmanModel()
                {
                   U_oid=item.u_oid,
                   U_name1=item.u_name1,
                   U_sm=item.u_sm,
                   U_sf=item.u_sf
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public List<UsersmanModel> SelectUsersmanBy(int id)
        {
            MyDbContext db = CreateContext();
            List<Usersman> list = db.Usersman.AsNoTracking()
                  .Where(e => e.u_oid == id)
                  .Select(e => e)
                  .ToList();
            List<UsersmanModel> list2 = new List<UsersmanModel>();
            foreach (Usersman item in list)
            {
                UsersmanModel sm = new UsersmanModel()
                {
                    U_oid = item.u_oid,
                    U_name1 = item.u_name1,
                    U_sm = item.u_sm,
                    U_sf = item.u_sf
                };
                list2.Add(sm);
            }
            return list2; 
        }

        public int UsersmanUpdate(UsersmanModel p)
        {
            Usersman pc = new Usersman()
            {
                u_oid = p.U_oid,
                u_name1 = p.U_name1,
                u_sm = p.U_sm,
                u_sf = p.U_sf
            };
            return Update(pc);
        }

        public List<UsersmanModel> UsersmanFenYe(int currentPage, int PageSize, out int rows)
        {
            var list = CreateContext().Usersman.AsNoTracking().OrderBy(e => e.u_oid).ToList();
            rows = list.Count();
            var data = list
                 .Skip((currentPage - 1) * PageSize)
                 .Take(PageSize)
                 .ToList();
            List<UsersmanModel> list2 = new List<UsersmanModel>();
            foreach (var p in data)
            {
                UsersmanModel e = new UsersmanModel()
                {
                    U_oid=p.u_oid,
                    U_name1=p.u_name1,
                    U_sm=p.u_sm,
                    U_sf=p.u_sf
                };
                list2.Add(e);
            }
            return list2;
        }
        
    }
}
