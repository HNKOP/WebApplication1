using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplication1.DAL;
using WebApplication1.Entities;
using WebApplication1.Entities.Commands;
using WebApplication1.Utils;

namespace WebApplication1.Handlers.Commands
{
    public class DataEntityAddCommandHandler : IRequestHandler<DataEntityAddCommand>
    {
        private readonly WebApplicationContext _context;

        public DataEntityAddCommandHandler(WebApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(DataEntityAddCommand request, CancellationToken cancellationToken)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            serializeOptions.Converters.Add(new DataEntityJsonConverter());
            var dataEntities = JsonSerializer.Deserialize<List<DataEntity>>(request.DataEntitiesJsonArray, serializeOptions);

            await _context.DataEntities.ExecuteDeleteAsync(cancellationToken);

            await _context.DataEntities.AddRangeAsync(dataEntities.OrderBy(x => x.Code), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
