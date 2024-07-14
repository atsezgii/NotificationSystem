using Core.DataAccess;

namespace Core.Entities
{
    public class BaseUser : Entity
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserName { get; set; }


    }
}
