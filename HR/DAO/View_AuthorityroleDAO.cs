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
    public class View_AuthorityroleDAO : BaseDao<View_Authorityrole>, IView_AuthorityroleDAO
    {
        public int View_AuthorityroleAdd(View_AuthorityroleModel p)
        {
            View_Authorityrole pc = new View_Authorityrole()
            {
                pid = p.Pid,
                u_oid = p.U_oid,
                text=p.Text

            };

            return Add(pc);
        }

        public int View_AuthorityroleDelete(View_AuthorityroleModel p)
        {
            View_Authorityrole pc = new View_Authorityrole()
            {
                pid = p.Pid,
                u_oid = p.U_oid,
                text=p.Text

            };

            return Delete(pc);
        }

        public List<View_AuthorityroleModel> View_AuthorityroleSelect()
        {
            List<View_Authorityrole> list = Select();
            List<View_AuthorityroleModel> list2 = new List<View_AuthorityroleModel>();
            foreach (View_Authorityrole item in list)
            {
                View_AuthorityroleModel sm = new View_AuthorityroleModel()
                {
                    Pid = item.pid,
                    U_oid = item.u_oid,
                    Text=item.text
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public List<View_AuthorityroleModel> SelectView_AuthorityroleBy(int id)
        {
            MyDbContext db = CreateContext();
            List<View_Authorityrole> list = db.View_Authorityrole.AsNoTracking()
                  .Where(e => e.pid == id)
                  .Select(e => e)
                  .ToList();
            List<View_AuthorityroleModel> list2 = new List<View_AuthorityroleModel>();
            foreach (View_Authorityrole item in list)
            {
                View_AuthorityroleModel sm = new View_AuthorityroleModel()
                {
                    Pid = item.pid,
                    U_oid = item.u_oid,
                    Text=item.text
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public int View_AuthorityroleUpdate(View_AuthorityroleModel p)
        {
            View_Authorityrole pc = new View_Authorityrole()
            {
                pid = p.Pid,
                u_oid = p.U_oid,
                text=p.Text
            };
            return Update(pc);
        }

        public List<View_AuthorityroleModel> View_AuthorityroleFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }
    }
}
