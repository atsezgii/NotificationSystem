using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
    {
    }
}
