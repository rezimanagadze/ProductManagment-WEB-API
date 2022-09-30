using Microsoft.AspNetCore.Mvc;
using ProductManagment.Interfaces;
using ProductManagment.Model;

namespace ProductManagment.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost("createPackage")]
        public CreatePackageResponse CreatePackage(PackageModel request)=> _packageService.CreatePackage(request);

        [HttpPost("getPackage")]
        public GetPackageResponse GetPackage(GetPackageRequest request) => _packageService.GetPackage(request);

        [HttpPost("updatePackage")]
        public UpdatePackageResponse UpdatePackage(UpdatePackageRequest request) => _packageService.UpdatePackage(request);

        [HttpPost("deletePackage")]
        public DeletePackageResponse DeletePackage(DeletePackageRequest request) => _packageService.DeletePackage(request);
    }
}
