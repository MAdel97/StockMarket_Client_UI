using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using StockMarketNotifier.BL;
using StockMarketNotifier.DTO;
using StockMarketNotifier.Models;
using System.Collections.Generic;
using AcademicCoursesCRUD.Common;
using System;

namespace StockMarketNotifier.Helper { 
internal interface IScopedProcessingService
{
    Task DoWork(CancellationToken stoppingToken);
}

    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private StockBLL stockBLL = null;
        private ClientBL clientBL = null;
        

        private readonly ILogger _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;
            stockBLL = new StockBLL();
            clientBL= new ClientBL();

        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);
               List<StockDTO> response= WebAPIConsumer.AddComponent();
                if (response!=null)
                {
                    try
                    {
                        await stockBLL.AddStock(response);
                        var clients = await clientBL.GetCLients();
                        var lastupdate = await stockBLL.GetLatestStock();
                       
                        foreach (var client in clients)
                        {
                         

                            /* Email.SendMail("inbox.adel@gmail.com","Eden_1997",   "client.EmailAddress" +
                                 "","Latest Stock Updates" +
                                 "","dear clients");*/
                            client.lastupdated= DateTime.Now;
                            client.isUpdated = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                
              

                await Task.Delay(21600000, stoppingToken);
            }
        }
    }
}