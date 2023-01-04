using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OprationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOprationClaimRepository
{
    public OprationClaimRepository(BaseDbContext context) : base(context)
    {
        // BaseDbContext'i Ef içerisinde Base Context e yolladı
    }
}
