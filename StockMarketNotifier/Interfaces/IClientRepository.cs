using StockMarketNotifier.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketNotifier.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> AddClient(Client _obj);
        Task<List<Client>> GetClients();
        Task<Client> UpdateClient(Client client,int id);
        Task<Client> DeleteClient(int clienId);


    }
}
