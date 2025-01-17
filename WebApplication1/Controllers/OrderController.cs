using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTOS;
using WebApplication1.Data.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly OrderService _orderService;

		public OrderController(OrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<List<Order>> GetOrders()
		{
			return await _orderService.GetOrders();
		}

		[HttpPost]
		public async Task<bool> CreateOrder([FromBody]OrderCreateDTO orderCreateDTO)
		{
			return await _orderService.CreateOrder(orderCreateDTO);
		}
	}
}
