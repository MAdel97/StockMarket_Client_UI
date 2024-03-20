using StockMarketNotifier.Common;
using StockMarketNotifier.Helper;
using StockMarketNotifier.Interfaces;
using StockMarketNotifier.Models;
using StockMarketNotifier.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockMarketNotifier.DTO;

namespace StockMarketNotifier.BL
{
    public class ClientBL : DTOMapper
    {
        private IClientRepository repository = null;
        private readonly IConfiguration _configuration;
        public ClientBL()
        {

            this.repository = new ClientRepository();
        }

        public async Task<Client> AddClient(ClientDTO clientDTO )
        {
            var obj = DTOMapper.mapper.Map<Client>(clientDTO);

            return await repository.AddClient(obj);
           

        }
        public async Task<List<ClientDTO>> GetCLients()
        {
            var clients = await repository.GetClients();

            var objDTO = DTOMapper.mapper.Map<List<ClientDTO>>(clients);
            return objDTO;
        }


        public async Task<ClientDTO> UpdateClient (ClientDTO clientDTO )
        {
            int id = clientDTO.Id;
            var obj = DTOMapper.mapper.Map<Client>(clientDTO);

            var client = await repository.UpdateClient(obj,id);

            var objDTO = DTOMapper.mapper.Map<ClientDTO>(client);
            return objDTO;
        }

        public async Task<ClientDTO> DeleteClient(int clientID)
        {
            var academicCourse = await repository.DeleteClient(clientID);

            var objDTO = DTOMapper.mapper.Map<ClientDTO>(academicCourse);
            return objDTO;
        }
    }
}

