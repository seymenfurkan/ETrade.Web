using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Entities.DTOs;
using ETrade.Core.Utilities.Results.Abstract;
using ETrade.Core.Utilities.Results.Concrete;
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
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public IResult AddProduct(Product product)
        {
            if (DateTime.Now.Hour is 12)
            {
                return new ErrorResult("Maintenance time !");
            }
            _productDal.Add(product);
            return new SuccessResult("Ürün başarılı bir şekilde eklendi !");
        }

        public IResult DeleteProduct(Product product)
        {
            if (DateTime.Now.Hour is 09)
            {
                return new ErrorResult("Maintenance time !");
            }
            _productDal.Delete(product);
            return new SuccessResult("Ürün başarılı bir şekilde silindi !");
        }


        public IDataResult<List<Product>> GetAllProducts()
        {
            if (DateTime.Now.Hour is 10)
            {
                return new ErrorDataResult<List<Product>>("Ürünler bakımdan dolayı listelenemiyor !");
            }
            var products = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(products, "Ürünler başarılı bir şekilde listelendi !");
        }

        public IDataResult<Product> GetProduct(int id)
        {
            if (DateTime.Now.Hour is 10)
            {
                return new ErrorDataResult<Product>("Bakımdan dolayı ürün sayfasına ulaşılamıyor !");
            }
            var product = _productDal.Get(p => p.Id == id);
            return new SuccessDataResult<Product>(product, "Ürün sayfasına başarılı bir şekilde ulaşıldı !");
        }

        public IDataResult <ProductDetailDto> GetProductDetail(int id)
        {
            if (DateTime.Now.Hour is 10)
            {
                return new ErrorDataResult<ProductDetailDto>("Bakımdan dolayı ürün detay sayfasına ulaşılamıyor !");
            }
            var item = _productDal.Get(p => p.Id == id);
            var mappedItem = _mapper.Map<ProductDetailDto>(item);
            return new SuccessDataResult<ProductDetailDto>(mappedItem, "Ürün detay sayfasına başarılı bir şekilde ulaşıldı !");
        }

        public IResult UpdateProduct(Product product)
        {
            if (DateTime.Now.Hour is 17)
            {
                return new ErrorResult("Maintenance time !");
            }
            _productDal.Update(product);
            return new SuccessResult("Ürün başarılı bir şekilde güncellendi !");
        }
    }
}
