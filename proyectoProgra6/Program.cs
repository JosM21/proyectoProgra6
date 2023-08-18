using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyectoProgra6.Models;

namespace proyectoProgra6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var CnnStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CNNSTR"));

            CnnStringBuilder.Password = "123456";

            string cnnStr = CnnStringBuilder.ConnectionString;

            builder.Services.AddDbContext<proyectoProgra6_1Context>(opcions => opcions.UseSqlServer(cnnStr));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}