using API_REST_PROYECT.DTOs.Supply;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.Models;
using AutoMapper;

namespace API_REST_PROYECT.Services
{
    public class AccessoryService : ISupplyService<AccessoryDTO>
    {
        private readonly ISupplyRepository<Accessory> _accessoryRepository;
        private readonly IMapper _mapper;

        public AccessoryService(ISupplyRepository<Accessory> accessoryRepository, IMapper mapper)
        {
            _accessoryRepository = accessoryRepository;
            _mapper = mapper;
        }
        public async Task<AccessoryDTO> AddSupplyAsync(AccessoryDTO Dto)
        {
            if (Dto == null) throw new Exception("Datos incorrectos.");

            var exist = await _accessoryRepository.GetByCodeAsync(Dto.codeSupply);
            if (exist != null)
                throw new InvalidOperationException("Ya existe un perfil creado con este codigo.");

            var accessory = _mapper.Map<Accessory>(Dto);
            var newAccessory = await _accessoryRepository.AddAsync(accessory);
            return _mapper.Map<AccessoryDTO>(newAccessory);
        }

    }
}
