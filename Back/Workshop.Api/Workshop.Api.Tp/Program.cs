using Workshop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Workshop.Api.Tp.Models.SignalR;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddDbContext<WorkshopInfrastructureDbContext>
    (configure => configure.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection2"), options =>
{
    options.MigrationsAssembly(typeof(WorkshopInfrastructureDbContext).Assembly.FullName);
}));

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials();
}); 
app.UseAuthorization();

app.MapControllers();

app.MapHub<AppHub>("/appHub");

app.Run();