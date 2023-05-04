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
            var result = _service.GetAllProducts();
            if (!result.Success)
            {
                TempData["ListError"] = result.Message;
                return RedirectToAction("Index","Home");
            }
            ViewData["ListSuccess"] = result.Message;
            var mappedEntity = _mapper.Map<List<ProductViewModel>>(result.Data);
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
            if (ModelState.IsValid)
            {
                var mapToEntity = _mapper.Map<Product>(request);
                var result = _service.AddProduct(mapToEntity);
                if(!result.Success)
                {
                    TempData["CreateError"] = result.Message;
                    return RedirectToAction("Index");
                }
                TempData["CreateSuccess"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add" , request);
            }

        }

        [HttpGet]
        public IActionResult Remove(DeleteProductViewModel request)
        {
            var deleteToEntity = _service.GetProduct(request.Id);
            var mapToEntity = _mapper.Map<Product>(deleteToEntity.Data);
            var result = _service.DeleteProduct(mapToEntity);
            if(!result.Success)
            {
                TempData["DeleteError"] = result.Message;
                return RedirectToAction("Index");
            }
            TempData["DeleteSuccess"] = result.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var productToUpdate = _service.GetProduct(id);
            var mapToEntity = _mapper.Map<UpdateProductViewModel>(productToUpdate.Data);
            return View(mapToEntity);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel request , int id)
        {
            var updateToEntity = _service.GetProduct(id);
            var updatedEntity = _mapper.Map(request, updateToEntity.Data);

            updateToEntity.Data.TradeMark = updatedEntity.TradeMark;
            updateToEntity.Data.Stock = updatedEntity.Stock;
            updateToEntity.Data.Price = updatedEntity.Price;
            updateToEntity.Data.Name = updatedEntity.Name;

            var result = _service.UpdateProduct(updateToEntity.Data);
            if (!result.Success)
            {
              
                ViewData["UpdateError"] = result.Message;
                return View("Update");
            }
            TempData["UpdateSuccess"] = result.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetDetail(int id)    
        {
            var item = _service.GetProductDetail(id);
            var mappedItem = _mapper.Map<GetProductWithDetailByIdViewModel>(item);
            return View(mappedItem);
        }

    }
}
