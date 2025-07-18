using API_REST_PROYECT.DTOs.Supply;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using Profile = API_REST_PROYECT.Models.Profile;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;


namespace API_REST_PROYECT.Services
{
    public class ProfileService : ISupplyService<ProfileDTO>
    {
        private readonly ISupplyRepository<Profile> _perfilRepository;
        private readonly IMapper _mapper;

        public ProfileService(ISupplyRepository<Profile> perfilRepository, IMapper mapper)
        {
            _perfilRepository = perfilRepository;
            _mapper = mapper;
        }
        public async Task<ProfileDTO> AddSupplyAsync(ProfileDTO Dto)
        {
            if (Dto == null) throw new Exception("Datos incorrectos.");

            var exist = await _perfilRepository.GetByCodeAsync(Dto.codeSupply);
            if (exist != null)
                throw new InvalidOperationException("Ya existe un perfil creado con este codigo.");

            var perfil = _mapper.Map<Profile>(Dto);
            var newPerfil = await _perfilRepository.AddAsync(perfil);
            return _mapper.Map<ProfileDTO>(newPerfil);
        }

    }
}
