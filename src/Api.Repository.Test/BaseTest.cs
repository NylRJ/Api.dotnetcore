using System;
using Api.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Repository.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {


        }



    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; set; }
        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>

                o.UseMySql($"Persist Security Info=True;Server=localhost;Port=3306;Database={dataBaseName};User=root;Password=J1r@y@"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
