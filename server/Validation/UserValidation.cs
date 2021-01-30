using Contracts;

namespace Validation
{
    public static class UserValidation
    {
        public static bool Valid(UserRequest request)
        {
            if(request.FirstName.Length <= 0 || request.FirstName.Length > 100)
                return false;
            if(request.LastName.Length <= 0 || request.LastName.Length > 100)
                return false;
            return true;
        }
    }
}