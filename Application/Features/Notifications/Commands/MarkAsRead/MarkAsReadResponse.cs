using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Commands.MarkAsRead
{
    public class MarkAsReadResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Contents { get; set; }
        public DateTime PostedDate { get; set; }
        public bool ReadStatus { get; set; }
    }
}
