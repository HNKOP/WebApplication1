using MediatR;

namespace WebApplication1.Entities.Queries
{
    public class DataEntityQuery : IRequest<IReadOnlyCollection<DataEntity>>
    {
        public int? Id { get; set; }
        public int? Code { get; set; }

        public string? Value { get; set; }
    }
}
