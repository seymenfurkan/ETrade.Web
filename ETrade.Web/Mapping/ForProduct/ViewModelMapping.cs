using AutoMapper;
using ETrade.Core.Entities.DTOs;
using ETrade.Entities.Concrete;
using ETrade.Web.Models.ProductViewModels;

namespace ETrade.Web.Mapping.ForProduct
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();


            CreateMap<CreateProductViewModel, Product>();
            CreateMap<UpdateProductViewModel, Product>().ReverseMap(); 
            CreateMap<DeleteProductViewModel, Product>();


            CreateMap<ProductDetailDto , GetProductWithDetailByIdViewModel>().ReverseMap();
        }
    }
}
