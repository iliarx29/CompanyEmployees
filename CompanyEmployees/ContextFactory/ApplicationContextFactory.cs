﻿//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Repository;

//namespace CompanyEmployees.ContextFactory
//{
//    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
//    {
//        public ApplicationContext CreateDbContext(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();
//            var builder = new DbContextOptionsBuilder<ApplicationContext>()
//                .UseSqlServer(configuration.GetConnectionString("sqlConnection"), 
//                b => b.MigrationsAssembly("CompanyEmployees"));

//            return new ApplicationContext(builder.Options);
//        }
//    }
//}
