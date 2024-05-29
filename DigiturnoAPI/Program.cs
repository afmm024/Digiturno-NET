using DigiturnoAPI.Hubs;
using DigiturnoAPI.Services;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DBSettings>(
    builder.Configuration.GetSection("DBSettings"));
builder.Services.AddScoped<ITicketServices, TicketsService>();
builder.Services.AddScoped<DatabaseProvider>();
builder.Services.AddSignalR();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<HubDigiturno>("/hub");

app.Run();
