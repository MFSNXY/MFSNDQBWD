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
    public class StandardDetailsDAO : BaseDao<StandardDetails>, IStandardDetailsDAO
    {
        public List<StandardDetailsModel> StandardDetailsSelect()
        {
            List<StandardDetails> list = Select();
            List<StandardDetailsModel> list2 = new List<StandardDetailsModel>();
            foreach (StandardDetails item in list)
            {
                StandardDetailsModel ckm = new StandardDetailsModel()
                {
                    item_id = item.item_id,
                    item_name = item.item_name
                };
                list2.Add(ckm);
            }
            return list2;
        }
    }
}
