using ETrade.Core.DataAccessRepositories.EntityFramework;
using ETrade.Core.Entities;
using ETrade.Core.Entities.DTOs;
using ETrade.DataAccess.Abstract;
using ETrade.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProductDal : EfEntityRepositoryBase<Product, AppDbContext>, IProductDal
    {
    }
}
