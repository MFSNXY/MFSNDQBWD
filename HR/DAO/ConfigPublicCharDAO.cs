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
    public class ConfigPublicCharDAO : BaseDao<ConfigPublicChar>, IConfigPublicCharDAO
    {
        public List<ConfigPublicCharModel> ConfigMajorKindSelect()
        {
            List<ConfigPublicChar> list = Select();
            List<ConfigPublicCharModel> list2 = new List<ConfigPublicCharModel>();
            foreach (ConfigPublicChar item in list)
            {
                ConfigPublicCharModel ckm = new ConfigPublicCharModel()
                {
                    Id = item.Id,
                    Attributekind = item.Attributekind,
                    Attributename = item.Attributename
                };
                list2.Add(ckm);
            }
            return list2;
        }

        public List<ConfigPublicCharModel> ConfigMajorKindStudentBy(string lx)
        {
            MyDbContext db = CreateContext();
            List<ConfigPublicChar> list = db.ConfigPublicChar.AsNoTracking()
                  .Where(e => e.Attributekind == lx)
                  .Select(e => e)
                  .ToList();
            List<ConfigPublicCharModel> list2 = new List<ConfigPublicCharModel>();
            foreach (ConfigPublicChar item in list)
            {
                ConfigPublicCharModel sm = new ConfigPublicCharModel()
                {
                    Id=item.Id,
                    Attributename = item.Attributename
                };
                list2.Add(sm);
            }
            return list2;
        }

        public int ConfigPublicCharDelete(ConfigPublicCharModel ck)
        {
            ConfigPublicChar cmj = new ConfigPublicChar()
            {
                Attributekind = ck.Attributekind,
                Attributename = ck.Attributename,
                Id = ck.Id
            };
            return Delete(cmj);
        }
    }
}
