using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using WebApplication1.Entities;
using WebApplication1.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ISender _sender;

        public DataController(ISender sender)
        {
            _sender = sender;
        }

        // GET: api/<DataController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DataEntityQuery request, CancellationToken token)
        {
            var result = await _sender.Send(request, token);

            return Ok(result);
        }

        // POST api/<DataController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JsonArray request, CancellationToken token)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            serializeOptions.Converters.Add(new DataEntityDtoJsonConverter());
            var DataEntityDtos = JsonSerializer.Deserialize<List<DataEntityDto>>(request, serializeOptions);            
            

            var result = await _sender.Send(DataEntityDtos, token);

            return Ok();
        }
    }
}
