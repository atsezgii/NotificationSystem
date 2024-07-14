using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseUser
    {
        public ICollection<Notification> SentNotifications { get; set; }
        public ICollection<Notification> ReceivedNotifications { get; set; }
    }

}
