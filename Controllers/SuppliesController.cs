using API_REST_PROYECT.DTOs.Supply;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_REST_PROYECT.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ISupplyService<ProfileDTO> _profileService;
        private readonly ISupplyService<GlassDTO> _glassService;
        private readonly ISupplyService<AccessoryDTO> _accessoryService;
        private readonly ISupplyGeneralService _generalService;
        public SuppliesController(ISupplyService<ProfileDTO> profileService,
                                  ISupplyService<GlassDTO> glassService,
                                  ISupplyService<AccessoryDTO> accesoryService,
                                  ISupplyGeneralService generalService)
        {
            _profileService = profileService;
            _accessoryService = accesoryService;
            _glassService = glassService;
            _generalService = generalService;
            _generalService = generalService;
        }


        //____________ALTA____________//
        [HttpPost("altaPerfil")]
        [Authorize]
        public async Task<IActionResult> AddProfile(ProfileDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400

                var result = await _profileService.AddSupplyAsync(dto);
                return Ok("Creado correctamente."); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }


        [HttpPost("altaVidrio")]
        [Authorize]
        public async Task<IActionResult> AddVidrio(GlassDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400

                var result = await _glassService.AddSupplyAsync(dto);
                return Ok("Creado correctamente."); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }


        [HttpPost("altaAccesorio")]
        [Authorize]
        public async Task<IActionResult> AddAccessory(AccessoryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400

                var result = await _accessoryService.AddSupplyAsync(dto);
                return Ok("Creado correctamente."); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }

        //____________ELIMINAR____________//
        [HttpDelete("bajaInsumo")]
        [Authorize]
        public async Task<IActionResult> DeleteSupply(string sku)
        {
            try
            {
                if (sku.IsNullOrEmpty())
                    return BadRequest("Sku invalido"); //Codigo 400

                var tex = await _generalService.RemoveSupplyAsync(sku);
                return Ok(tex); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }

        //____________EDITAR____________//
        [HttpPut("editarInsumo")]
        [Authorize]
        public async Task<IActionResult> EditSupply(string sku, string description)
        {
            try
            {
                if (sku.IsNullOrEmpty())
                    return BadRequest("Sku invalido"); //Codigo 400

                var tex = await _generalService.RemoveSupplyAsync(sku);
                return Ok(tex); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
        }
    }
}
