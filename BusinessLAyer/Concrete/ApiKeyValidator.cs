using BusinessLayer.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        private readonly IConfiguration _configuration;

        public ApiKeyValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsValid(string apiKey)
        {
            return apiKey == _configuration["API_KEY"];
        }
    }
}
