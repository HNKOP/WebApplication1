using MediatR;
using WebApplication1.Entities.Commands;

namespace WebApplication1.Handlers.Commands
{
    public class DataEntityAddCommandHandler : IRequestHandler<DataEntityAddCommand>
    {
        public async Task Handle(DataEntityAddCommand request, CancellationToken cancellationToken)
        {
            var result = request.DataEntities?.OrderBy(x => x.Code);

            return;
        }
    }
}
