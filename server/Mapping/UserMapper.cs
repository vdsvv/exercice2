using System;
using Contracts;
using Models;

namespace Mapping
{
    public static class UserMapper
    {
        public static User FromRequest(Guid userId, UserRequest request){
            var user = new User
            {
                Id = userId,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName
            };
            return user;
        }

         public static UserResponse ToResponse(User user){
            var response = new UserResponse
            {
                Id = user.Id.ToString(),
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName
            };
            return response;
        }
    }
}