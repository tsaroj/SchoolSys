using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SERVER.CORE.DTOs.Users;
using SERVER.CORE.Entities;
using SERVER.CORE.Interface;
using SERVER.QUERY.query;
using BCryptNet = BCrypt.Net.BCrypt;

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
        // public async Task<int> AddUser(User user)
        // {
        //     using (NpgsqlConnection connection = new NpgsqlConnection(_connectionstring))
        //     {
        //         connection.Open();
        //        
        //         var data = await connection.ExecuteAsync(UserQuery.InsertUser,user);
        //         return data;
        //     }
        // }

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

        public async Task<int> AddUser(CreateRequest userRequest)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionstring))
            {
                connection.Open();
                userRequest.Password = BCryptNet.HashPassword(userRequest.Password);
                var user = _mapper.Map<User>(userRequest);
                user.CreatedAt= DateTime.Now;
                var data = await connection.ExecuteAsync(UserQuery.InsertUser,user);
                return data;
            }
        }
    }
}