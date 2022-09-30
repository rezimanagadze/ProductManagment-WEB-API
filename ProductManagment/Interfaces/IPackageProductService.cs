using ProductManagment.Model;

namespace ProductManagment.Interfaces
{
    public interface IPackageProductService
    {
        CreatePackageProductResponse CreatePackageProduct(PackageProductModel request);
        GetPackageProductResponse GetPackageProduct(GetPackageProductRequest request);
        UpdatePackageProductResponse UpdatePackageProduct(UpdatePackageProductRequest request);
        DeletePackageProductResponse DeletePackageProduct(DeletePackageProductRequest request);
    }
}
