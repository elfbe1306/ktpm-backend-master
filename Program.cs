using ktpm_backend_master;
using ktpm_backend_master.Repositories;
using ktpm_backend_master.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<SupabaseClientService>();
builder.Services.AddScoped<InterfaceUserRepository, UserRepository>();
builder.Services.AddScoped<InterfaceUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
       a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
