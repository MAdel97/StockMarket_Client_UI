using StockMarketNotifier.BL;
using StockMarketNotifier.Common;
using StockMarketNotifier.DTO;
using StockMarketNotifier.Interfaces;
using StockMarketNotifier.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketNotifier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockNotifierController : ControllerBase
    {
        private ClientBL clientBL=null;

        private readonly ILogger<StockNotifierController> _logger;

        public StockNotifierController(ILogger<StockNotifierController> logger)
        {
            clientBL = new ClientBL();
            _logger = logger;
        }

        [HttpPost("AddClient")]
        
        public  async Task<Client> AddClient([FromBody] ClientDTO clientDTO)
            {
             GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status  
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await clientBL.AddClient(clientDTO);
        }
        [HttpGet("GetClients")]
        public async Task<List<ClientDTO>>GetClients()
        {
           

            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
             return await clientBL.GetCLients();
        }
      
        [HttpPost("UpdateClient")]
        public async Task<ClientDTO> UpdateClient([FromBody] ClientDTO client)
         {
            
            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await clientBL.UpdateClient(client);
        }

        [HttpPost("DeleteClient")]
        public async Task<ClientDTO> DeleteClient([FromBody] ClientDTO clientDTO)
        {
           
            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await clientBL.DeleteClient(clientDTO.Id);
        }
    }
}
