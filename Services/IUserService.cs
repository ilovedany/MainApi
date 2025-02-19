
using System.Xml;
namespace MainAPI.Services
{
    public interface IUserService
    {
        
        public Task<IEnumerable<User>> GetUsersAsync();
        public void AddUser(User user);
        public void DeleteUser(int id);
        public void PutUser(User user);
        public string GetXml(int id);
    }
}