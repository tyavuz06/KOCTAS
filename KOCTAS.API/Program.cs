using KOCTAS.Business;
using KOCTAS.Business.Core;
using KOCTAS.Business.Interfaces;
using KOCTAS.Data.Core;
using KOCTAS.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMapper, AutoMap>();
builder.Services.AddSingleton<IMovieBusiness, MovieBusiness>();
builder.Services.AddSingleton<IMovieDal, MovieDal>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
