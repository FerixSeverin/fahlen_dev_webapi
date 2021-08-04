using System.Collections.Generic;

namespace fahlen_dev_webapi.Contracts.Response
{
    public class AuthFailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}