using Application.errors;
using Application.repository;
using Domain.order.entity;
using Infra.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.repository
{
    public class OrderRepositoryDatabase : OrderRepository
    {

        private readonly ApplicationContext _contex;

        public OrderRepositoryDatabase(ApplicationContext contex) => _contex = contex;

        public async Task<List<Order>> GetAll()
        {
            return await _contex.Orders
                .Include(order => order.Products)
                    .ThenInclude(orderProduct => orderProduct.Product)
                .ToListAsync();
        }

        public async Task<Order> Get(Guid id)
        {
            var order = await _contex.Orders
                .Include(order => order.Products)
                    .ThenInclude(orderProduct => orderProduct.Product)
                .FirstAsync(order => order.Id == id);

            if(order is null)
            {
                throw new NotFoundError("Order was not found");
            }

            return order;
        }

        public async Task Save(Order order)
        {
            await _contex.Orders.AddAsync(order);
            await _contex.SaveChangesAsync();
        }

        public Task Update(Order order)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
