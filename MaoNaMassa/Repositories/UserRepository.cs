using PraticasComDapper.MaoNaMassa.Models;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Dapper;

namespace PraticasComDapper.MaoNaMassa.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<User> GetAll(SqlConnection connectionString)
            =>  _connection.GetAll<User>();

        public User Get(int id)            
            => _connection.Get<User>(id);

        public void Create(User user)
            => _connection.Insert<User>(user);

        internal object Get()
        {
            throw new NotImplementedException();
        }

        internal object Get(object connectionString)
        {
            throw new NotImplementedException();
        }
    }
}