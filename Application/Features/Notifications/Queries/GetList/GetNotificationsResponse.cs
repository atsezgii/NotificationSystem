using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Queries.GetList
{
    public class GetNotificationsResponse
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public string Contents { get; set; }
        public DateTime PostedDate { get; set; }
        public bool ReadStatus { get; set; }
    }
}
