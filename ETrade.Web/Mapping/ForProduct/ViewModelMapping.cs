using AutoMapper;
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
            CreateMap<UpdateProductViewModel, Product>(); 
            CreateMap<DeleteProductViewModel, Product>();
        }
    }
}
