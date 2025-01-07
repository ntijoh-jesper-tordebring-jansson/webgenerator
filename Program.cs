using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace webgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "seed")
            {
                Seeder.SeedDatabase();
                return;
            }

            Console.WriteLine("Continuing with program");
        }
    }
}
