using Autofac;
using Microsoft.Extensions.Configuration;
using StudentApp.Data.Data;
using StudentApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Data
{
    public class StudenAppModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public StudenAppModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }
         
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentAppContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StudentAppUnitOfWork>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName);

            builder.RegisterType<StudentServices>();
        }
    }
}
