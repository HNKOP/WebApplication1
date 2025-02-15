using MediatR;
using WebApplication1.Entities;

namespace WebApplication1.Queries
{
    public class DataEntityQueryHandler : IRequestHandler<DataEntityQuery, IReadOnlyCollection<DataEntity>>
    {
        public async Task<IReadOnlyCollection<DataEntity>> Handle(DataEntityQuery request, CancellationToken cancellationToken)
        {
            return new List<DataEntity> { new DataEntity()
                {
                    Id = 1,
                    Code = 1,
                    Value = "Value1"
                }
            };
        }
    }
}
