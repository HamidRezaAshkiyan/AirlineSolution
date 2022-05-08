using Airline.DataAccess.Sqlite.Library.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services
//        .AddDbContext<AirlineContext>(opt =>
//                                           opt.UseSqlServer
//                                               (builder.Configuration.GetConnectionString("AirlineDB")));

builder.Services
       .AddDbContext<AirlineContext>(opt =>
                                          opt.UseSqlite
                                              (builder.Configuration.GetConnectionString("AirlineSqliteDB")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPersonRepo, SqlPersonRepo>();
builder.Services.AddControllers().AddNewtonsoftJson(s => {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();