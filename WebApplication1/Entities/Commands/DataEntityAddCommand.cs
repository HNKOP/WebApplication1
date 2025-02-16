using MediatR;

namespace WebApplication1.Entities.Commands
{
    public class DataEntityAddCommand : IRequest
    {
        public IReadOnlyCollection<DataEntityDto>? DataEntities { get; set; }
    }
}
