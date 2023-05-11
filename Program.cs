using FishFarm.Models;
using FishFarm.Repository.BoatRepo;
using FishFarm.Repository.FishFarmRepo;
using FishFarm.Repository.WorkersRepo;
using FishFarm.Services.BoatServices;
using FishFarm.Services.FishFarmServices;
using FishFarm.Services.WorkerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FishFarmDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconn")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Repositories 
builder.Services.AddScoped<IFishFarmRepository, FishFarmRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IBoatRepository, BoatRepository>();
//Services
builder.Services.AddScoped<IFishFarmService, FishFarmService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IBoatService, BoatService>();

builder.Services.AddCors(); // cros 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(@"D:\Fish_Farm_Backend\FishFarm", "Img")),
    RequestPath = "/Img"
});*/

//cros
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
