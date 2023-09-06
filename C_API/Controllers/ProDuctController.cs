using B_Bus.Respositories;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProDuctController : ControllerBase
    {
        private IProDuctRes _proDuctRes;

        public ProDuctController(IProDuctRes proDuctRes)
        {
            _proDuctRes = proDuctRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_proDuctRes.GetAll());
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
                var proDuctRes = _proDuctRes.GetProductById(id);
                return Ok(proDuctRes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(ProductDTO productDTO)
        {
            try
            {
                return Ok(_proDuctRes.AddProduct(productDTO));
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
                _proDuctRes.deleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, ProductDTO productDTO)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _proDuctRes.updateProduct(productDTO);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
