using MediatR;
using System.Text.Json.Nodes;

namespace WebApplication1.Entities.Commands
{
    public class DataEntityAddCommand : IRequest
    {
        public JsonArray? DataEntitiesJsonArray { get; set; }
    }
}
