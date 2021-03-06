using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repo.IRepo
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepo Category { get; }

        ISubCategoryRepo SubCategory { get; }

        void Save();
    }
}
