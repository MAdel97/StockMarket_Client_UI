using StockMarketNotifier.DTO;
using StockMarketNotifier.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketNotifier.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> AddStock(Stock _obj);
        Task<Stock> GetLatestStock( );




    }
}
