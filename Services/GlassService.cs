using API_REST_PROYECT.DTOs.Supply;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.Models;
using AutoMapper;

namespace API_REST_PROYECT.Services
{
    public class GlassService : ISupplyService<GlassDTO>
    {
        private readonly ISupplyRepository<Glass> _glassRepository;
        private readonly IMapper _mapper;

        public GlassService(ISupplyRepository<Glass> glassRepository, IMapper mapper)
        {
            _glassRepository = glassRepository;
            _mapper = mapper;
        }


        public async Task<GlassDTO> AddSupplyAsync(GlassDTO Dto)
        {
            if (Dto == null) throw new Exception("Datos incorrectos.");

            var exist = await _glassRepository.GetByCodeAsync(Dto.codeSupply);
            if (exist != null)
                throw new InvalidOperationException("Ya existe un perfil creado con este codigo.");

            var glass = _mapper.Map <Glass>(Dto);
            var newGlass = await _glassRepository.AddAsync(glass);
            return _mapper.Map<GlassDTO>(newGlass);
        }
    }
}
