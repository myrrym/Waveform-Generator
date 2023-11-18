using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Waveform_Generator.Database
{
    public partial class DatabaseManager
    {
        private readonly IConfiguration _configuration;

        public DatabaseManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("MyDatabaseConnection");
        }
    }
}
