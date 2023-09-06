using B_Bus.Respositories;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandRes _brandRes;

        public BrandController(IBrandRes brandRes)
        {
            _brandRes = brandRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_brandRes.GetAll());
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
                var brand = _brandRes.GetBrandById(id);
                return Ok(brand);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(BrandDTO brandDTO)
        {
            try
            {
                return Ok(_brandRes.AddBrand(brandDTO));
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
                _brandRes.deleteBrand(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, BrandDTO brandDTO)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _brandRes.updateBrand(brandDTO);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
