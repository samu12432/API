using API_REST_PROYECT.DTOs.Product;
using API_REST_PROYECT.DTOs.Stock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_PROYECT.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost("crearProducto")]
        [Authorize]
        public async Task<IActionResult> CreateProduct(ProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }
    }
}
