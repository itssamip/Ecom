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
    public class SubCategoryRepo : Repo<SubCategory>, ISubCategoryRepo
    {
        private readonly ApplicationDbContext _db;

        public SubCategoryRepo(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        public void Update(SubCategory subCategory)
        {
            var objFromDb = _db.SubCategories.FirstOrDefault(s => s.Id == subCategory.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = subCategory.Name;
                objFromDb.CategoryId = subCategory.CategoryId;
            }
        }
    }
}
