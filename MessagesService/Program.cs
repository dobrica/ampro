using MessagesService.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var MessageSpecificOrigins = "MessageSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MessageSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMessageRepository, MessageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MessageSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
