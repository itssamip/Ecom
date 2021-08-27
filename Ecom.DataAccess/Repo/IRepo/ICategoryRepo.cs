using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repo.IRepo
{
    public interface ICategoryRepo : IRepo<Category>
    {
        void Update(Category category);
    }
}
