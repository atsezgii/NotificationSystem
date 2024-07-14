using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface INotificationRepository:IAsyncRepository<Notification>,IRepository<Notification>
    {
    }
}
