namespace fahlen_dev_webapi.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Base = Root;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }
    }
}