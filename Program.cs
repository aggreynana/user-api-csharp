using UserApi.Application.Services;
using UserApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// 1. Register services BEFORE building
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Swagger (optional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Build app
var app = builder.Build();

// 3. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 4. Run
app.Run();
