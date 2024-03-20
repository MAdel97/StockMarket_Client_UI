using System;
using System.Collections.Generic;
using System.Reflection;

namespace StockMarketNotifier.Models
{
    public  class Client
    {
       
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public DateTime lastupdated { get; set; }
        public bool isUpdated { get; set; }
        public virtual Client clients { get; set; }
    }
}
