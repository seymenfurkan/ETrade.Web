using ETrade.Core.DataAccessRepositories;
using ETrade.Core.Entities.DTOs;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {

    }
}
