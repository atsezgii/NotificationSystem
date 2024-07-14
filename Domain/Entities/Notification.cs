using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification : Entity
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Contents { get; set; }
        public DateTime PostedDate { get; set; }
        public bool ReadStatus { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }

    }
}
