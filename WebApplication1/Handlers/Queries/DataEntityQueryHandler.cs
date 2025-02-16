using MediatR;
using System.Linq;
using WebApplication1.Entities;
using WebApplication1.Entities.Queries;

namespace WebApplication1.Handlers.Queries
{
    public class DataEntityQueryHandler : IRequestHandler<DataEntityQuery, IReadOnlyCollection<DataEntity>>
    {
        public async Task<IReadOnlyCollection<DataEntity>> Handle(DataEntityQuery request, CancellationToken cancellationToken)
        {
            var query = GetFilteredQuery(request);

            return query.ToList();
        }

        private IQueryable<DataEntity> GetFilteredQuery(DataEntityQuery request)
        {
            var query = new List<DataEntity> { new DataEntity()
                {
                    Id = 1,
                    Code = 1,
                    Value = "Value1"
                },
                new DataEntity()
                {
                    Id = 2,
                    Code = 5,
                    Value = "Value2"
                },
            };

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
