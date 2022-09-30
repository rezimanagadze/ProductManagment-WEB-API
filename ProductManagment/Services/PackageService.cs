using ProductManagment.Model;
using ProductManagment.Interfaces;
using ProductManagment.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ProductManagment.Services
{
    public class PackageService: IPackageService
    {
        private readonly ProductManagmentContext _context;
        private readonly IMapper<Entity.Package, PackageModel> _packageMapper;

        public PackageService(ProductManagmentContext context)
        {
           _context=context;
           _packageMapper = new PackageMapper();
        }

        public CreatePackageResponse CreatePackage(PackageModel package)
        {
            var packageAlreadyExist=_context.Packages.Any(p=>p.Id==package.Id);

            if(packageAlreadyExist)
            {
                throw new DbUpdateException($"Package With id {package.Id} Already Exist");
            }

            var record = _context.Packages.Add(_packageMapper.MapFromModelToEntity(package));
            _context.SaveChanges();

            return new CreatePackageResponse{CreatedPackage=_packageMapper.MapFromEntityToModel(record.Entity)};
                    
        }

        public GetPackageResponse GetPackage(GetPackageRequest getPackageRequest)
        {
            var package=_context.Packages.Find(getPackageRequest.Id);

            return new GetPackageResponse { Package = _packageMapper.MapFromEntityToModel(package) };
        }

        
        public UpdatePackageResponse UpdatePackage(UpdatePackageRequest UpdatePackageRequest)
        {
            var packageExists = _context.Packages.Find(UpdatePackageRequest.PackageToUpdated.Id);

            if(packageExists == null)
            {
                throw new DbUpdateException($"Package With Id{UpdatePackageRequest.PackageToUpdated.Id} does not  Exists");
            }

            _packageMapper.MapFromModelToEntity(UpdatePackageRequest.PackageToUpdated, packageExists);
            _context.SaveChanges();

            return new UpdatePackageResponse() { UpdatedPackage = UpdatePackageRequest.PackageToUpdated };
        }

        public DeletePackageResponse DeletePackage(DeletePackageRequest deletePackageReequest)
        {
            var PackageDelete= _context.Packages.Find(deletePackageReequest.Id);

            if(PackageDelete == null)
            {
                throw new DbUpdateException($"Package With Id{deletePackageReequest.Id}Does  not exists");
            }

            _context.Packages.Remove(PackageDelete);
            _context.SaveChanges();

            return new DeletePackageResponse();
        }
    }
}
