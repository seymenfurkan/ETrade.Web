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
            CreateMap<ProductListDto, ProductListViewModel>().ReverseMap();
            
            CreateMap<CreateProductViewModel, CreateProductDto>();

            CreateMap<UpdateProductViewModel, UpdateProductDto>().ReverseMap();
            CreateMap<UpdateProductViewModel, GetProductByIdDto>().ReverseMap();

            CreateMap<DeleteProductViewModel, DeleteProductDto>();
         
            CreateMap<ProductDetailDto , GetProductWithDetailByIdViewModel>().ReverseMap();
        }
    }
}
