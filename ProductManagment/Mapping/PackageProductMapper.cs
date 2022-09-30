using ProductManagment.Interfaces;
using ProductManagment.Model;

namespace ProductManagment.Mapping
{
    public class PackageProductMapper: IMapper<Entity.PackageProduct, PackageProductModel>
    {
        public PackageProductModel MapFromEntityToModel(Entity.PackageProduct source) => new PackageProductModel
        {
            Id = source.Id,
            PackageId = source.PackageId,
            ProductId = source.ProductId,
        };

        public Entity.PackageProduct MapFromModelToEntity(PackageProductModel source)
        {
            var entity = new Entity.PackageProduct();

            MapFromModelToEntity(source, entity);

            return entity;
        }



        public void MapFromModelToEntity(PackageProductModel source, Entity.PackageProduct target)
        {
            target.Id = source.Id;
            target.PackageId = source.PackageId;
            target.ProductId = source.ProductId;
        }
    }
}
