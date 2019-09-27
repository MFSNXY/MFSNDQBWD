using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using EFEntity;

namespace DAO
{
    public class PermissionDAO : BaseDao<Permission>, IPermissionDAO
    {
        public int PermissionAdd(PermissionModel p)
        {
            Permission per = new Permission() {
                id=p.id,
                state=p.state,
                Pid=p.Pid,
                text=p.text,
                Url=p.Url
            };
            return Add(per);
        }

        public PermissionModel PermissionBy(int id)
        {
           Permission p=  CreateContext().Permissions.AsNoTracking().Where(e => e.id == id).Select(e => e).SingleOrDefault();
            return new PermissionModel()
            {
                id = p.id,
                state = p.state,
                Pid = p.Pid,
                text = p.text,
                Url = p.Url
            };
        }

        public int PermissionDelete(int id)
        {
            Permission p = new Permission() { id=id};
            return Delete(p);
        }

        public List<PermissionModel> PermissionFY(int currentPage, int pageSize, out int rows)
        {
            var result4 = CreateContext().Permissions
                .AsNoTracking()
                .OrderBy(e=>e.id);
            rows = result4.Count();//总行数
            var data = result4//.Where(e=>e)
                 .Skip((currentPage - 1) * pageSize)//忽略多少条数
                 .Take(pageSize)//取多少条数
                 .ToList();
            List<Permission> list = data.ToList();
            List<PermissionModel> list2 = new List<PermissionModel>();
            foreach (var p in list)
            {
                PermissionModel pp = new PermissionModel()
                {
                    id = p.id,
                    state = p.state,
                    Pid = p.Pid,
                    text = p.text,
                    Url = p.Url
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<PermissionModel> PermissionRole(int pid, int rid)
        {
            var list = CreateContext().Permissions.SqlQuery(string.Format(@"select [id],[text],[state],[Url],[Pid],checked=
                                                                            case 
                                                                            when [PerID] is null then 0
                                                                            else 1
                                                                            end
                                                                            from [dbo].[Permission] p
                                                                            left join (
                                                                                select [PerId]
                                                                                from [dbo].[PermissionsRole]
                                                                                where [Rid]={1}
                                                                            ) rp on
                                                                            p.id=rp.PerID
                                                                            where [Pid]={0}", pid, rid)).ToList();
            List<PermissionModel> list2 = new List<PermissionModel>();
            foreach (var p in list)
            {
                PermissionModel pp = new PermissionModel()
                {
                    id = p.id,
                    state = p.state,
                    text = p.text,
                    Url = p.Url
                };
                list2.Add(pp);
            }
            return list2;
        }

        public List<PermissionModel> PermissionSelect()
        {
            List<Permission> list = Select();
            List<PermissionModel> list2 = new List<PermissionModel>();
            foreach (var p in list)
            {
                PermissionModel pp = new PermissionModel()
                {
                    id = p.id,
                    state = p.state,
                    Pid = p.Pid,
                    text = p.text,
                    Url = p.Url
                };
                list2.Add(pp);
            }
            return list2;
        }

        public int PermissionUpdate(PermissionModel p)
        {
            Permission pp = new Permission()
            {
                id = p.id,
                state = p.state,
                Pid = p.Pid,
                text = p.text,
                Url = p.Url
            };
            return Update(pp);
        }
    }
}
