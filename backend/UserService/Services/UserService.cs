using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using UserService.Protos;

namespace UserService.Services
{
    public class UserService : UserServiceBase
    {
        private readonly List<User> users = new List<User>();

        public override Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                Role = request.Role
            };
            users.Add(user);

            return Task.FromResult(new CreateUserResponse { User = user });
        }

        public override Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = users.FirstOrDefault(u => u.Id == request.Id);
            return Task.FromResult(new GetUserResponse { User = user });
        }

        public override Task<ListUsersResponse> ListUsers(ListUsersRequest request, ServerCallContext context)
        {
            var response = new ListUsersResponse();
            response.Users.AddRange(users);
            return Task.FromResult(response);
        }
    }
}