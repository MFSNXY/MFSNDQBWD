using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Model;

namespace DAO
{
    public class ConfigMajorKindDAO : BaseDao<ConfigMajorKind>, IConfigMajorKindDAO
    {
        public int ConfigMajorKindAdd(ConfigMajorKindModel ck)
        {
            string kid = DateTime.Now.Second.ToString();
            ConfigMajorKind cmj = new ConfigMajorKind()
            {
                Id = ck.Id,
                Majorkindid= kid,
                Majorkindname=ck.Majorkindname
            };
            return Add(cmj);
        }

        public int ConfigMajorKindDelete(ConfigMajorKindModel ck)
        {
            ConfigMajorKind cmj = new ConfigMajorKind()
            {
                Majorkindid = ck.Majorkindid,
                Majorkindname = ck.Majorkindname,
                Id = ck.Id
            };
            return Delete(cmj);
        }

        public List<ConfigMajorKindModel> ConfigMajorKindSelect()
        {
            List<ConfigMajorKind> list = Select();
            List<ConfigMajorKindModel> list2 = new List<ConfigMajorKindModel>();
            foreach (ConfigMajorKind item in list)
            {
                ConfigMajorKindModel ckm = new ConfigMajorKindModel()
                {
                    Id=item.Id,
                    Majorkindid=item.Majorkindid,
                    Majorkindname=item.Majorkindname
                };
                list2.Add(ckm);
            }
            return list2;
        }


        public List<ConfigMajorKindModel> ConfigMajorKindStudentBy(int id)
        {
            MyDbContext db = CreateContext();
            List<ConfigMajorKind> list = db.ConfigMajorKind.AsNoTracking()
                  .Where(e => e.Id == id)
                  .Select(e => e)
                  .ToList();
            List<ConfigMajorKindModel> list2 = new List<ConfigMajorKindModel>();
            foreach (ConfigMajorKind item in list)
            {
                ConfigMajorKindModel sm = new ConfigMajorKindModel()
                {
                    Id = item.Id,
                    Majorkindid=item.Majorkindid,
                    Majorkindname=item.Majorkindname
                };
                list2.Add(sm);
            }
            return list2; 
        }

        public int ConfigMajorKindUpdate(ConfigMajorKindModel ck)
        {
            ConfigMajorKind cmk = new ConfigMajorKind()
            {
                Id = ck.Id,
                Majorkindid=ck.Majorkindid,
                Majorkindname=ck.Majorkindname
            };
            return Update(cmk);
        }

        public string fff(string id)
        {
            string sql =string.Format(@"select * from dbo.ConfigMajorKind where Majorkindid='{0}'",id);
            DataTable dt = DBHelper.select(sql);
            return dt.Rows[0]["Majorkindname"].ToString();
        }
    }

}