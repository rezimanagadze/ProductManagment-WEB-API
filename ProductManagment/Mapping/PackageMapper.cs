using ProductManagment.Interfaces;
using ProductManagment.Model;

namespace ProductManagment.Mapping
{
    public class PackageMapper: IMapper<Entity.Package, PackageModel>
    {
        public PackageModel MapFromEntityToModel(Entity.Package source) => new PackageModel
        {
            Name = source.Name,
            Price = source.Price,
            Description = source.Description,
            Id = source.Id,
        };

        public Entity.Package MapFromModelToEntity(PackageModel source)
        {
            var entity = new Entity.Package();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(PackageModel source, Entity.Package target)
        {
            target.Id = source.Id;
            target.Name=source.Name;
            target.Price= source.Price;
            target.Description= source.Description;
        }

    }
}
