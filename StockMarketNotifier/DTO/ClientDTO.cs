using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketNotifier.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public DateTime lastupdated { get; set; }
        public bool isUpdated { get; set; }



    }
}   
