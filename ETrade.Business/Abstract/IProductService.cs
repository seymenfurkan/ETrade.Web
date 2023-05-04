using ETrade.Core.Entities.DTOs;
using ETrade.Core.Utilities.Results.Abstract;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAllProducts();
        IDataResult<Product> GetProduct(int id);
        IResult AddProduct(Product product);
        IResult DeleteProduct(Product product);
        IResult UpdateProduct(Product product);
        IDataResult<ProductDetailDto> GetProductDetail(int id);
    }
}
