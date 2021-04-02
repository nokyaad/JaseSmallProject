using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JaseSmallProject.Models
{
    public class ApiCalls
    {
        private HttpClient _httpClient;

        public ApiCalls()
        {
            _httpClient = new HttpClient();
        }


    }
}
