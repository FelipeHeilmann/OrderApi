﻿using Application.repository;
using Domain.order.entity;
using Infra.context;
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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
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
    }
}