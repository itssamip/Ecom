using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repo.IRepo
{
    public interface ISubCategoryRepo : IRepo<SubCategory>
    {
        void Update(SubCategory subCategory);
    }
}
