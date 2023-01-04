using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IOprationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
{
}
