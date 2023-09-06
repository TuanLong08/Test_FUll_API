using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DaTa.Context
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build();
            var connectionStrings = configurationRoot.GetConnectionString("DefaultConnect");
            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            return new MyDBContext(optionsBuilder.Options);
        }
    }
}
