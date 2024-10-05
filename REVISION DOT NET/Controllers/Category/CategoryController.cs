using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REVISION_DOT_NET.Data;
using REVISION_DOT_NET.Model.Domain.Category;
using REVISION_DOT_NET.Model.DTO;

namespace REVISION_DOT_NET.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private AppDbContext _context;
        private ResponseDto _responseDto;
        public CategoryController(AppDbContext context)
        {
            _context = context;
            _responseDto = new ResponseDto();
            
        }
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryModel categoryData)
        {
            try
            {
                var category = new CategoryModel
                {
                    categoryName = categoryData.categoryName,
                    slug = categoryData.slug,
                };

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                _responseDto.Message = "Category Created Successfully";
                _responseDto.IsSuccess = true;
                _responseDto.Result = category;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;

                return BadRequest(_responseDto);
            }
        }

    }
}
