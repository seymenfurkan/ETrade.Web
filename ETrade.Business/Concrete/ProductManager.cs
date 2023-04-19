using ETrade.Business.Abstract;
using ETrade.DataAccess.Abstract;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            _productDal.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            var deleteToProduct =  _productDal.Get(p => p.Id == product.Id);
            _productDal.Delete(deleteToProduct);
        }


        public List<Product> GetAllProducts() => _productDal.GetAll();
      

        public Product GetProduct(int id) => _productDal.Get(p => p.Id == id);
   

        public void UpdateProduct(Product product)
        {
            _productDal.Update(product);
        }
    }
}
