using API_REST_PROYECT.DTOs.Supply;
using AutoMapper;
using Pro = API_REST_PROYECT.Models.Profile;
using Glass = API_REST_PROYECT.Models.Glass;
using Accessory = API_REST_PROYECT.Models.Accessory;
using GlassType = API_REST_PROYECT.Models.GlassType;

namespace API_REST_PROYECT.Mappers
{
    public class SupplyMapping : Profile
    {
        public SupplyMapping()
        {
            CreateMap<Pro, ProfileDTO>().ReverseMap();

            CreateMap<Accessory, AccessoryDTO>().ReverseMap();

        }
    }
}
