using Application.repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.product.entity;
using Infra.context;
using Microsoft.EntityFrameworkCore;
using Application.errors;
using System.Reflection.Metadata.Ecma335;

namespace Infra.repository
{
    public class ProductRepositoryDatabase : ProductRepository
    {
        private readonly ApplicationContext _context;

        
        public ProductRepositoryDatabase(ApplicationContext context){
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<Product> Get(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if(product == null)
            {
                throw new NotFoundError("Product not found");
            }

            return product;
        }

        public async Task Save(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(); 
        }
        public async Task<bool> Delete(Product product)
        {
           
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
