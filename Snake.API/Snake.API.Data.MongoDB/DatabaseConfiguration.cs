using Snake.API.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Data.MongoDB
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
