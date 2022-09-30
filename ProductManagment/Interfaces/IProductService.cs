using ProductManagment.Model;

namespace ProductManagment.Interfaces
{
    public interface IProductService
    {
        CreateProductResponse CreateProduct(ProductModel request);
        GetProductResponse GetProduct(GetProductRequest request);
        UpdateProductResponse UpdateProduct(UpdateProductRequest request);
        DeleteProductResponse DeleteProduct(DeleteProductRequest request);
    }
}
