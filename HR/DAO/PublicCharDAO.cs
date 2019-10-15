using EFEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;

namespace DAO
{
    public class PublicCharDAO:BaseDao<PublicChar>,IPublicCharDAO
    {
        public int PublicCharAdd(PublicCharModel p)
        {
            PublicChar pc = new PublicChar()
            {
                pbc_id = p.Pbc_id,
                attribute_kind = p.Attribute_kind,
                attribute_name=p.Attribute_name

            };

            return Add(pc);
        }

        public int PublicCharDelete(PublicCharModel p)
        {
            PublicChar pc = new PublicChar()
            {
                pbc_id = p.Pbc_id,
                attribute_kind = p.Attribute_kind,
                attribute_name = p.Attribute_name

            };

            return Delete(pc);
        }

        public List<PublicCharModel> PublicCharSelect()
        {
            List<PublicChar> list = Select();
            List<PublicCharModel> list2 = new List<PublicCharModel>();
            foreach (PublicChar item in list)
            {
                PublicCharModel sm = new PublicCharModel()
                {
                    Pbc_id = item.pbc_id,
                    Attribute_kind = item.attribute_kind,
                    Attribute_name=item.attribute_name
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public List<PublicCharModel> SelectPublicCharBy(int id)
        {
            MyDbContext db = CreateContext();
            List<PublicChar> list = db.PublicChar.AsNoTracking()
                  .Where(e => e.pbc_id == id)
                  .Select(e => e)
                  .ToList();
            List<PublicCharModel> list2 = new List<PublicCharModel>();
            foreach (PublicChar item in list)
            {
                PublicCharModel sm = new PublicCharModel()
                {
                    Pbc_id = item.pbc_id,
                    Attribute_kind = item.attribute_kind,
                    Attribute_name = item.attribute_name
                };
                list2.Add(sm);
            }
            return list2; ;
        }

        public int PublicCharUpdate(PublicCharModel p)
        {
            PublicChar pc = new PublicChar()
            {
                pbc_id = p.Pbc_id,
                attribute_kind = p.Attribute_kind,
                attribute_name = p.Attribute_name
            };
            return Update(pc);
        }

        public List<PublicCharModel> PublicCharFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }


        public List<PublicCharModel> PublicCharGet(string type)
        {
            var list = CreateContext().PublicChar.AsNoTracking().Where(e => e.attribute_kind == type).Select(e => e).ToList();
            List<PublicCharModel> list2 = new List<PublicCharModel>();
            foreach (var p in list)
            {
                PublicCharModel pc = new PublicCharModel()
                {
                    Pbc_id = p.pbc_id,
                    Attribute_kind = p.attribute_kind,
                    Attribute_name = p.attribute_name
                };
                list2.Add(pc);
            }
            return list2;
        }


    }
}
