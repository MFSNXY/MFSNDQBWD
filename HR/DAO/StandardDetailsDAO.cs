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
    public class StandardDetailsDAO : BaseDao<StandardDetails>, IStandardDetailsDAO
    {
        public int StandardDetailsAdd(StandardDetailsModel s)
        {
            StandardDetails sd = new StandardDetails()
            {
                item_id=s.Item_id,
                item_name=s.Item_name,
            };

            return Add(sd);
        }

        public int StandardDetailsDelete(StandardDetailsModel s)
        {
            StandardDetails sd = new StandardDetails()
            {
                item_id = s.Item_id,
                item_name = s.Item_name,
            };

            return Delete(sd);
        }

        public List<StandardDetailsModel> StandardDetailsSelect()
        {
            List<StandardDetails> list = Select();
            List<StandardDetailsModel> list2 = new List<StandardDetailsModel>();
            foreach (StandardDetails item in list)
            {
                StandardDetailsModel sd = new StandardDetailsModel()
                {
                    Item_id=item.item_id,
                    Item_name=item.item_name,
                };
                list2.Add(sd);
            }
            return list2; ;
        }

        public List<StandardDetailsModel> SelectStandardDetailsBy(int id)
        {
            MyDbContext db = CreateContext();
            List<StandardDetails> list = db.StandardDetails.AsNoTracking()
                  .Where(e => e.item_id == id)
                  .Select(e => e)
                  .ToList();
            List<StandardDetailsModel> list2 = new List<StandardDetailsModel>();
            foreach (StandardDetails item in list)
            {
                StandardDetailsModel sd = new StandardDetailsModel()
                {
                    Item_id = item.item_id,
                    Item_name = item.item_name,
                };
                list2.Add(sd);
            }
            return list2; ;
        }

        public int StandardDetailsUpdate(StandardDetailsModel s)
        {
            StandardDetails sd = new StandardDetails()
            {
                item_id = s.Item_id,
                item_name = s.Item_name,
            };
            return Update(sd);
        }

        public List<StandardDetailsModel> StandardDetailsFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }
    }
}
