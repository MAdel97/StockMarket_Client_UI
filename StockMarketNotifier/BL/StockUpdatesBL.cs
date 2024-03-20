using StockMarketNotifier.Common;
using StockMarketNotifier.DTO;
using StockMarketNotifier.Helper;
using StockMarketNotifier.Interfaces;
using StockMarketNotifier.Models;
using StockMarketNotifier.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockMarketNotifier.BL
{
    public class StockBLL : DTOMapper
    {
        private IStockRepository repository = null;
        private readonly IConfiguration _configuration;
        public StockBLL()
        {

            this.repository = new StockRepository( );
        }

        public async Task<Stock> AddStock(List<StockDTO> stock )
        {
            var obj = DTOMapper.mapper.Map<List<Stock>>(stock);
           

            var results=  await repository.AddStock(obj[0]);
            return  results;
           

        }
        public async Task<StockDTO> GetLatestStock()
        {
            var stock = await repository.GetLatestStock();

            var objDTO = DTOMapper.mapper.Map<StockDTO>(stock);
            return objDTO;
        }

    
    }
}

