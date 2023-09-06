using B_Bus.Respositories;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRes _categoryRes;

        public CategoryController(ICategoryRes categoryRes)
        {
            _categoryRes = categoryRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_categoryRes.GetAll());
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
                var categoryRes = _categoryRes.GetCategoryById(id);
                return Ok(categoryRes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(CategoryDTO categoryDTO)
        {
            try
            {
                return Ok(_categoryRes.AddCategory(categoryDTO));
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
                _categoryRes.deleteCategory(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, CategoryDTO categoryDTO)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _categoryRes.updateCategory(categoryDTO);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
