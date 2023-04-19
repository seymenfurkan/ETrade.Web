using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.DataAccess.Abstract;
using ETrade.Entities.Concrete;
using ETrade.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _service.GetAllProducts();
            var mappedEntity = _mapper.Map<List<ProductViewModel>>(products);
            return View(mappedEntity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductViewModel request)
        {
            var mapToEntity = _mapper.Map<Product>(request);
            _service.AddProduct(mapToEntity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(DeleteProductViewModel request)
        {
            var deleteToEntity = _service.GetProduct(request.Id);
            var mapToEntity = _mapper.Map<Product>(deleteToEntity);
            _service.DeleteProduct(mapToEntity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var productToUpdate = _service.GetProduct(id);
            return View(productToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel request , int id)
        {
            var updateToEntity = _service.GetProduct(id);
            var updatedEntity = _mapper.Map(request, updateToEntity);

            updateToEntity.TradeMark = updatedEntity.TradeMark;
            updateToEntity.Stock = updatedEntity.Stock;
            updateToEntity.Price = updatedEntity.Price;
            updateToEntity.Name = updatedEntity.Name;

            _service.UpdateProduct(updateToEntity);

            return RedirectToAction("Index");
        }

    }
}
