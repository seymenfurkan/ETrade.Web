using AutoMapper;
using ETrade.Business.Abstract;
using ETrade.Core.Entities.DTOs;
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
            var mappedEntity = _mapper.Map<List<ProductListViewModel>>(result.Data);
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
                var mapToEntity = _mapper.Map<CreateProductDto>(request);
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
      
            var mappedEntity = _mapper.Map<DeleteProductDto>(request);
            var deleteToEntity = _service.GetProduct(mappedEntity.Id);

            var data = deleteToEntity.Data;
            var entity = _mapper.Map<DeleteProductDto>(data);
            
            var result = _service.DeleteProduct(entity);

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
            var data = productToUpdate.Data;

            var mapToEntity = _mapper.Map<UpdateProductViewModel>(data);
            return View(mapToEntity);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel request)
        {
            var mappedEntity = _mapper.Map<GetProductByIdDto>(request);
            var updateToEntity = _service.GetProduct(mappedEntity.Id);

            var updateToData = updateToEntity.Data;
            var updatedData = mappedEntity;


            var updatedEntity = _mapper.Map(updatedData , updateToData);
            var entity = _mapper.Map<UpdateProductDto>(updatedEntity);

            var result = _service.UpdateProduct(entity);
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
