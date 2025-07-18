using API_REST_PROYECT.DTOs.Auth;
using API_REST_PROYECT.DTOs.Stock;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_PROYECT.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }


        [HttpPost("crearStock")]
        [Authorize]
        public async Task<IActionResult> CreateStock(StockDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400

                var result = await _stockService.CreateStock(dto);
                if (!result)
                    return Unauthorized("El stock ya se encuentra creado."); //Codigo 401

                return Ok("Stock registrado correctamente."); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }

        [HttpPut("editarStock")]
        [Authorize]
        public async Task<IActionResult> UpdateStock(StockDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400

                await _stockService.UpdateStock(dto);

                return Ok("Stock registrado correctamente."); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }



        [HttpGet("verStock")]
        [Authorize]
        public async Task<IActionResult> GetAllStock()
        {
            try
            {
                var stockList = await _stockService.GetAllStock();
                return Ok(stockList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el stock", error = ex.Message });
            }
        }

        [HttpGet("stockSku")]
        [Authorize]
        public async Task<IActionResult> GetStockBySKu(string sku)
        {
            try
            {
                var stockList = await _stockService.GetStockBySku(sku);
                return Ok(stockList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el stock", error = ex.Message });
            }
        }



    }
}
