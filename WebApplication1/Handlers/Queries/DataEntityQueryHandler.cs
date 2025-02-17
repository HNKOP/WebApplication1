using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.DAL;
using WebApplication1.Entities;
using WebApplication1.Entities.Queries;

namespace WebApplication1.Handlers.Queries
{
    public class DataEntityQueryHandler : IRequestHandler<DataEntityQuery, IReadOnlyCollection<DataEntity>>
    {
        private readonly WebApplicationContext _context;

        public DataEntityQueryHandler(WebApplicationContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<DataEntity>> Handle(DataEntityQuery request, CancellationToken cancellationToken)
        {
            var query = GetFilteredQuery(request);

            return await query.ToListAsync(cancellationToken);
        }

        private IQueryable<DataEntity> GetFilteredQuery(DataEntityQuery request)
        {
            var query = _context.DataEntities;

            if (request.Id != null)
            {
                query.Where(x => x.Id == request.Id);
            }

            if (request.Code != null)
            {
                query.Where(x => x.Code == request.Code);
            }


            if (string.IsNullOrEmpty(request.Value))
            {
                query.Where(x => x.Value.Contains(request.Value));
            }

            return query.AsQueryable();
        }
    }
}
