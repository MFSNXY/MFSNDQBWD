using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity.Infrastructure;

namespace DAO
{
    public class BaseDao<T>where T :class
    {

        public static MyDbContext CreateContext()
        {
            MyDbContext db = CallContext.GetData("s") as MyDbContext;
            if (db == null)
            {
                db = new MyDbContext();
                CallContext.SetData("s", db);
            }
            return db;
        }

        public void FenLi(T t)
        {
            MyDbContext db = CreateContext();
            var ObjContext = ((IObjectContextAdapter)db).ObjectContext;
            var objSet = ObjContext.CreateObjectSet<T>();
            var objKey = ObjContext.CreateEntityKey(objSet.EntitySet.Name, t);
            object objT;
            var ext = ObjContext.TryGetObjectByKey(objKey, out objT);
            if (ext)
            {
                ObjContext.Detach(objT);
            }
        }
        public int Add(T t)
        {
            MyDbContext db = CreateContext();
            try
            {
                db.Set<T>().Add(t);
            }catch(Exception e)
            {
                LogHelper.WriteLog(typeof(BaseDao<T>), e.Message);
            }
            return db.SaveChanges();
        }

        public int Update(T t)
        {

            MyDbContext db = CreateContext();
            FenLi(t);
            try
            {
                db.Set<T>().Attach(t);
                db.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(typeof(BaseDao<T>), e.Message);
            }
            return db.SaveChanges();
        }
        public int Delete(T t)
        {
            MyDbContext db = CreateContext();
            FenLi(t);
            try
            {
                db.Set<T>().Attach(t);
                db.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(typeof(BaseDao<T>), e.Message);
            }
            return db.SaveChanges();

        }

        public List<T> Select()
        {
            List<T> list = new List<T>();
            try
            {
               list = CreateContext().Set<T>()
                       .AsNoTracking()
                       .Select(e => e)
                       .ToList();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(typeof(BaseDao<T>), e.Message);
            }
            return list;
        }

    }
}
