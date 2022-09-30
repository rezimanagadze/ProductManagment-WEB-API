using Microsoft.AspNetCore.Mvc;
using ProductManagment.Interfaces;
using ProductManagment.Model;

namespace ProductManagment.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PackageProductController : Controller
    {
        private readonly IPackageProductService _packageProductService;

        public PackageProductController(IPackageProductService packageProductService)
        {
            _packageProductService=packageProductService;
        }


        [HttpPost("createPackageProduct")]
        public CreatePackageProductResponse CreatePackageProduct(PackageProductModel request)=>_packageProductService.CreatePackageProduct(request);

        [HttpPost("getPackageProduct")]
        public GetPackageProductResponse GetPackageProduct(GetPackageProductRequest request) => _packageProductService.GetPackageProduct(request);

        [HttpPost("updatePackageProduct")]
        public UpdatePackageProductResponse UpdatePackageProduct(UpdatePackageProductRequest request) => _packageProductService.UpdatePackageProduct(request);

        [HttpPost("deletePackageProduct")]
        public DeletePackageProductResponse DeletePackageProduct(DeletePackageProductRequest request) => _packageProductService.DeletePackageProduct(request);

    }
}
