using B_Bus.Respositories;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRes _orderRes;

        public OrderController(IOrderRes orderRes)
        {
            _orderRes = orderRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderRes.GetAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var orderRes = _orderRes.GetOrderById(id);
                return Ok(orderRes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(OrderDTO orderDTO)
        {
            try
            {
                return Ok(_orderRes.AddOrder(orderDTO));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _orderRes.deleteOrder(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, OrderDTO orderDTO)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _orderRes.updateOrder(orderDTO);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
