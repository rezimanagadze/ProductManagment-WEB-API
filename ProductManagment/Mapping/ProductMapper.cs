using ProductManagment.Model;
using ProductManagment.Interfaces;

namespace ProductManagment.Mapping
{
    public class ProductMapper: IMapper<Entity.Product, ProductModel>
    {
        public ProductModel MapFromEntityToModel(Entity.Product source)=> new ProductModel
        {
            Name = source.Name,
            Price = source.Price,
            Category = source.Category,
            Description=source.Description,
            Id = source.Id,

        };

        public Entity.Product MapFromModelToEntity(ProductModel source)
        {
            var entity=new Entity.Product();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(ProductModel source, Entity.Product target)
        {
            target.Name = source.Name;
            target.Price = source.Price;
            target.Category = source.Category;
            target.Description = source.Description;
            target.Id=source.Id;
        }
    }
}
