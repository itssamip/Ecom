using Ecom.DataAccess.Data;
using Ecom.DataAccess.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepo(_db);
            SubCategory = new SubCategoryRepo(_db);
        }

        public ICategoryRepo Category { get; private set; }
        public ISubCategoryRepo SubCategory { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
