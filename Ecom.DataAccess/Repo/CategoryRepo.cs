using Ecom.DataAccess.Data;
using Ecom.DataAccess.Repo.IRepo;
using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repo
{
    public class CategoryRepo : Repo<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = category.Name;
            }
        }
    }
}
