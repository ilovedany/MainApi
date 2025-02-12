using MainAPI.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Host=localhost;Port=5432;Database=SourceAPI;Username=postgres;Password=123";

IServiceCollection services = builder.Services;

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
    )
);
services.AddTransient<IUserService>(provider => new UserService(connectionString));
services.AddTransient<ISpecialistRankService>(provider => new SpecialistRankService(connectionString));

builder.Services.AddControllers();

var app = builder.Build();




app.MapControllers();

app.UseHttpsRedirection();
app.UseCors();
app.Run();