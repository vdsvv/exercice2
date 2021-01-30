namespace Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Base = Root;

        public static class Users
        {
            public const string GetAll = Base + "/users";

            public const string Get = Base + "/users/{userId}";

            public const string Update = Base + "/users/{userId}";

            public const string Delete= Base + "/users/{userId}";

            public const string Create = Base + "/users";
        }
    }
}