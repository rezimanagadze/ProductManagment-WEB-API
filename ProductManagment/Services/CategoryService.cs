using Microsoft.EntityFrameworkCore;
using ProductManagment.Model;
using ProductManagment.Interfaces;
using ProductManagment.Mapping;

namespace ProductManagment.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductManagmentContext _context;
        private readonly IMapper<Entity.Category, CategoryModel> _categoryMapper;


        public CategoryService(ProductManagmentContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }

        public CreateCategoryResponse CreateCategory(CategoryModel category)
        {
            var categoryAlreadyExists = _context.Categories.Any(p => p.Id == category.Id);

            if (categoryAlreadyExists)
            {
                throw new DbUpdateException($"Category with id '{category.Id} Already Exists");
            }

            var record = _context.Categories.Add(_categoryMapper.MapFromModelToEntity(category));
            _context.SaveChanges();

            return new CreateCategoryResponse{CreatedCategory = _categoryMapper.MapFromEntityToModel(record.Entity)};
        }


        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var category = _context.Categories.Find(getCategoryRequest.Id);

            return new GetCategoryResponse { Category = _categoryMapper.MapFromEntityToModel(category) };
        }


        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var categoryExists=_context.Categories.Find(updateCategoryRequest.CategoryToUpdate.Id);

            if(categoryExists==null)
            {
                throw new DbUpdateException($"Category With Id{updateCategoryRequest.CategoryToUpdate.Id} Does not exists");
            }

            _categoryMapper.MapFromModelToEntity(updateCategoryRequest.CategoryToUpdate, categoryExists);

            _context.SaveChanges();

            return new UpdateCategoryResponse {UptadetedCategory=updateCategoryRequest.CategoryToUpdate};
        }

        
        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest DeleteCategoryRequest)
        {
            var categoryDelete=_context.Categories.Find(DeleteCategoryRequest.Id);

            if(categoryDelete == null)
            {
                throw new DbUpdateException($"Category With Id{DeleteCategoryRequest.Id}does not exists");
            }

            _context.Categories.Remove(categoryDelete);
            _context.SaveChanges();
            return new DeleteCategoryResponse(); 
        }
      
    }
} 