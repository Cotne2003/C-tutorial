using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Entities;
using OrderManagementSystem.Interfaces;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("Id")]
        public async Task<Order> GetById(int id)
        {
            return await _orderService.GetOrderById(id);
        }

        [HttpPost]
        public async Task<bool> CreateOrder(OrderCreateDTO orderCreateDTO)
        {
            return await _orderService.CreateOrder(orderCreateDTO); 
        }

        [HttpPut]
        public async Task<bool> UpdateOrder(OrderUpdateDTO orderUpdateDTO)
        {
            return await _orderService.UpdateOrder(orderUpdateDTO);
        }

        [HttpGet]
        public async Task<List<Order>> GetAll(int userId)
        {
            return await _orderService.GetAllOrders(userId);
        }


    }
}
