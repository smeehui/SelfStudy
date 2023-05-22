using CRUDProductApp_API.Data;
using CRUDProductApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDProductApp_API.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;

        public ProductService(AppDBContext context)
        {
            _context = context;
        }
        public Product Add(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(Guid id)
        {
            return _context.Products.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            Product? product = _context.Products.Where(s => s.Id.Equals(id)).FirstOrDefault();

            if (product != null)
            {
                _context.Products.Remove(product);
            }
            else
            {
                throw new DbUpdateException();
            }
        }

        public Product Update(Product entity)
        {
            Product? product = _context.Products.Find(entity);

            if (product != null)
            {
                return _context.Products.Update(product).Entity;
            }
            else
            {
                throw new DbUpdateException();
            }
        }
    }
}
