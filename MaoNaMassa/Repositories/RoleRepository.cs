using PraticasComDapper.MaoNaMassa.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace PraticasComDapper.MaoNaMassa.Repositories
{
    [Table("[Role]")]
    public class RoleRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    
        private readonly SqlConnection _connection;
        public RoleRepository(SqlConnection connection)
            => _connection = connection;
   
        public IEnumerable<User> Get(string connectionString)
            =>  _connection.GetAll<User>();

        public User Get(int id)
            => _connection.Get<User>(id);

        public void Create(User user)
            => _connection.Insert<User>(user);    
    } 
}
