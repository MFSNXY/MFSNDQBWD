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
    public class AuthorityroleDAO : BaseDao<Authorityrole>, IAuthorityroleDAO
    {
        public int AuthorityroleAdd(AuthorityroleModel p)
        {
            Authorityrole pc = new Authorityrole()
            {
                pid=p.Pid,
                u_oid=p.U_oid,
                aut_id=p.Aut_id

            };

            return Add(pc);
        }

        public int AuthorityroleDelete(int id)
        {
            Authorityrole pc = new Authorityrole()
            {
                pid = id
            };

            return Delete(pc);
        }

        public List<AuthorityroleModel> AuthorityroleSelect()
        {
            List<Authorityrole> list = Select();
            List<AuthorityroleModel> list2 = new List<AuthorityroleModel>();
            foreach (Authorityrole item in list)
            {
                AuthorityroleModel sm = new AuthorityroleModel()
                {
                    Pid=item.pid,
                    U_oid=item.u_oid,
                    Aut_id=item.aut_id
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public List<AuthorityroleModel> SelectAuthorityroleBy(int id)
        {
            MyDbContext db = CreateContext();
            List<Authorityrole> list = db.Authorityrole.AsNoTracking()
                  .Where(e => e.pid == id)
                  .Select(e => e)
                  .ToList();
            List<AuthorityroleModel> list2 = new List<AuthorityroleModel>();
            foreach (Authorityrole item in list)
            {
                AuthorityroleModel sm = new AuthorityroleModel()
                {
                    Pid = item.pid,
                    U_oid = item.u_oid,
                    Aut_id = item.aut_id
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public int AuthorityroleUpdate(AuthorityroleModel p)
        {
            Authorityrole pc = new Authorityrole()
            {
                pid = p.Pid,
                u_oid = p.U_oid,
                aut_id = p.Aut_id
            };
            return Update(pc);
        }

        public List<AuthorityroleModel> AuthorityroleFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }
        public int AuthorityroleDel(int oid)
        {
            string sql = string.Format(@"delete from dbo.Authorityrole where u_oid='{0}'", oid);
            int rs = CreateContext().Database.ExecuteSqlCommand(sql);
            return rs;
        }
        public int AuthorityroleSel(int oid)
        {
            int rows = CreateContext().Authorityrole.Where(e => e.u_oid == oid.ToString()).Select(e => e).ToList().Count;
            return rows;
        }
    }
}
