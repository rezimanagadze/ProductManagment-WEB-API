using Microsoft.EntityFrameworkCore;
using ProductManagment.Model;
using ProductManagment.Interfaces;
using ProductManagment.Mapping;

namespace ProductManagment.Services
{
    public class PackageProductService: IPackageProductService
    {
        private readonly ProductManagmentContext _context;
        private readonly IMapper<Entity.PackageProduct, PackageProductModel> _packageProductMapper;


        public PackageProductService(ProductManagmentContext context)
        {
            _context = context;
            _packageProductMapper = new PackageProductMapper();
        }

        public CreatePackageProductResponse CreatePackageProduct(PackageProductModel packageProduct)
        {
            var packageProductAlreadyExists=_context.PackageProducts.Any(p => p.Id == packageProduct.Id);

            if (packageProductAlreadyExists)
            {
                throw new DbUpdateException($"PackageProduct with Id{packageProduct.Id} already exists");
            }

            var record = _context.PackageProducts.Add(_packageProductMapper.MapFromModelToEntity(packageProduct));
            _context.SaveChanges();

            return new CreatePackageProductResponse{CreatedPackageProduct = _packageProductMapper.MapFromEntityToModel(record.Entity)};
        }

        public GetPackageProductResponse GetPackageProduct(GetPackageProductRequest getPackageProdcutRequest)
        {
            var packageProduct = _context.PackageProducts.Find(getPackageProdcutRequest.Id);

            return new GetPackageProductResponse { PackageProduct = _packageProductMapper.MapFromEntityToModel(packageProduct) };
        }


        public UpdatePackageProductResponse UpdatePackageProduct(UpdatePackageProductRequest packageProdcutUpdate)
        {
            var packageProductExists = _context.PackageProducts.Find(packageProdcutUpdate.PackageProductUpdate.Id);

            if (packageProductExists == null)
            {
                throw new DbUpdateException($"PackageProduct with Id{packageProdcutUpdate.PackageProductUpdate.Id} does not exists");
            }

            _packageProductMapper.MapFromModelToEntity(packageProdcutUpdate.PackageProductUpdate, packageProductExists);
            _context.SaveChanges();

            return new UpdatePackageProductResponse { UpdatedPackageProduct = packageProdcutUpdate.PackageProductUpdate };
        }


        public DeletePackageProductResponse DeletePackageProduct(DeletePackageProductRequest  packageProductDelete)
        {
            var packageProduct = _context.PackageProducts.Find(packageProductDelete.Id);

            if (packageProduct==null)
            {
                throw new DbUpdateException($"PackageProduct with Id{packageProductDelete.Id} does not exists");
            }

            _context.PackageProducts.Remove(packageProduct);
            _context.SaveChanges();

            return new DeletePackageProductResponse();
        }
    }
}
