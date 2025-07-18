using API_REST_PROYECT.DTOs.Stock;
using AutoMapper;
using Stock =  API_REST_PROYECT.Models.Stock;

namespace API_REST_PROYECT.Mappers
{
    public class StockMapping : Profile
    {
        public StockMapping()
        {
            CreateMap<Stock, StockDto>().ReverseMap();
        }
    }
}
