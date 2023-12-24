using Application.dto;
using Application.usecase.order;
using Application.usecase.product;
using Domain.order.entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CreateOrder _create;
        private readonly GetAllOrders _getAll;
        private readonly GetOrderById _getById;

        public OrderController(
            CreateOrder create, 
            GetAllOrders getAll, 
            GetOrderById getById
            )
        {
            _create = create;
            _getAll = getAll;
            _getById = getById;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll()
        {
            var orders = await _getAll.Execute();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(Guid id) 
        {
            var order = await _getById.Execute(id);

            return Ok(order);
        }

        
        [HttpPost]
        public async Task<ActionResult<Order>> Create(List<OrderProductDTO> products)
        {
            var product = await _create.Execute(products);

            return Ok(product);
        }

    }
}
