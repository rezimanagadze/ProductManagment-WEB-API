using ProductManagment.Model;
using ProductManagment.Services;

namespace ProductManagment.Interfaces
{
    public interface IPackageService
    {
        CreatePackageResponse CreatePackage(PackageModel request);
        GetPackageResponse GetPackage(GetPackageRequest request);
        UpdatePackageResponse UpdatePackage(UpdatePackageRequest request);
        DeletePackageResponse DeletePackage(DeletePackageRequest request);

    }
}
