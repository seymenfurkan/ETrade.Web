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
        IDataResult<List<ProductListDto>> GetAllProducts();
        IDataResult<GetProductByIdDto> GetProduct(int id);
        IResult AddProduct(CreateProductDto entity);
        IResult DeleteProduct(DeleteProductDto entity);
        IResult UpdateProduct(UpdateProductDto entity);
        IDataResult<ProductDetailDto> GetProductDetail(int id);
    }
}
