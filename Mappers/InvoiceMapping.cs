
using Invoice = API_REST_PROYECT.Models.Invoice;
using AutoMapper;
using API_REST_PROYECT.DTOs.Invoice;

namespace API_REST_PROYECT.Mappers
{
    public class InvoiceMapping : Profile
    {
        public InvoiceMapping() 
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
        }
    }
}
