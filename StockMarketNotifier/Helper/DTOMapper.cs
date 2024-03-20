using AutoMapper;
using StockMarketNotifier.DTO;
using StockMarketNotifier.Models;


namespace StockMarketNotifier.Helper
{
    public class DTOMapper : Profile
    {
        public static IMapper mapper { get; set; }
        static DTOMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDTO, Client>().ForMember(O=>O.clients,opt=>opt.Ignore()).ReverseMap()  ;
                //cfg.CreateMap<Response, StockDTO>().ReverseMap();
                cfg.CreateMap<Stock,StockDTO>().ReverseMap().ForMember(o=>o.Id,opt=>opt.Ignore());
           });
            configuration.AssertConfigurationIsValid();
            mapper = configuration.CreateMapper();
        }
    }
}
