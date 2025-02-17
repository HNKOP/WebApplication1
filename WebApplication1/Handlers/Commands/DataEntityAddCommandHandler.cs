using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Entities;
using WebApplication1.Entities.Commands;

namespace WebApplication1.Handlers.Commands
{
    public class DataEntityAddCommandHandler : IRequestHandler<DataEntityAddCommand>
    {
        private readonly WebApplicationContext _context;

        private readonly IMapper _mapper;

        public DataEntityAddCommandHandler(WebApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(DataEntityAddCommand request, CancellationToken cancellationToken)
        {
            await _context.DataEntities.ExecuteDeleteAsync(cancellationToken);

            var sortedRequest = request.DataEntities?.OrderBy(x => x.Code);

            var result = _mapper.Map<IEnumerable<DataEntityDto>, IEnumerable<DataEntity>>(sortedRequest);

            await _context.DataEntities.AddRangeAsync(result, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
