using B_Bus.Respositories;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailsRes _orderDetailsRes;

        public OrderDetailController(IOrderDetailsRes orderDetailsRes)
        {
            _orderDetailsRes = orderDetailsRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderDetailsRes.GetAll());
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
                var orderDetailsRes = _orderDetailsRes.GetOrderDetailById(id);
                return Ok(orderDetailsRes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(OrderDetailDTO orderDetailDTO)
        {
            try
            {
                return Ok(_orderDetailsRes.AddOrderDetail(orderDetailDTO));
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
                _orderDetailsRes.deleteOrderDetail(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, OrderDetailDTO orderDTO)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _orderDetailsRes.updateOrderDetail(orderDTO);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
