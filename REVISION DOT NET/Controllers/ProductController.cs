using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REVISION_DOT_NET.Entities;

namespace REVISION_DOT_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> getProduct()
        {
            var product = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = 1,
                    Description = "Test",
                    Stock = 1,
                    Title = "Test tiel",
                },
                  new ProductEntity
                {
                    Id = 2,
                    Description = "Test Description 2",
                    Stock = 5,
                    Title = "Test Title 2",
                },
                new ProductEntity
                {
                    Id = 3,
                    Description = "Test Description 3",
                    Stock = 20,
                    Title = "Test Title 3",
                },

            };

            var findSingle = product.Find(data => data.Id == 3);
            return Ok(findSingle);

        }
    }
}
