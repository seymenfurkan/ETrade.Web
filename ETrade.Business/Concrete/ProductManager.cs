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

        public IResult AddProduct(CreateProductDto entity)
        {
            if (DateTime.Now.Hour is 09)
            {
                return new ErrorResult("Maintenance time !");
            }
            var mappedEntity = _mapper.Map<Product>(entity);
            _productDal.Add(mappedEntity);
            return new SuccessResult("Ürün başarılı bir şekilde eklendi !");
        }

        public IResult DeleteProduct(DeleteProductDto entity)
        {
            if (DateTime.Now.Hour is 09)
            {
                return new ErrorResult("Maintenance time !");
            }
            var mappedEntity = _mapper.Map<Product>(entity);
            _productDal.Delete(mappedEntity);
            return new SuccessResult("Ürün başarılı bir şekilde silindi !");
        }


        public IDataResult<List<ProductListDto>> GetAllProducts()
        {
            if (DateTime.Now.Hour is 09)
            {
                return new ErrorDataResult<List<ProductListDto>>("Ürünler bakımdan dolayı listelenemiyor !");
            }
            var products = _productDal.GetAll();
            var mappedEntities = _mapper.Map<List<ProductListDto>>(products);
            return new SuccessDataResult<List<ProductListDto>>(mappedEntities, "Ürünler başarılı bir şekilde listelendi !");
        }

        public IDataResult<GetProductByIdDto> GetProduct(int id)
        {
            if (DateTime.Now.Hour is 09)
            {
                return new ErrorDataResult<GetProductByIdDto>("Bakımdan dolayı ürün sayfasına ulaşılamıyor !");
            }
            var entity = _productDal.Get(p => p.Id == id);
            var mappedEntity = _mapper.Map<GetProductByIdDto>(entity);

            return new SuccessDataResult<GetProductByIdDto>(mappedEntity, "Ürün sayfasına başarılı bir şekilde ulaşıldı !");
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

        public IResult UpdateProduct(UpdateProductDto entity)
        {
            if (DateTime.Now.Hour is 17)
            {
                return new ErrorResult("Maintenance time !");
            }
            var mappedEntity = _mapper.Map<Product>(entity);
            _productDal.Update(mappedEntity);
            return new SuccessResult("Ürün başarılı bir şekilde güncellendi !");
        }
    }
}
