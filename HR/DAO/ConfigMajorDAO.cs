using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Model;

namespace DAO
{
    public class ConfigMajorDAO : BaseDao<ConfigMajor>, IConfigMajorDAO
    {
        public int ConfigMajorAdd(ConfigMajorModel ck)
        {
            ConfigMajor cmj = new ConfigMajor();
            cmj.Id = ck.Id;
            cmj.Majorkindid = ck.Majorkindid;
            cmj.Majorkindname = ck.Majorkindname;
            cmj.Majorid = ck.Majorid;
            cmj.Majorname = ck.Majorname;
            cmj.Testamount = ck.Testamount;
            return Add(cmj);
        }

        public int ConfigMajorDelete(ConfigMajorModel ck)
        {
            ConfigMajor cmj = new ConfigMajor()
            {
                Majorkindid = ck.Majorname,
                Majorkindname = ck.Majorkindname,
                Majorid = ck.Majorid,
                Majorname = ck.Majorname,
                Testamount = ck.Testamount,
                Id = ck.Id
            };
            return Delete(cmj);
        }

        public List<ConfigMajorModel> ConfigMajorSelect()
        {
            List<ConfigMajor> list = Select();
            List<ConfigMajorModel> list2 = new List<ConfigMajorModel>();
            foreach (ConfigMajor item in list)
            {
                ConfigMajorModel ckm = new ConfigMajorModel()
                {
                    Id = item.Id,
                    Majorkindid = item.Majorkindid,
                    Majorkindname = item.Majorkindname,
                    Majorid = item.Majorid,
                    Majorname = item.Majorname,
                    Testamount = item.Testamount
                };
                list2.Add(ckm);
            }
            return list2;
        }

        public List<ConfigMajorModel> ConfigMajorSelectBy(int id)
        {
            MyDbContext db = CreateContext();
            List<ConfigMajor> list = db.ConfigMajor.AsNoTracking()
                  .Where(e => e.Id == id)
                  .Select(e => e)
                  .ToList();
            List<ConfigMajorModel> list2 = new List<ConfigMajorModel>();
            foreach (ConfigMajor item in list)
            {
                ConfigMajorModel sm = new ConfigMajorModel()
                {
                    Id = item.Id,
                    Majorkindid = item.Majorname,
                    Majorkindname = item.Majorkindname,
                    Majorid = item.Majorid,
                    Majorname = item.Majorname,
                    Testamount = item.Testamount
                };
                list2.Add(sm);
            }
            return list2;
        }

        public int ConfigMajorUpdate(ConfigMajorModel ck)
        {
            ConfigMajor cmk = new ConfigMajor()
            {
                Id = ck.Id,
                Majorkindid = ck.Majorname,
                Majorkindname = ck.Majorkindname,
                Majorid = ck.Majorid,
                Majorname = ck.Majorname,
                Testamount = ck.Testamount
            };
            return Update(cmk);
        }

       
    }
}
