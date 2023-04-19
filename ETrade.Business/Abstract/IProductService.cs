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
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
