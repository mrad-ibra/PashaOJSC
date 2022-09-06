using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductStockApi.Interfaces;

namespace ProductStockApi.Controllers
{
    [Route("api/v1/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockRepository _service;
        private readonly ILogger<StockController> _logger;
        public StockController(IStockRepository service, ILogger<StockController> logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetStock(int id)
        {
            _logger.LogInformation("This is GetStock()");
            var stock = _service.GetStock(id);
            return Ok(stock);
        }
        [HttpPut]
        [Route("add")]
        public IActionResult AddStock(int id, int count)
        {
            _logger.LogInformation("This is AddStock()");
            var stock = _service.AddStock(id, count);
            return Ok(stock);
        }

        [HttpPut]
        [Route("delete")]
        public IActionResult RemoveStock(int id, int count)
        {
            _logger.LogInformation("This is RemoveStock()");
            var stock = _service.RemoveStock(id, count);
            return Ok(stock);
        }
    }
}
