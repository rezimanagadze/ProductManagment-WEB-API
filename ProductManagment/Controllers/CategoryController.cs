using Microsoft.AspNetCore.Mvc;
using ProductManagment.Interfaces;
using ProductManagment.Model;

namespace ProductManagment.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("createCategory")]
        public CreateCategoryResponse CreateCategory(CategoryModel request)=>_categoryService.CreateCategory(request);

        [HttpPost("getCategory")]
        public GetCategoryResponse GetCategory(GetCategoryRequest request)=> _categoryService.GetCategory(request);

        [HttpPost("updateCategory")]
        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request)=>_categoryService.UpdateCategory(request);

        [HttpPost("deleteCategory")]
        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request) => _categoryService.DeleteCategory(request);

    }
}
