using API_REST_PROYECT.DTOs.Stock;
using API_REST_PROYECT.DTOs.Supply;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.Models;
using API_REST_PROYECT.Repository;
using AutoMapper;

namespace API_REST_PROYECT.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly ISupplyRepository<Supply> _supplyRepository;
        private readonly Mapper _mapper;

        public StockService(IStockRepository stockRepository, ISupplyRepository<Supply> supplyGeneral, Mapper mapper)
        {
            _stockRepository = stockRepository;
            _supplyRepository = supplyGeneral;
            _mapper = mapper;
        }

        public async Task<bool> CreateStock(StockDto dto)
        {
            if (dto == null) throw new Exception("Datos incorrectos.");

            //Validamos que no exista 
            var exist = await _stockRepository.GetStockBySku(dto.skuSupply);
            if (exist != null)
                throw new InvalidOperationException("Ya existe.");

            //Generamos 
            var supply = await _supplyRepository.GetByCodeAsync(dto.skuSupply);
            if (supply == null)
                throw new InvalidOperationException("No se encontró el insumo con ese código.");

            Stock newStock = new Stock
            {
                stockSupply = supply,
                stockQuantity = dto.stockQuantity,
                stockCreate = new DateTime(),
                stockUpdate = new DateTime(),
            };

            await _stockRepository.AddAsync(newStock);

            return true;
        }

        public async Task UpdateStock(StockDto dto)
        {
            if (dto == null) throw new Exception("Datos incorrectos.");

            Stock? exist = await _stockRepository.GetStockBySku(dto.skuSupply);
            if (exist == null)
                throw new InvalidOperationException("No existe.");

            if(dto.stockQuantity <= 0) throw new InvalidOperationException("El stock debe ser mayor a 0.");

            exist.stockQuantity = dto.stockQuantity;
            exist.stockUpdate = new DateTime();

            await _stockRepository.UpdateStockAsync(exist);
        }

        public async Task<IEnumerable<StockDto>> GetAllStock()
        {
            var stocks = await _stockRepository.GetAllStock();
            return _mapper.Map<IEnumerable<StockDto>>(stocks);

        }

        public async Task<StockDto?> GetStockBySku(string sku)
        {
            if (!string.IsNullOrEmpty(sku)) throw new Exception("Es necesario ingresar un Sku");
            var stock = await _stockRepository.GetStockBySku(sku);
            if (stock != null)
                throw new InvalidOperationException("No existe.");
            return _mapper.Map<StockDto>(stock);
        }
    }
}
