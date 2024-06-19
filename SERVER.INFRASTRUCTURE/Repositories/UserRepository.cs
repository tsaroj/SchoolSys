using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SERVER.CORE.DTOs.Users;
using SERVER.CORE.Entities;
using SERVER.CORE.Interface;

namespace SERVER.INFRASTRUCTURE.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly string _connectionstring;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserRepository(IConfiguration configuration,IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionstring = _configuration.GetConnectionString("DbConnString");
        }
        public Task<int> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsers()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionstring))
            {
                connection.Open();
                string query = $@"select * from ""Identity"".""Users"" u; ";
                var data = (await connection.QueryAsync<UserResponse>(query)).ToList();
                return data;
            }
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            using NpgsqlConnection connection = new(_connectionstring);
            connection.Open();
            string query = $@"select * from ""Identity"".""Users"" u where u.""Id"" = @Id; ";
            var  user = await connection.QueryFirstOrDefaultAsync<UserResponse>(query, new { Id = id });
            return user;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}