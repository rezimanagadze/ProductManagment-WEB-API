using ProductManagment.Interfaces;
using ProductManagment.Model;
using ProductManagment.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ProductManagment.Services
{
    public class ProductService:IProductService
    {
        public readonly ProductManagmentContext _context;
        public readonly IMapper<Entity.Product, ProductModel> _productMapper;

        public ProductService(ProductManagmentContext context)
        {
            _context = context;
            _productMapper = new ProductMapper();
        }

        public CreateProductResponse CreateProduct(ProductModel product)
        {
            var productAlreadyExist=_context.Products.Any(p=>p.Id == product.Id);

            if(productAlreadyExist)
            {
                throw new DbUpdateException ($"Product With Id{product.Id} Already Exist");
            }

            var record = _context.Products.Add(_productMapper.MapFromModelToEntity(product));
            _context.SaveChanges();


            return new CreateProductResponse{CreatedProduct = _productMapper.MapFromEntityToModel(record.Entity)};
        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            var product = _context.Products.Find(getProductRequest.Id);

            return new GetProductResponse { Product=_productMapper.MapFromEntityToModel(product)};
        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest productToUpdate)
        {
            var productExists = _context.Products.Find(productToUpdate.ProductUpdate.Id);

            if(productExists==null)
            {
                throw new DbUpdateException($"Product with id{productToUpdate.ProductUpdate.Id} does not exists");
            }

            _productMapper.MapFromModelToEntity(productToUpdate.ProductUpdate, productExists);
            _context.SaveChanges();

            return new UpdateProductResponse { UpdatedProduct = productToUpdate.ProductUpdate };
        }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest productDelete)
        {
            var product = _context.Products.Find(productDelete.Id);

            if (product == null)
            {
                throw new DbUpdateException($"Product with id{productDelete.Id} does not exists");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return new DeleteProductResponse();
        }
    }
}
