using WatchMarketApp.Extensions;
using WatchMarketApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.ConfigureService();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
