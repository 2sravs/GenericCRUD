using GenericCRUDOp.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericCRUDOp.Repository
{
    public class GenericRepository<t> : GenericRepositoryBase<t>, IGenericRepository<t> where T : class
    {
        private GenericDBContext db = null;

        public GenericRepository()
        {
            this.db = new GenericDBContext();
            table = db.Set<t>();
        }
        public GenericRepository(GenericDBContext db)
        {
            this.db = db;
            table = db.Set<t>();
        }
        public IEnumerable<t> SelectAll()
        {
            return table.ToList();
        }
        public T SelectByID(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return obj is GenericRepository<t> repository &&
                   EqualityComparer<GenericDBContext>.Default.Equals(db, repository.db);
        }

        public override int GetHashCode()
        {
            return 794399803 + EqualityComparer<GenericDBContext>.Default.GetHashCode(db);
        }
    }
}
}