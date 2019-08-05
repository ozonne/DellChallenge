using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto GetById(string id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            return product != null ? MapToDto(product) : null;
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Update(ProductDto product)
        {
            var dataProduct = _context.Products.Where(p => p.Id == product.Id).FirstOrDefault();
            if (dataProduct == null)
            {
                return null;
            }
            dataProduct.Name = product.Name;
            dataProduct.Category = product.Category;
            _context.Products.Update(dataProduct);
            _context.SaveChanges();
            return product;
        }

        public ProductDto Delete(string id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return MapToDto(product);
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
