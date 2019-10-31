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
        /// <summary>
        /// 查询rid角色下的权限
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public List<PermissionModel> PermissionRole(int pid, int rid)
        {
            var list = CreateContext().Permissions.SqlQuery(string.Format(@"select [id], [text], [Pid], [Url], [state] from
                                                                            [dbo].[Permission] p 
                                                                            inner join (select [aut_id] from [dbo].[Authorityrole] where [u_oid]={1} ) rp on 
                                                                            p.id=rp.[aut_id]
                                                                            where PID={0}", pid, rid)).ToList();
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


        public List<PermissionModel> PermissionSelectPid(int pid)
        {
            List<Permission> list = CreateContext().Permissions.Where(e => e.Pid == pid).ToList();
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
        public List<QxModel> qx(int c, int d)
        {
            List<Qx> list = CreateContext().Qx.SqlQuery(string.Format(@"select [id],[text],[state],[Pid],[Url],checked=
            case 
            when rp.aut_id is null then 0
            else 1
            end
            from dbo.Permission p
            left join(
            select aut_id
            from  dbo.Authorityrole
            where u_oid={0}
            ) rp on p.id=rp.aut_id
            where p.Pid={1}", d, c)).Select(e => e).ToList();
            List<QxModel> list2 = new List<QxModel>();
            foreach (var p in list)
            {
                QxModel pp = new QxModel()
                {
                    id = p.id,
                    state = p.state,
                    Pid = p.Pid,
                    text = p.text,
                    Url = p.Url,
                    @checked = p.@checked
                };
                list2.Add(pp);
            }
            return list2;
        }

    }
}
