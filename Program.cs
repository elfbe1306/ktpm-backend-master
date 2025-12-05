using ktpm_backend_master;
using ktpm_backend_master.Repositories.Course;
using ktpm_backend_master.Repositories.LearningContentFolder;
using ktpm_backend_master.Repositories.User;
using ktpm_backend_master.Services.Course;
using ktpm_backend_master.Services.LearningContentFolder;
using ktpm_backend_master.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<SupabaseClientService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILearningContentFolderRepository, LearningContentFolderRepository>();
builder.Services.AddScoped<ILearningContentFolderService, LearningContentFolderService>();

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
