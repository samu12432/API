using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.Models;
using Microsoft.IdentityModel.Tokens;

namespace API_REST_PROYECT.Services
{
    public class SupplyService : ISupplyGeneralService
    {
        private readonly ISupplyRepository<Glass> _glassRepositor;
        private readonly ISupplyRepository<Accessory> _accessoryRepositor;
        private readonly ISupplyRepository<Profile> _profileRepository;

        public SupplyService(
            ISupplyRepository<Glass> glassRepo,
            ISupplyRepository<Accessory> accessoryRepo,
            ISupplyRepository<Profile> profileRepo)
        {
            _glassRepositor = glassRepo;
            _accessoryRepositor = accessoryRepo;
            _profileRepository = profileRepo;
        }

        public async Task<string> RemoveSupplyAsync(string sku)
        {
            if (sku.IsNullOrEmpty()) throw new Exception("Sku invalido.");
            {
                // Buscar en vidrio
               var glass = await _glassRepositor.GetByCodeAsync(sku);
                if (glass != null)
                {
                    await _glassRepositor.RemoveAsync(glass);
                    return $"Vidrio con SKU {sku} eliminado.";
                }

                // Buscar en accesorios
                var accessory = await _accessoryRepositor.GetByCodeAsync(sku);
                if (accessory != null)
                {
                    await _accessoryRepositor.RemoveAsync(accessory);
                    return $"Accesorio con SKU {sku} eliminado.";
                }

                // Buscar en perfiles
                var profile = await _profileRepository.GetByCodeAsync(sku);
                if (profile != null)
                {
                    await _profileRepository.RemoveAsync(profile);
                    return $"Perfil con SKU {sku} eliminado.";
                }

                throw new InvalidOperationException($"No se encontró ningún insumo con SKU: {sku}");
            }
        }
    }
}
