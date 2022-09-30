using ProductManagment.Model;

namespace ProductManagment.Interfaces
{
    public interface ICategoryService
    {
        CreateCategoryResponse CreateCategory(CategoryModel request);
        GetCategoryResponse GetCategory(GetCategoryRequest request);
        UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request);


    }
}
